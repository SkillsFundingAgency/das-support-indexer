using System.Web;

namespace SFA.DAS.Support.Shared.Authentication
{
    /// <summary>
    /// Sets or gets the Identity (User) of the request
    /// </summary>
    public class RequestHeaderIdentityHandler : IIdentityHandler
    {
        public const string XResourceRequestIdentity = "X-ResourceRequestIdentity";
        private const string DefaultIdentity = "anonymous@digitaleductation.gov.uk";
        private readonly IIdentityHash _identityHash;
        public RequestHeaderIdentityHandler(IIdentityHash identityHash)
        {
            _identityHash = identityHash;
        }
        public string GetIdentity(HttpRequestBase request)
        {
            return _identityHash.Decrypt(request?.Headers[XResourceRequestIdentity] ?? DefaultIdentity);
        }

        public void SetIdentity(HttpRequestBase request, string identity)
        {
            request.Headers.Add(XResourceRequestIdentity, _identityHash.Encrypt(identity));
        }
    }
}