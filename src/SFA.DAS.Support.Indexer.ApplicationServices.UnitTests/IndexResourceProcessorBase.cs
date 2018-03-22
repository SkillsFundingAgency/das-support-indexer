using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Moq;
using Nest;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Common.Infrastucture.Elasticsearch;
using SFA.DAS.Support.Common.Infrastucture.Indexer;
using SFA.DAS.Support.Common.Infrastucture.Settings;
using SFA.DAS.Support.Indexer.ApplicationServices.Settings;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.SearchIndexModel;
using SFA.DAS.Support.Shared.SiteConnection;

namespace SFA.DAS.Support.Indexer.ApplicationServices.UnitTests
{
    public class IndexResourceProcessorBase
    {
        protected const string _indexName = "new_index_name";
        protected const int _indexToRetain = 5;
        protected IEnumerable<AccountSearchModel> _accountModels;
        protected SiteResource _accountSiteResource;
        protected Uri _baseUrl;

        protected Mock<ISiteConnector> _downloader;
        protected Mock<IElasticsearchCustomClient> _elasticClient;
        protected Mock<IIndexNameCreator> _indexNameCreator;
        protected Mock<IIndexProvider> _indexProvider;
        protected Mock<ILog> _logger;
        protected Mock<ISearchSettings> _searchSettings;
        protected Mock<ISiteSettings> _siteSettings;
        protected SiteResource _userSiteResource;


        protected void Initialise()
        {
            _baseUrl = new Uri("http://localhost");

            _accountModels = new List<AccountSearchModel>
            {
                new AccountSearchModel
                {
                    Account = "Valtech"
                }
            };


            _accountSiteResource = new SiteResource
            {
                SearchCategory = SearchCategory.Account,
                SearchTotalItemsUrl = "localhost",
                SearchItemsUrl = "localhost"
            };

            _userSiteResource = new SiteResource
            {
                SearchCategory = SearchCategory.User,
                SearchTotalItemsUrl = "localhost",
                SearchItemsUrl = "localhost"
            };


            _downloader = new Mock<ISiteConnector>();
            _indexProvider = new Mock<IIndexProvider>();

            _searchSettings = new Mock<ISearchSettings>();
            _searchSettings.Setup(o => o.IndexName).Returns(_indexName);


            _logger = new Mock<ILog>();
            _indexNameCreator = new Mock<IIndexNameCreator>();
            _elasticClient = new Mock<IElasticsearchCustomClient>();
            _siteSettings = new Mock<ISiteSettings>();

            var existsResponse = new Mock<IExistsResponse>();

            existsResponse
                .SetupGet(o => o.Exists)
                .Returns(false);

            _indexNameCreator
                .Setup(o => o.CreateNewIndexName(_indexName, SearchCategory.Account))
                .Returns(_indexName);

            _indexNameCreator
                .Setup(o => o.CreateIndexesAliasName(_indexName, SearchCategory.Account))
                .Returns("new_index_name_Alias");

            _elasticClient
                .Setup(o => o.IndexExists(_indexName, string.Empty))
                .Returns(existsResponse.Object);

            var createIndexResponse = new Mock<ICreateIndexResponse>();
            createIndexResponse
                .Setup(o => o.ApiCall.HttpStatusCode)
                .Returns((int) HttpStatusCode.OK);

            _elasticClient
                .Setup(x => x.CreateIndex(_indexName, It.IsAny<Func<CreateIndexDescriptor, ICreateIndexRequest>>(),
                    string.Empty))
                .Returns(createIndexResponse.Object);

            _downloader
                .Setup(o => o.Download<IEnumerable<AccountSearchModel>>(_baseUrl))
                .Returns(Task.FromResult(_accountModels));

            _downloader
                .Setup(o => o.Download(It.IsAny<Uri>()))
                .Returns(Task.FromResult("50"));

            _downloader
                .Setup(o => o.LastCode)
                .Returns(HttpStatusCode.OK);

            _indexProvider
                .Setup(o => o.DeleteIndex(_indexName));

            _indexProvider
                .Setup(o => o.CreateIndexAlias(_indexName, It.IsAny<string>()));

            _indexProvider
                .Setup(o => o.DeleteIndexes(_indexToRetain, It.IsAny<string>()));
        }
    }
}