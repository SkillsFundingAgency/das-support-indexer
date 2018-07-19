﻿using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Indexer.ApplicationServices.Services;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Indexer.ApplicationServices.UnitTests
{
    [TestFixture]
    public class UserIndexResourceProcessorTest : IndexResourceProcessorBase
    {
        [SetUp]
        public void Setup()
        {
            Initialise();
        }


        [Test]
        public async Task ShouldProcessOnlyUserSearchType()
        {
            _indexNameCreator
                .Setup(o => o.CreateNewIndexName(_indexName, SearchCategory.Account))
                .Returns("new_index_name");


            var _sut = new UserIndexResourceProcessor(_siteSettings.Object,
                _downloader.Object,
                _indexProvider.Object,
                _searchSettings.Object,
                _logger.Object,
                _indexNameCreator.Object,
                _elasticClient.Object);

            await _sut.ProcessResource(new Uri("http://localhost"), _accountSiteResource);

            _indexNameCreator
                .Verify(o => o.CreateNewIndexName(_indexName, SearchCategory.Account), Times.Never);
        }
    }
}