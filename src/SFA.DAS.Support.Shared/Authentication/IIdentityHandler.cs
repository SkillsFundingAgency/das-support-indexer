using System.Net.Http;
using System.Web;

namespace SFA.DAS.Support.Shared.Authentication
{
    public interface IIdentityHandler
    {
        string GetIdentity(HttpRequestBase request);

        void SetIdentity(HttpClient request, string identity);
    }
}