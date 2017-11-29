﻿using System.Web;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using SFA.DAS.Support.Portal.Core.Services;
using SFA.DAS.Support.Portal.Web.Logging;
using SFA.DAS.Support.Portal.Web.Services;
using SFA.DAS.Support.Portal.Web.Settings;
using StructureMap.Configuration.DSL;

namespace SFA.DAS.Support.Portal.Web.DependencyResolution
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<IRequestContext>().Use(x => new RequestContext(new HttpContextWrapper(HttpContext.Current)));
            For<IMappingService>().Use<MappingService>();
            For<ICheckPermissions>().Use<PermissionCookieProvider>();
            For<IGrantPermissions>().Use<PermissionCookieProvider>();
            For<IChallengeSettings>().Use<ChallengeSettings>();
            For<IRoleSettings>().Use<RoleSettings>();
            For<IAuthSettings>().Use<AuthSettings>();

            For<IGetCurrentIdentity>().Use<IdentityService>();
        }
    }
}