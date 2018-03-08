using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using MediatR;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace SFA.DAS.Support.Portal.ApplicationServices.DependencyResolution
{
    [ExcludeFromCodeCoverage]
    public sealed class ApplicationServicesRegistry : Registry
    {
        public ApplicationServicesRegistry()
        {
            Scan(
                scan =>
                {
                    scan.AssemblyContainingType<ApplicationServicesRegistry>();
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf(typeof(IRequestHandler<,>));
                    scan.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                });
            For<ICrypto>().Use<Crypto>();
            For<IChallengeService>().Use<ChallengeService>();
            For<IDatetimeService>().Use<DatetimeService>();
            For<IManifestRepository>().Singleton().Use<ManifestRepository>();

            For<Dictionary<string, UserProfile>>().Singleton().Use(new Dictionary<string, UserProfile>());
            For<IKeyedItemRepository<string,UserProfile>>().Use<UserProfileRepository>();
            For<IUserProfileService>().Use(x=> new UserProfileService(x.GetInstance<IKeyedItemRepository<string, UserProfile>>(), DateTimeOffset.MinValue);
            

        }
    }
}