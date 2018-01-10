﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Common.Infrastucture.Indexer;
using SFA.DAS.Support.Common.Infrastucture.Models;
using SFA.DAS.Support.Portal.ApplicationServices.Handlers;
using SFA.DAS.Support.Portal.ApplicationServices.Queries;
using SFA.DAS.Support.Portal.ApplicationServices.Responses;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using SFA.DAS.Support.Portal.Core.Services;
using SFA.DAS.Support.Portal.Infrastructure.Services;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.Handlers
{
    [TestFixture]
    public class SearchHandlerTests
    {
        private SearchHandler _unit;
        private SearchResponse _actual;
        private Mock<ISearchProvider> _mockSearchProvider;


        [SetUp]
        public void Setup()
        {
            _mockSearchProvider = new Mock<ISearchProvider>();
        }

        [Test]
        public async Task ItShouldReturnTheRepositoryResultsForTheQuery()
        {
            var searchQuery = new SearchQuery
            {
                SearchTerm = "NHS",
                SearchType = SearchCategory.Account
            };

            var ecpectedResult = new List<AccountSearchModel>
                                {
                                    new AccountSearchModel
                                    {
                                        Account = "NHS",
                                        SearchType = SearchCategory.Account
                                    }
                                };

            _mockSearchProvider
                .Setup(x => x.FindAccounts(searchQuery.SearchTerm, searchQuery.SearchType, It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new PagedSearchResponse<AccountSearchModel>
                {
                    Results = ecpectedResult
                });


            _unit = new SearchHandler(_mockSearchProvider.Object);
            _actual = await _unit.Handle(searchQuery);

            CollectionAssert.IsNotEmpty(_actual.AccountSearchResult.Results);
            Assert.AreEqual(ecpectedResult.Count, _actual.AccountSearchResult.Results.ToList().Count);
        }

    }
}