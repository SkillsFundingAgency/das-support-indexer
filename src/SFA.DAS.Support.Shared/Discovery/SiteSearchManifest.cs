using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SFA.DAS.Support.Shared.Discovery
{
    [ExcludeFromCodeCoverage]
    [Obsolete]
    public class SiteSearchManifest : ISiteSearchManifest
    {
        public SupportServiceIdentity ServiceIdentity { get; set; }
        public IEnumerable<SiteSearchResource> SearchResources { get; set; } = new List<SiteSearchResource>();
        
    }
}