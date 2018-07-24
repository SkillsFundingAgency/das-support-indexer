using System;
using System.Collections.Generic;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Discovery
{
    public interface IServiceConfiguration
    {
        bool ResourceExists(SupportServiceResourceKey key);
        SiteSearchResource GetResource(SupportServiceResourceKey key);
        IEnumerable<NavItem> GetNavItems(SupportServiceResourceKey key, string id);
        SiteSearchManifest ManifestFromResource(SiteSearchResource resource);
        SiteSearchResource FindResource(SupportServiceResourceKey key);

        Uri FindSiteBaseUriForManfiestElement(Dictionary<SupportServiceIdentity, Uri> sites,
            SupportServiceResourceKey challengeKey);
    }
}