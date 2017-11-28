using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using SFA.DAS.Portal.ApplicationServices.Services;
using SFA.DAS.Portal.Core.Services;

namespace SFA.DAS.Portal.Infrastructure.DependencyResolution
{
    public class LoggingPropertyFactory : ILoggingPropertyFactory
    {
        private readonly IRoleSettings _roleSettings;
        private readonly IGetCurrentIdentity _getCurrentIdentity;

        public LoggingPropertyFactory(IRoleSettings roleSettings, IGetCurrentIdentity getCurrentIdentity)
        {
            _roleSettings = roleSettings;
            _getCurrentIdentity = getCurrentIdentity;
        }

        public IDictionary<string, object> GetProperties()
        {
            var properties = new Dictionary<string, object>();
            try
            {
                properties.Add("Version", GetVersion());
                properties.Add("RequestCtx.User.Email", GetEmail());
                properties.Add("RequestCtx.User.SupportTier", GetSupportTier());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
            
            return properties;
        }

        private string GetSupportTier()
        {
            ClaimsIdentity identity;
            try
            {
                identity = _getCurrentIdentity.GetCurrentIdentity();
            }
            catch (Exception e)
            {
                return "Anonymous user";
            }

            if (identity == null)
            {
                return "Identity is null";
            }

            if (identity.Claims == null)
            {
                return "Identity claims are null";
            }

            var roles = new List<Claim>();

            if (identity.Claims.Any() && identity.Claims.Count(x => x.Type == ClaimTypes.Role) > 0)
            {
                roles = identity.Claims.Where(x => x.Type == ClaimTypes.Role).ToList();
            }
            else
            {
                return "No user role available";
            }

            if (roles.Any(x => x.Value == _roleSettings.T2Role))
            {
                return "T2User";
            }

            if (roles.Any(x => x.Value == _roleSettings.ConsoleUserRole))
            {
                return "ConsoleUser";
            }

            return string.Empty;
        }

        private string GetEmail()
        {
            ClaimsIdentity identity;
            try
            {
                identity = _getCurrentIdentity.GetCurrentIdentity();
            }
            catch (Exception e)
            {
                return "Anonymous user";
            }


            if (identity == null)
            {
                return "Identity is null";
            }

            if (identity.Claims == null)
            {
                return "Identity claims are null";
            }

            if (identity.Claims.Any() && identity.Claims.Count(x => x.Type == ClaimTypes.Email) > 0)
            {
                return identity.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
            }
            
            return "No user email available";
            
        }

        private string GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fileVersionInfo.ProductVersion;
        }
    }
}