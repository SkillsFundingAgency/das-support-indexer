﻿using System.Diagnostics.CodeAnalysis;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    [ExcludeFromCodeCoverage]
    public class SiteResource
    {
        public string ResourceKey { get; set; }
        public string ResourceUrlFormat { get; set; }
        public string SearchItemsUrl { get; set; }
        public string ResourceTitle { get; set; }
        public string Challenge { get; set; }
        public SearchCategory SearchCategory { get; set; }
    }
}