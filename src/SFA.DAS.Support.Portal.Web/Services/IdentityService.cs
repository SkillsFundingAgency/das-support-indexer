﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using System.Web;
using SFA.DAS.Support.Portal.ApplicationServices.Services;

namespace SFA.DAS.Support.Portal.Web.Services
{
    [ExcludeFromCodeCoverage]
    public class IdentityService : IGetCurrentIdentity
    {
        public ClaimsIdentity GetCurrentIdentity()
        {
            return (ClaimsIdentity)HttpContext.Current.User?.Identity ?? new ClaimsIdentity(new List<Claim>());
        }
    }
}