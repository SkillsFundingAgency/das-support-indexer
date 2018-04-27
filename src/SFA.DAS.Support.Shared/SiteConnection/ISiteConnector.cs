using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Shared.SiteConnection
{
    public interface ISiteConnector
    {
        string LastContent { get; set; }
        Exception LastException { get; set; }
        HttpStatusCode LastCode { get; set; }
        HttpStatusCodeDecision HttpStatusCodeDecision { get; set; }
        Task<string> Download(SupportServiceIdentity service, Uri url);
        Task<string> Download(Uri url);
        Task<T> Download<T>(Uri uri) where T : class;
        Task<T> Download<T>(string url) where T : class;
        Task<T> Upload<T>(Uri uri, IDictionary<string, string> formData) where T : class;
    }
}