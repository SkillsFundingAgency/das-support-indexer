using System;
using System.Collections.Generic;

namespace SFA.DAS.Support.Shared.Discovery
{
    [Obsolete]
    public interface ISiteSearchManifest
    {
        SupportServiceIdentity ServiceIdentity { get; set; }
        IEnumerable<SiteSearchResource> SearchResources { get; }
     
    }
}