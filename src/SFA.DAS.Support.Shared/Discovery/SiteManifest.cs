using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SFA.DAS.Support.Shared.Authentication;

namespace SFA.DAS.Support.Shared.Discovery
{
    [ExcludeFromCodeCoverage]
    [Obsolete]
    public class SiteManifest : ISiteManifest
    {
        public SupportServiceIdentity ServiceIdentity { get; set; }
        public IEnumerable<SiteResource> Resources { get; set; } = new List<SiteResource>();
        
    }
}