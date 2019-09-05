﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using Elasticsearch.Net;
using FluentAssertions;
using Moq;
using Nest;
using NUnit.Framework;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Common.Infrastucture.Elasticsearch;
using SFA.DAS.Support.Common.Infrastucture.Settings;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Common.Infrastucture.UnitTests
{
    [TestFixture]
    public class ElasticSearchIndexProviderTest
    {
        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILog>();
            _clientMock = new Mock<IElasticsearchCustomClient>();
            _settings = new Mock<ISearchSettings>();

            _settings
                .Setup(x => x.IndexShards)
                .Returns(1);

            _settings
                .Setup(x => x.IndexReplicas)
                .Returns(0);

            _loggerMock
                .Setup(x => x.Error(It.IsAny<Exception>(), It.IsAny<string>()));

            _deleteResponse = new Mock<DeleteIndexResponse>();
            _deleteResponse
                .Setup(x => x.Acknowledged)
                .Returns(true);
        }

        private Mock<IElasticsearchCustomClient> _clientMock;
        private Mock<ILog> _loggerMock;
        private Mock<ISearchSettings> _settings;
        private Mock<DeleteIndexResponse> _deleteResponse;

        private ElasticSearchIndexProvider _sut;

        private const string _indexName = "DummyIndex";
        private const string _aliasName = "DummyAlias";

        [Test]
        public void ShouldCallClientCreateIndexAliasIfAliasDoNotExist()
        {
            //Arrange 
            var aliasExist = false;

            var objectExistsResponse = new Mock<ExistsResponse>();
            objectExistsResponse
                .Setup(x => x.Exists)
                .Returns(aliasExist);

            _clientMock
                .Setup(x => x.AliasExists(It.IsAny<string>(), string.Empty))
                .Returns(objectExistsResponse.Object)
                .Verifiable();

            _clientMock
                .Setup(x => x.Alias(_aliasName, _indexName, string.Empty))
                .Verifiable();

            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            _sut.CreateIndexAlias(_indexName, _aliasName);

            //Assert 
            _clientMock
                .Verify(x => x.AliasExists(It.IsAny<string>(), string.Empty),
                    Times.AtLeastOnce);

            _clientMock
                .Verify(x => x.Alias(_aliasName, _indexName, string.Empty), Times.AtLeastOnce);
        }


        [Test]
        public void ShouldCallClientWhenCheckingIfIndexExists()
        {
            //Arrange 
            var indexExistsResponse = new Mock<ExistsResponse>();
            indexExistsResponse
                .Setup(x => x.Exists)
                .Returns(true);

            _clientMock
                .Setup(x => x.IndexExists(_indexName, string.Empty))
                .Returns(indexExistsResponse.Object)
                .Verifiable();

            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            _sut.IndexExists(_indexName);

            //Assert 
            _clientMock
                .Verify(x => x.IndexExists(_indexName, string.Empty), Times.AtLeastOnce);
        }

        [Test]
        public void ShouldCallClientWhenCreatingIndex()
        {
            //Arrange 
            var apiCall = new Mock<IApiCallDetails>();
            apiCall.Setup(x => x.HttpStatusCode)
                .Returns((int) HttpStatusCode.OK);

            var response = new Mock<CreateIndexResponse>();
            response
                .Setup(o => o.ApiCall)
                .Returns(apiCall.Object);


            var mockExistResponse = new Mock<ExistsResponse>();
            mockExistResponse.SetupGet(x => x.Exists).Returns(false);

            _clientMock
                .Setup(x => x.IndexExists(_indexName, string.Empty))
                .Returns(mockExistResponse.Object);

            _clientMock
                .Setup(x => x.CreateIndex(_indexName, It.IsAny<Func<CreateIndexDescriptor, ICreateIndexRequest>>(),
                    string.Empty))
                .Returns(response.Object);


            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            _sut.CreateIndex<UserSearchModel>(_indexName);

            //Assert 
            _clientMock
                .Verify(x => x.IndexExists(_indexName, string.Empty), Times.AtLeastOnce);

            _clientMock
                .Verify(
                    x => x.CreateIndex(_indexName, It.IsAny<Func<CreateIndexDescriptor, ICreateIndexRequest>>(),
                        string.Empty), Times.AtLeastOnce);
        }


        [Test]
        public void ShouldCallClientWhenDeletingIndex()
        {
            //Arrange 
            _clientMock
                .Setup(x => x.DeleteIndex(_indexName, string.Empty))
                .Returns(_deleteResponse.Object);

            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            _sut.DeleteIndex(_indexName);

            //Assert 
            _clientMock
                .Verify(x => x.DeleteIndex(_indexName, string.Empty), Times.AtLeastOnce);
        }

        [Test]
        public void ShouldCallClientWhenIndexingDocuments()
        {
            //Arrange 

            var documents = new List<UserSearchModel>
            {
                new UserSearchModel
                {
                    Id = "A001"
                }
            };

            _clientMock
                .Setup(x => x.BulkAll(documents, _indexName, 1000))
                .Verifiable();


            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            _sut.IndexDocuments(_indexName, documents);

            //Assert 
            _clientMock
                .Verify(x => x.BulkAll(documents, _indexName, 1000), Times.AtLeastOnce);
        }

        [Test]
        public void ShouldDeleteOnlyOldIndexes()
        {
            //Arrange 
            var indexToDelete01 = "at-das-support-portal-account_20180119100000";
            var indexToDelete02 = "at-das-support-portal-account_20180119103000";
            var indexToKeep01 = "at-das-support-portal-account_20180119110000";
            var indexToKeep02 = "at-das-support-portal-account_20180119113000";


            var indexList = new Dictionary<string, IndicesStats>();
            indexList.Add(indexToDelete01, new IndicesStats());
            indexList.Add(indexToKeep01, new IndicesStats());
            indexList.Add(indexToDelete02, new IndicesStats());
            indexList.Add(indexToKeep02, new IndicesStats());

            var readOnlyMockResult = new ReadOnlyDictionary<string, IndicesStats>(indexList);

            var indicesStatsResult = new Mock<IndicesStatsResponse>();
            indicesStatsResult
                .SetupGet(x => x.Indices)
                .Returns(readOnlyMockResult);

            _clientMock
                .Setup(x => x.IndicesStats(Indices.All, null, string.Empty))
                .Returns(indicesStatsResult.Object);

            _clientMock
                .Setup(x => x.DeleteIndex(It.IsAny<IndexName>(), string.Empty))
                .Returns(_deleteResponse.Object)
                .Verifiable();

            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            _sut.DeleteIndexes(2, "at-das-support-portal-account");

            ////Assert 

            _clientMock
                .Verify(x => x.DeleteIndex(indexToDelete01, string.Empty), Times.Once);

            _clientMock
                .Verify(x => x.DeleteIndex(indexToDelete02, string.Empty), Times.Once);

            _clientMock
                .Verify(x => x.DeleteIndex(It.IsAny<IndexName>(), string.Empty), Times.Exactly(2));
        }

        [Test]
        public void ShouldSwapAliasIfAliasAlreadyExist()
        {
            //Arrange 
            var aliasExist = true;

            var objectExistsResponse = new Mock<ExistsResponse>();
            objectExistsResponse
                .Setup(x => x.Exists)
                .Returns(aliasExist);

            _clientMock
                .Setup(x => x.AliasExists(It.IsAny<string>(), string.Empty))
                .Returns(objectExistsResponse.Object)
                .Verifiable();

            _clientMock
                .Setup(x => x.GetIndicesPointingToAlias(_aliasName, string.Empty))
                .Returns(new List<string> {_indexName})
                .Verifiable();

            _clientMock
                .Setup(x => x.Alias(It.IsAny<IBulkAliasRequest>(), string.Empty))
                .Verifiable();

            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            _sut.CreateIndexAlias(_indexName, _aliasName);

            //Assert 
            _clientMock
                .Verify(x => x.AliasExists(It.IsAny<string>(), string.Empty),
                    Times.AtLeastOnce);

            _clientMock
                .Verify(x => x.Alias(It.IsAny<IBulkAliasRequest>(), string.Empty), Times.AtLeastOnce);

            _clientMock
                .Verify(x => x.GetIndicesPointingToAlias(_aliasName, string.Empty), Times.AtLeastOnce);
        }

        [Test]
        public void ShouldThrowExceptiontWhenIndexDeletionRespnseIsInValid()
        {
            //Arrange 
            DeleteIndexResponse deleteResponse = null;

            _clientMock
                .Setup(x => x.DeleteIndex(_indexName, string.Empty))
                .Returns(deleteResponse);

            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            Action action = () => _sut.DeleteIndex(_indexName);

            //Assert 
            action.ShouldThrow<Exception>();
        }

        [Test]
        public void ShouldThrowExceptionWhenIndexCreationStatusIsNotOk()
        {
            //Arrange 

            var response = new Mock<CreateIndexResponse>();
            response
                .Setup(o => o.ApiCall.HttpStatusCode)
                .Returns((int) HttpStatusCode.BadRequest);


            _clientMock
                .Setup(x => x.CreateIndex(_indexName, It.IsAny<Func<CreateIndexDescriptor, ICreateIndexRequest>>(),
                    string.Empty))
                .Returns(response.Object)
                .Verifiable();

            //Act
            _sut = new ElasticSearchIndexProvider(_clientMock.Object, _loggerMock.Object, _settings.Object);
            Action action = () => _sut.CreateIndex<UserSearchModel>(_indexName);

            //Assert 
            action.ShouldThrow<Exception>();
        }
    }
}