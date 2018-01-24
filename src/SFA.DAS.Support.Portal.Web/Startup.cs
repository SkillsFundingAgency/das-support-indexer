﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using Owin;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Shared.Authentication;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Portal.Web
{
    [ExcludeFromCodeCoverage]
    public partial class Startup
    {
        public static readonly List<SiteManifest> SiteManifests = new List<SiteManifest>();
        public static readonly Dictionary<string, SiteResource> SiteResources = new Dictionary<string, SiteResource>();

        public static readonly Dictionary<string, SiteChallenge> SiteChallenges =
            new Dictionary<string, SiteChallenge>();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledExceptionEventHandler;
        }

        private static void CurrentDomain_UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception) e.ExceptionObject;
            var logger = DependencyResolver.Current.GetService<ILog>();

            logger.Error(ex, "App_Error");
        }
    }
}