﻿using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    [ExcludeFromCodeCoverage]
    public class SiteResource
    {
        [JsonRequired] public SupportServiceResourceKey ResourceKey { get; set; }

        [JsonRequired] public string ResourceUrlFormat { get; set; }

        public string SearchItemsUrl { get; set; }
        public string ResourceTitle { get; set; }
        public string Challenge { get; set; }
        public SearchCategory SearchCategory { get; set; }
        public SupportServiceResourceKey? HeaderKey { get; set; }
    }
}