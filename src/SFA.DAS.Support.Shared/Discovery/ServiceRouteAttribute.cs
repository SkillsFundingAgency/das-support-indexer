using System;

namespace SFA.DAS.Support.Shared.Discovery
{
    public class ServiceRouteAttribute : Attribute
    {
        public string RoutePrefix {  get; private set; }
        public ServiceRouteAttribute(string routePrefix)
        {
            RoutePrefix = routePrefix;
        }
    }
}