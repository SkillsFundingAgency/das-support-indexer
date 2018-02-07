﻿using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    public class EmployerUserSiteManifest : SiteManifest
    {
        public EmployerUserSiteManifest()
        {
            ServiceIdentity = SupportServiceIdentity.SupportEmployerUser;
            Resources = new[]
            {
                new SiteResource
                {
                    ResourceKey = SupportServiceResourceKey.None,
                    ResourceTitle = "Overview",

                    ResourceUrlFormat = "/user/index/{0}",
                    SearchItemsUrl = "/api/search/users",
                    SearchCategory = SearchCategory.User,
                    HeaderKey = SupportServiceResourceKey.EmployerUserHeader,
                    IsNavigationItem = true
                },
                new SiteResource
                {
                    ResourceKey = SupportServiceResourceKey.EmployerUserHeader,
                    ResourceUrlFormat = "/user/header/{0}"

                },
                new SiteResource
                {
                    ResourceKey = SupportServiceResourceKey.EmployerUserAccounts,
                    ResourceUrlFormat = "/user/header/{0}"

                }
            };
        }
        
    }
}