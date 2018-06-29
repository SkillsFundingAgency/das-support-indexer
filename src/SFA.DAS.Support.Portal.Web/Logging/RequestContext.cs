using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Web;
using SFA.DAS.NLog.Logger;

namespace SFA.DAS.Support.Portal.Web.Logging
{
    [ExcludeFromCodeCoverage]
    public sealed class RequestContext : IRequestContext
    {
        [DebuggerStepThrough]
        public RequestContext(HttpContextBase context)
        {
            try
            {
                IpAddress = context?.Request?.UserHostAddress ?? IPAddress.Any.ToString();
                Url = context?.Request.RawUrl;
            }
            catch (HttpException)
            {
                // Happens on request that starts the application.
                IpAddress = string.Empty;
                Url = string.Empty;
            }
        }

        public string IpAddress { get; }

        public string Url { get; }
    }
}