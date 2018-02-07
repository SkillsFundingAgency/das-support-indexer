﻿using System.Collections.Generic;
using SFA.DAS.Support.Shared.Authentication;

namespace SFA.DAS.Support.Shared.Discovery
{
    public interface ISiteManifest
    {
        SupportServiceIdentity ServiceIdentity { get; set; }
        IEnumerable<SiteResource> Resources { get; }
        IEnumerable<SiteChallenge> Challenges { get; }
    }
}