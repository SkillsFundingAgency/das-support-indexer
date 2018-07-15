using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace SFA.DAS.Support.Shared.Authentication
{
    [ExcludeFromCodeCoverage]
    public class CryptoSettings : ICryptoSettings
    {
        [JsonRequired] public string Salt { get; set; }

        [JsonRequired] public string Secret { get; set; }
    }
}