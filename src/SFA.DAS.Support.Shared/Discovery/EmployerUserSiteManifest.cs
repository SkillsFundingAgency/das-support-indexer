using System;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    [Obsolete]
    public class EmployerUserSiteManifest : SiteManifest
    {
        public EmployerUserSiteManifest()
        {
            ServiceIdentity = SupportServiceIdentity.SupportEmployerUser;
            Resources = new[]
            {
                new SiteResource
                {
                    ResourceKey = SupportServiceResourceKey.EmployerUser,
                    ResourceTitle = "Overview",

                    SearchItemsUrl = "/api/search/users/{0}/{1}",
                    SearchTotalItemsUrl = "/api/search/users/totalCount/{0}",
                    SearchCategory = SearchCategory.User,
                    
                },
            };
        }
    }
}