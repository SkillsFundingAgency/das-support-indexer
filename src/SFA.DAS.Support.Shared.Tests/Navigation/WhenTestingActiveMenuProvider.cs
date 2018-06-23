using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;


namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    public class WhenTestingActiveMenuProvider
    {
        private readonly MenuProvider _unit = new MenuProvider();

        [SetUp]
        public void Setup()
        {
            // ARRANGE
            var items = new List<MenuItem>
            {
                new MenuItem
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
                },
                new MenuItem
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
                                    NavigateUrl = "accounts/{accountId}/finance/transactions",
                                    Roles = new[] {"Tier2"}
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
                }
            };
            // ACT
            _unit.SetMenu(items, "Account.Finance.PAYE");
        }
        [Test]
        public void ItShouldHaveAListOfMenuItems()
        {
            Assert.IsNotEmpty(_unit.MenuItems);
            Assert.AreEqual(1, _unit.MenuItems.Count);
        }
        [Test]
        public void ItShouldHaveActiveMenuKeys()
        {
            Assert.IsNotEmpty(_unit.SelectedMenuItemKeys);
        }
        [Test]
        public void ItRootSelectedMenuShouldBeSetCorrectly()
        {
            Assert.AreEqual(_unit.SelectedMenuItemKeys.FirstOrDefault(), "Account");
        }
        [Test]
        public void ItActualSelectedMenuShouldBeSetCorrectly()
        {
            Assert.AreEqual(_unit.SelectedMenuItemKeys.LastOrDefault(), "Account.Finance.PAYE");
        }
    }
}
