using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace SFA.DAS.Support.Shared.Authentication
{
    public class ClaimsIdentityProvider : IIdentityProvider
    {
        private const string EmailClaimTypeName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        public string DefaultIdentity { get; set; } = "anonymous@digitaleducation.gov.uk";

        public string ObtainIdentity()
        {
            if (Thread.CurrentPrincipal.Identity is ClaimsIdentity claimsIdentity)
                return claimsIdentity.Claims.FirstOrDefault(i => i.Type == EmailClaimTypeName)?.Value ??
                       DefaultIdentity;

            return DefaultIdentity;
        }
    }
}