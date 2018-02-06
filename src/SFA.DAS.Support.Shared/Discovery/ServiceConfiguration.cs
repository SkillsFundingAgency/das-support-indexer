﻿using System.Collections.Generic;
using SFA.DAS.Support.Shared.Authentication;
using SFA.DAS.Support.Shared.SearchIndexModel;

namespace SFA.DAS.Support.Shared.Discovery
{
    public class ServiceConfiguration
    {
        public SupportServiceManifests ServiceManifests { get; set; }

        public ServiceConfiguration()
        {
            ServiceManifests = new SupportServiceManifests
            {
                {
                    SupportServiceIdentity.SupportEmployerUser, new SiteManifest
                    {
                        ServiceIdentity = SupportServiceIdentity.SupportEmployerUser,
                        Resources = new[]
                        {
                            new SiteResource
                            {
                                ResourceKey = SupportServiceResourceKey.EmployerUser,
                                ResourceTitle = "Overview",

                                ResourceUrlFormat = "/user/index/{0}",
                                SearchItemsUrl = "/api/search/users",
                                SearchCategory = SearchCategory.User,
                                HeaderKey = SupportServiceResourceKey.EmployerUserHeader
                            },
                            new SiteResource
                            {
                                ResourceKey = SupportServiceResourceKey.EmployerUserHeader,
                                ResourceUrlFormat = "/user/header/{0}"
                            },
                            new SiteResource
                            {
                                ResourceKey = SupportServiceResourceKey.EmployerUserAccountTeam,
                                ResourceUrlFormat = "/account/team/{0}",
                                ResourceTitle = "Team members",
                                HeaderKey = SupportServiceResourceKey.EmployerUserHeader
                            }
                        }
                    }
                },
                {
                    SupportServiceIdentity.SupportEmployerAccount, new SiteManifest
                    {
                        ServiceIdentity = SupportServiceIdentity.SupportEmployerAccount,
                        Resources = new[]
                        {
                            new SiteResource
                            {
                                ResourceKey = SupportServiceResourceKey.EmployerAccount,
                                ResourceUrlFormat = "/account/{0}",
                                ResourceTitle = "Organisations",
                                SearchItemsUrl = "/api/search/organisations",
                                SearchCategory = SearchCategory.Account,
                                HeaderKey = SupportServiceResourceKey.EmployerAccountHeader
                            },
                            new SiteResource
                            {
                                ResourceKey = SupportServiceResourceKey.EmployerAccountHeader,
                                ResourceUrlFormat = "/account/header/{0}"
                            },
                            new SiteResource
                            {
                                ResourceKey = SupportServiceResourceKey.EmployerAccountFinance,
                                ResourceUrlFormat = "/account/finance/{0}",
                                ResourceTitle = "Finance",
                                Challenge = SupportServiceResourceKey.EmployerAccountFinanceChallenge,
                                HeaderKey = SupportServiceResourceKey.EmployerAccountHeader
                            }
                        },
                        Challenges = new List<SiteChallenge>
                        {
                            new SiteChallenge
                            {
                                ChallengeKey = SupportServiceResourceKey.EmployerAccountFinanceChallenge,
                                ChallengeUrlFormat = "/challenge/{0}"
                            }
                        }
                    }
                }
            };
        }
    }
}