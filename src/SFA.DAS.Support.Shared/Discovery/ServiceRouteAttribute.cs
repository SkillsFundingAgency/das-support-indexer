using System;

namespace SFA.DAS.Support.Shared.Discovery
{
    public class ServiceRouteAttribute : Attribute
    {
        public ServiceRouteAttribute(string routePrefix)
        {
            RoutePrefix = routePrefix;
        }

        public string RoutePrefix { get; }
    }
}