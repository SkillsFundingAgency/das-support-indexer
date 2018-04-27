using System.Collections.Generic;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    public class EmployerUserSiteManifest : List<SiteResource>
    {
        public EmployerUserSiteManifest()
        {
          this.AddRange( new[]
            {
                new SiteResource
                {
                    ServiceIdentity = SupportServiceIdentity.SupportEmployerUser,
                    SearchItemsUrl = "/api/search/users/{0}/{1}",
                    SearchTotalItemsUrl = "/api/search/users/totalCount/{0}",
                    SearchCategory = SearchCategory.User,
                }
            });
        }
        
    }
}