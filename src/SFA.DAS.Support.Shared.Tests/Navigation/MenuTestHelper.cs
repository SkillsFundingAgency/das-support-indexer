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
                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{acountId}}/organisations"
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
                                NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{acountId}}/finance/paye",
                                MenuItems = new List<MenuItem>()
                                {
                                    new MenuItem
                                    {
                                        Key = "Account.Finance.PAYE.Submissions",
                                        Text = "Submissions",
                                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{acountId}}/finance/paye/{{payeSchemeId}}"
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
                        Text = "Teams",
                        NavigateUrl = $"views/{SupportServiceIdentity.SupportEmployerAccount.ToRoutePrefix()}/accounts/{{acountId}}/teams"
                    },

                    //new MenuItem
                    //{
                    //    Key = "Account.Commitments",
                    //    Text = "Commitments",
                    //    NavigateUrl = $"{SupportServiceIdentity.SupportCommitments.ToRoutePrefix()}/accounts/{{accountId}}",
                    //    MenuItems = new List<MenuItem>
                    //    {
                    //        new MenuItem
                    //        {
                    //            Key = "Account.Commitments.Apprentices",
                    //            Text = "Apprentices",
                    //            NavigateUrl = $"views/{SupportServiceIdentity.SupportCommitments.ToRoutePrefix()}/accounts/{{accountId}}/apprentices"
                    //        },
                    //        new MenuItem
                    //        {
                    //            Key = "Account.Commitments.Payments",
                    //            Text = "Payments",
                    //            NavigateUrl = $"views/{SupportServiceIdentity.SupportCommitments.ToRoutePrefix()}/accounts/{{accountId}}/payments"
                    //        }
                    //    }
                    //}
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