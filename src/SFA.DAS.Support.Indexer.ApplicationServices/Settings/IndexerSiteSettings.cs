using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace SFA.DAS.Support.Indexer.ApplicationServices.Settings
{
    [ExcludeFromCodeCoverage]
    public class IndexerSiteSettings : IIndexerSiteSettings
    {
        [JsonRequired] public string BaseUrls { get; set; }
      
        [JsonRequired] public string DelayTimeInSeconds { get; set; }
    }
}