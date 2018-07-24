using System;
using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Discovery
{
    [Obsolete]
    public interface ISiteManifest
    {
        SupportServiceIdentity ServiceIdentity { get; set; }
        IEnumerable<SiteResource> Resources { get; }
     
    }
}