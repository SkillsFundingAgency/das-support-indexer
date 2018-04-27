using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    [ExcludeFromCodeCoverage]
    public class SiteResource
    {
        [JsonRequired] public SupportServiceIdentity ServiceIdentity { get; set; }
        //[JsonRequired] public SupportServiceResourceKey ResourceKey { get; set; }


        public string SearchItemsUrl { get; set; }
        public string SearchTotalItemsUrl { get; set; }
        public SearchCategory SearchCategory { get; set; }
       
    }
}