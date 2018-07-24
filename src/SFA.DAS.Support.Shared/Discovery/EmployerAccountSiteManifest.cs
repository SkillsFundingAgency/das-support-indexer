using System;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    [Obsolete]
    public class EmployerAccountSiteManifest : SiteSearchManifest
    {
        public EmployerAccountSiteManifest()
        {
            ServiceIdentity = SupportServiceIdentity.SupportEmployerAccount;
            SearchResources = new[]
            {
                new SiteSearchResource
                {
                    ResourceKey = SupportServiceResourceKey.EmployerAccount,
                    ResourceTitle = "Organisations",
                    SearchItemsUrl = "/api/search/accounts/{0}/{1}",
                    SearchTotalItemsUrl = "/api/search/accounts/totalCount/{0}",
                    SearchCategory = SearchCategory.Account,
                },
            };
           
        }
    }
}