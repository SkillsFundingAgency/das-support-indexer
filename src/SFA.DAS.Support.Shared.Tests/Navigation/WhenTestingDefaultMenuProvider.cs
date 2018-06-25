using System.Collections.Generic;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    public class WhenTestingDefaultMenuProvider
    {
        private MenuViewModel _unit = new MenuViewModel();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ItShouldHaveAListOfMenuItems()
        {
            Assert.IsEmpty(_unit.MenuItems);
        }


        [Test]
        public void ItShouldHaveNoActiveMenuKeysByDefault()
        {
            Assert.IsEmpty(_unit.SelectedMenuItemKeys);
        }

        [Test]
        public void ItShouldHAveMenuItemsWhenAdded()
        {
            _unit.MenuItems.Add(new MenuItem
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
            });

            _unit.MenuItems.Add(new MenuItem
            {
                Key = "Account",
                Text = "Accounts",
                NavigateUrl = "accounts/{accountId}",
                MenuItems = new List<MenuItem>
                {
                    new MenuItem{
                        Key = "Account.Organisations",
                        Text = "Organisations",
                        NavigateUrl = "accounts/{acountId}/organisations"
                    },
                    new MenuItem{
                        Key = "Account.Finance",
                        Text = "Finance",
                        NavigateUrl = "accounts/{accountId}/finance",
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem{
                                Key = "Account.Finance.PAYE",
                                Text = "PAYE",
                                NavigateUrl = "accounts/{acountId}/finance/paye"
                            },
                            new MenuItem{
                                Key = "Account.Finance.Transactions",
                                Text = "Transactions",
                                NavigateUrl = "accounts/{accountId}/finance/transactions"
                            }
                        }
                    },
                    new MenuItem{
                        Key = "Account.Commitments",
                        Text = "Commitments",
                        NavigateUrl = "commitments/accounts/{accountId}",
                        MenuItems = new List<MenuItem>
                        {
                            new MenuItem{
                                Key = "Account.Commitments.Apprentices",
                                Text = "Apprentices",
                                NavigateUrl = "commitments/accounts/{accountId}/apprentices"
                            },
                            new MenuItem{
                                Key = "Account.Commitments.Payments",
                                Text = "Payments",
                                NavigateUrl = "commitments/accounts/{accountId}/payments"
                            }
                        }
                    }
                }
            });

            Assert.IsNotEmpty(_unit.MenuItems);

        }


    }
}