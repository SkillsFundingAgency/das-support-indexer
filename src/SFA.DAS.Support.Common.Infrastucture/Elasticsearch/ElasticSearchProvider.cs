﻿using System;
using System.Linq;
using System.Net;
using Nest;
using SFA.DAS.Support.Common.Infrastucture.Indexer;
using SFA.DAS.Support.Common.Infrastucture.Models;
using SFA.DAS.Support.Common.Infrastucture.Settings;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Common.Infrastucture.Elasticsearch
{
    public class ElasticSearchProvider : ISearchProvider
    {
        private readonly IElasticsearchCustomClient _elasticSearchClient;
        private readonly IIndexNameCreator _indexNameCreator;
        private readonly ISearchSettings _searchSettings;

        private string _indexAliasName;

        public ElasticSearchProvider(IElasticsearchCustomClient elasticSearchClient,
            ISearchSettings searchSettings,
            IIndexNameCreator indexNameCreator)
        {
            _elasticSearchClient = elasticSearchClient;
            _searchSettings = searchSettings;
            _indexNameCreator = indexNameCreator;
        }

        public PagedSearchResponse<UserSearchModel> FindUsers(string searchText, SearchCategory searchType,
            int pageSize = 10, int pageNumber = 1)
        {
            if (searchType != SearchCategory.User) return null;

            _indexAliasName = _indexNameCreator.CreateIndexesAliasName(_searchSettings.IndexName, searchType);

            var response = _elasticSearchClient.Search<UserSearchModel>(s => s.Index(_indexAliasName)
                .Type(Types.Type<UserSearchModel>())
                .Skip(pageSize * GetPage(pageNumber))
                .Take(pageSize)
                .Query(q => q
                    .MultiMatch(mp => mp
                        .Query(searchText)
                        .Fields(f => f.Field(x => x.Name)))), string.Empty);

            var countResponse = _elasticSearchClient.Count<UserSearchModel>(c => c.Index(_indexAliasName)
                .Type(Types.Type<UserSearchModel>())
                .Query(q => q
                    .MultiMatch(mp => mp
                        .Query(searchText)
                        .Fields(f => f.Field(x => x.Name)))), string.Empty);


            if (response?.ApiCall.HttpStatusCode != (int) HttpStatusCode.OK ||
                countResponse?.ApiCall.HttpStatusCode != (int) HttpStatusCode.OK)
                throw new Exception(
                    $"Received non-200 response when trying to fetch the search items from elastic serach Index, Status Code:{response.ApiCall.HttpStatusCode}");

            return GetSearchResponse(pageSize, response, countResponse);
        }

        public PagedSearchResponse<AccountSearchModel> FindAccounts(string searchText, SearchCategory searchType,
            int pageSize = 10, int pageNumber = 1)
        {
            if (searchType != SearchCategory.Account) return null;
            _indexAliasName = _indexNameCreator.CreateIndexesAliasName(_searchSettings.IndexName, searchType);

            var response = _elasticSearchClient.Search<AccountSearchModel>(s => s.Index(_indexAliasName)
                .Type(Types.Type<AccountSearchModel>())
                .Skip(pageSize * GetPage(pageNumber))
                .Take(pageSize)
                .Query(q => q
                    .MultiMatch(mp => mp
                        .Query(searchText)
                        .Fields(f => f
                            .Field(x => x.Account)))), string.Empty);

            var countResponse = _elasticSearchClient.Count<AccountSearchModel>(c => c.Index(_indexAliasName)
                .Type(Types.Type<AccountSearchModel>())
                .Query(q => q
                    .MultiMatch(mp => mp
                        .Query(searchText)
                        .Fields(f => f
                            .Field(x => x.Account)))), string.Empty);


            if (response?.ApiCall.HttpStatusCode != (int) HttpStatusCode.OK ||
                countResponse?.ApiCall.HttpStatusCode != (int) HttpStatusCode.OK)
                throw new Exception(
                    $"Received non-200 response when trying to fetch the search items from elastic serach Index, Status Code:{response.ApiCall.HttpStatusCode}");
            return GetSearchResponse(pageSize, response, countResponse);
        }

        private PagedSearchResponse<T> GetSearchResponse<T>(int pageSize, ISearchResponse<T> response,
            ICountResponse countResponse) where T : class
        {
            var totalcount = countResponse == null ? 0 : countResponse.Count;
            var responsePageSize = pageSize == 0 ? 1 : pageSize;
            var lastPage = (int) (totalcount / responsePageSize);


            return new PagedSearchResponse<T>
            {
                LastPage = lastPage <= 0 ? 1 : lastPage,
                TotalCount = totalcount,
                Results = response?.Documents?.Select(d => d).ToList()
            };
        }

        private int GetPage(int pageNumber)
        {
            return pageNumber <= 1 ? 0 : pageNumber;
        }
    }
}