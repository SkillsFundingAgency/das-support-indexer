﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.Azure;
using SFA.DAS.Configuration;
using SFA.DAS.Configuration.AzureTableStorage;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Common.Infrastucture.Settings;
using SFA.DAS.Support.Indexer.ApplicationServices.Settings;
using SFA.DAS.Support.Shared.Authentication;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.SiteConnection;
using StructureMap.Configuration.DSL;

namespace SFA.DAS.Support.Indexer.Worker.DependencyResolution
{
    [ExcludeFromCodeCoverage]
    public class DefaultRegistry : Registry
    {
        private const string ServiceName = "SFA.DAS.Support.Portal.Indexer.Worker";
        private const string Version = "1.0";

        public DefaultRegistry()
        {
            For<IRequestContext>().Use<FakeRequestContext>();

            For<ILoggingPropertyFactory>().Use<LoggingPropertyFactory>();
            For<ILog>().Use(x => new NLogLogger(
                x.ParentType,
                x.GetInstance<IRequestContext>(),
                x.GetInstance<ILoggingPropertyFactory>().GetProperties())).AlwaysUnique();


            var configuration = GetConfiguration();
            For<IWebConfiguration>().Use(configuration);
            For<ISearchSettings>().Use(configuration.ElasticSearch);
            For<IIndexerSiteSettings>().Use(configuration.Site);
            For<ISiteConnectorSettings>().Use(configuration.SiteConnector);
            For<ServiceConfiguration>().Singleton().Use(new ServiceConfiguration
                {
                    new EmployerAccountSiteManifest(),
                    new EmployerUserSiteManifest()
                }
            );
            For<ICryptoSettings>().Use(configuration.Crypto);
            For<ICrypto>().Use<Crypto>();

        }

        private WebConfiguration GetConfiguration()
        {
            var environment = CloudConfigurationManager.GetSetting("EnvironmentName") ?? "LOCAL";

            var storageConnectionString =
                CloudConfigurationManager.GetSetting("ConfigurationStorageConnectionString") ??
                "UseDevelopmentStorage=true;";

            var configurationRepository = new AzureTableStorageConfigurationRepository(storageConnectionString);

            var configurationOptions = new ConfigurationOptions(ServiceName, environment, Version);

            var configurationService = new ConfigurationService(configurationRepository, configurationOptions);

            return configurationService.Get<WebConfiguration>();
        }
    }
}