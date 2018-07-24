using System;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    [Obsolete]
    public class EmployerAccountSiteManifest : SiteManifest
    {
        public EmployerAccountSiteManifest()
        {
            ServiceIdentity = SupportServiceIdentity.SupportEmployerAccount;
            Resources = new[]
            {
                new SiteResource
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