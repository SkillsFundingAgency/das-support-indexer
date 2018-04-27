using System.Collections.Generic;
using SFA.DAS.Support.Shared.Authentication;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    public class EmployerAccountSiteManifest : List<SiteResource> 
    {
        public EmployerAccountSiteManifest()
        {
           // ServiceIdentity = SupportServiceIdentity.SupportEmployerAccount;
            this.AddRange( new[]
            {
                new SiteResource
                {
                    ResourceKey = SupportServiceResourceKey.EmployerAccount,
                    SearchItemsUrl = "/api/search/accounts/{0}/{1}",
                    SearchTotalItemsUrl ="/api/search/accounts/totalCount/{0}",
                    SearchCategory = SearchCategory.Account,
                   
                }
            });
        }
    }
}