using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace SFA.DAS.Support.Shared.SiteConnection
{
    [ExcludeFromCodeCoverage]
    public class SiteSettings : ISiteSettings
    {
        [JsonRequired] public string BaseUrls { get; set; }
    }
}