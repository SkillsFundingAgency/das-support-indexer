using System;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    [Obsolete]
    public class EmployerUserSiteManifest : SiteSearchManifest
    {
        public EmployerUserSiteManifest()
        {
            ServiceIdentity = SupportServiceIdentity.SupportEmployerUser;
            SearchResources = new[]
            {
                new SiteSearchResource
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