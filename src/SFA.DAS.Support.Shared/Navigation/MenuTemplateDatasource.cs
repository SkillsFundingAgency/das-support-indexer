using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace SFA.DAS.Support.Shared.Navigation
{

    /// <summary>
    /// Obtains the available menu templates 
    /// </summary>
    public class MenuTemplateDatasource : IMenuTemplateDatasource
    {

        private readonly FileInfo _fileDataSource = null;
        private readonly string _embeddedDataSource = null;

        public MenuTemplateDatasource(FileInfo fileMenuTempalteDataSource)
        {
            _fileDataSource = fileMenuTempalteDataSource;

            var embeddedPath = typeof(MenuTemplateDatasource).Namespace;
            _embeddedDataSource = $"{embeddedPath}.MenuTemplates.json";

        }

        public List<MenuRoot> Provide()
        {
            var menuItems = SourceFromFile();
            if (menuItems.Any()) return menuItems;

            menuItems = SourceFromEmbeddedResource();
            if (menuItems.Any()) return menuItems;

            menuItems = SourceFromDefault();
            return menuItems;
        }

        private List<MenuRoot> SourceFromDefault()
        {
            var menuItems = new List<MenuRoot>
            {
                new MenuRoot
                {
                    Perspective = SupportMenuPerspectives.EmployerUser,
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
                new MenuRoot
                {
                    Perspective = SupportMenuPerspectives.EmployerAccount,
                    MenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Key = "Account.Organisations",
                            Text = "Organisations",
                            NavigateUrl = "accounts/{accountId}/organisations"
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
                                    NavigateUrl = "accounts/{accountId}/finance/paye"
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
#if DEBUG
            var path = new FileInfo(typeof(MenuRoot).Assembly.Location).Directory.FullName;
            File.WriteAllText($@"{path}\MenuTemplates.json", JsonConvert.SerializeObject(menuItems));
#endif
            return menuItems;
        }

        private List<MenuRoot> SourceFromEmbeddedResource()
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            Stream resourceStream = thisAssembly.GetManifestResourceStream(_embeddedDataSource);
            if (resourceStream == null) return new List<MenuRoot>();
            BinaryReader br = new BinaryReader(resourceStream);
            byte[] ba = new byte[resourceStream.Length];
            resourceStream.Read(ba, 0, ba.Length);
            br.Close();
            var data = System.Text.Encoding.UTF8.GetString(ba);
            try
            {
                return JsonConvert.DeserializeObject<List<MenuRoot>>(data);
            }
            catch (Exception e)
            {
                return new List<MenuRoot>();
            }
        }

        private List<MenuRoot> SourceFromFile()
        {
            if (_fileDataSource == null || !_fileDataSource.Exists) return new List<MenuRoot>();
            try
            {
                return JsonConvert.DeserializeObject<List<MenuRoot>>(File.ReadAllText(_fileDataSource.FullName));
            }
            catch
            {
                // ignore
            }
            return new List<MenuRoot>();
        }
    }
}