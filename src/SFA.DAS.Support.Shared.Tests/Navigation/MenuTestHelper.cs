using System.Collections.Generic;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    public static class MenuTestHelper
    {
        public static MenuItem GetEmployerAccountMenu()
        {
            return new MenuItem
            {
                Key = "Account",
                Text = "Accounts",
                NavigateUrl = "accounts/{accountId}",
                MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Key = "Account.Organisations",
                        Text = "Organisations",
                        NavigateUrl = "accounts/{acountId}/organisations"
                    },
                    new MenuItem
                    {
                        Key = "Account.Finance",
                        Text = "Finance",
                        NavigateUrl = "accounts/{accountId}/finance",
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Key = "Account.Finance.PAYE",
                                Text = "PAYE",
                                NavigateUrl = "accounts/{acountId}/finance/paye"
                            },
                            new MenuItem
                            {
                                Key = "Account.Finance.Transactions",
                                Text = "Transactions",
                                NavigateUrl = "accounts/{accountId}/finance/transactions"
                            }
                        }
                    },
                    new MenuItem
                    {
                        Key = "Account.Commitments",
                        Text = "Commitments",
                        NavigateUrl = "commitments/accounts/{accountId}",
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem
                            {
                                Key = "Account.Commitments.Apprentices",
                                Text = "Apprentices",
                                NavigateUrl = "commitments/accounts/{accountId}/apprentices"
                            },
                            new MenuItem
                            {
                                Key = "Account.Commitments.Payments",
                                Text = "Payments",
                                NavigateUrl = "commitments/accounts/{accountId}/payments"
                            }
                        }
                    }
                }
            };
        }

        public static MenuItem GetEmployerUserMenu()
        {
            return new MenuItem
            {
                Key = "User",
                Text = "User",
                NavigateUrl = "users/{userId}",
                MenuItems = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Key = "User.Details",
                        Text = "User",
                        NavigateUrl = "users/{userId}"
                    },
                    new MenuItem
                    {
                        Key = "User.Accounts",
                        Text = "Accounts",
                        NavigateUrl = "users/{userId}/accounts"
                    }
                }
            };
        }
    }
}