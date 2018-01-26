﻿using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Common.Infrastucture.Elasticsearch;
using SFA.DAS.Support.Common.Infrastucture.Indexer;
using SFA.DAS.Support.Common.Infrastucture.Settings;
using SFA.DAS.Support.Indexer.ApplicationServices.Settings;
using SFA.DAS.Support.Shared.SearchIndexModel;
using System;
using System.Net;

namespace SFA.DAS.Support.Indexer.ApplicationServices.Services
{
    public class AccountIndexResourceProcessor : BaseIndexResourceProcessor<AccountSearchModel>
    {
        public AccountIndexResourceProcessor(ISiteSettings settings,
            IGetSiteManifest siteService,
            IGetSearchItemsFromASite downloader,
            IIndexProvider indexProvider,
            ISearchSettings searchSettings,
            ILog logger,
            IIndexNameCreator indexNameCreator,
            IElasticsearchCustomClient elasticClient)
            : base(settings, 
                  siteService, 
                  downloader, 
                  indexProvider, 
                  searchSettings,
                  logger,
                  indexNameCreator,
                  elasticClient)
        {
        }

        protected override bool ContinueProcessing(SearchCategory searchCategory)
        {
            return searchCategory == SearchCategory.Account;
        }

        protected override void CreateIndex(string indexName)
        {
            if (!_elasticClient.IndexExists(indexName, string.Empty).Exists)
            {
                var response = _elasticClient.CreateIndex(
                              indexName,
                              i => i
                                  .Settings(settings =>
                                      settings
                                      .NumberOfShards(_searchSettings.IndexShards)
                                      .NumberOfReplicas(_searchSettings.IndexReplicas)
                                      )
                                  .Mappings(ms => ms
                                      .Map<AccountSearchModel>(m => m
                                          .Properties(p => p
                                          .Text(k => k
                                                 .Name(n => n.Account)
                                                 .Fielddata(true)
                                                 .Fields(kf => kf
                                                 .Keyword(kfk => kfk.Name(kfkn => kfkn.Account))))
                                          .Keyword(k => k.Name(n => n.AccountID))
                                          .Keyword(k => k.Name(n => n.PayeSchemeId))
                                          )))
                                  , string.Empty);

                ValidateResponse(indexName, response);
            }
        }
    }
}