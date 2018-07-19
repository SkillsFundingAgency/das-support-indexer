using System;
using System.Linq;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class RouteToServiceMapper : IRouteToServiceMapper
    {
        public SupportServiceIdentity Service(string path)
        {
            var result = SupportServiceIdentity.SupportPortal;
            if (string.IsNullOrWhiteSpace(path)) return result;

            var routePrefix = path.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(routePrefix)) return result;

            foreach (SupportServiceIdentity value in Enum.GetValues(typeof(SupportServiceIdentity)))
            {
                var prefix = value.ToRoutePrefix();
                if (prefix != routePrefix) continue;
                result = value;
                break;
            }

            return result;
        }
    }
}