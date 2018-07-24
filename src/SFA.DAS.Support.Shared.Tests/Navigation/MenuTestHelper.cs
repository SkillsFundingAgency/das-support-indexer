using System.Collections.Generic;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    public static class MenuTestHelper
    {
        public static MenuRoot GetEmployerAccountMenu()
        {
            return new MenuRoot
            {
                Perspective = SupportMenuPerspectives.EmployerAccount,
                MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Key = "Account.Organisations",
                        Text = "Organisations",
                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{accountId}}/organisations"
                    },
                   new MenuItem
                    {
                        Key = "Account.Finance",
                        Text = "Finance",
                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{accountId}}/finance",
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Key = "Account.Finance.PAYE",
                                Text = "PAYE",
                                NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{accountId}}/finance/paye",
                                MenuItems = new List<MenuItem>()
                                {
                                    new MenuItem
                                    {
                                        Key = "Account.Finance.PAYE.Submissions",
                                        Text = "Submissions",
                                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{accountId}}/finance/paye/{{payeSchemeId}}"
                                    },
                                }
                            },
                            new MenuItem
                            {
                                Key = "Account.Finance.Transactions",
                                Text = "Transactions",
                                NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{accountId}}/finance/transactions"
                            }
                        }
                    },
                    new MenuItem
                    {
                        Key = "Account.Teams",
                        Text = "Team members",
                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{accountId}}/teams"
                    },

                  
                }
            };
        }

        public static MenuRoot GetEmployerUserMenu()
        {
            return new MenuRoot
            {
                Perspective = SupportMenuPerspectives.EmployerUser,
                MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Key = "User.Details",
                        Text = "User",
                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerUser.ToRoutePrefix()}/users/{{userId}}"
                    },
                    new MenuItem
                    {
                        Key = "User.Accounts",
                        Text = "Accounts",
                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerUser.ToRoutePrefix()}/users/{{userId}}/accounts"
                    }
                }
            };
        }

        public static List<MenuRoot> FullMenu()
        {
           
            return new List<MenuRoot>()
            {
                GetEmployerUserMenu(), GetEmployerAccountMenu()
               
            };
        }
    }
}