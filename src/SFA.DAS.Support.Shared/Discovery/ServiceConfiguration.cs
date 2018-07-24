using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Support.Shared.Authentication;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Discovery
{
    [Obsolete]
    public class ServiceConfiguration : List<SiteSearchManifest>, IServiceConfiguration
    {
        public Uri FindSiteBaseUriForManfiestElement(Dictionary<SupportServiceIdentity, Uri> sites,
            SupportServiceResourceKey key)
        {
            if (sites == null) throw new ArgumentNullException(nameof(sites));
            SiteSearchManifest manifest = null;
            foreach (var item in this)
                if (item.SearchResources.Any(r => r.ResourceKey == key))
                    manifest = item;
            if (manifest == null) throw new ArgumentNullException(nameof(manifest));
            var site = sites.FirstOrDefault(x => x.Key == manifest.ServiceIdentity);
            if (site.Value == null) throw new ArgumentNullException(nameof(site));
            ;
            return site.Value;
        }

        public bool ResourceExists(SupportServiceResourceKey key)
        {
            var resource = FindResource(key);

            return resource != null;
        }

       
        public SiteSearchResource GetResource(SupportServiceResourceKey key)
        {
            var resource = FindResource(key);
            return resource;
        }


        public IEnumerable<NavItem> GetNavItems(SupportServiceResourceKey key, string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            var resource = FindResource(key);
            var manifest = ManifestFromResource(resource);

            return manifest.SearchResources.Select(r => new NavItem
            {
                Title = r.ResourceTitle,
                Key = r.ResourceKey,
                Href = $"/resource?key={r.ResourceKey}&id={id}"
            });
        }

        public SiteSearchManifest ManifestFromResource(SiteSearchResource resource)
        {
            foreach (var manifest in this)
                if (manifest.SearchResources.Any(item => item.ResourceKey == resource.ResourceKey))
                    return manifest;
            return null;
        }

        public SiteSearchResource FindResource(SupportServiceResourceKey key)
        {
            foreach (var manifest in this)
            foreach (var item in manifest.SearchResources)
                if (item.ResourceKey == key)
                    return item;
            return null;
        }

    }
}