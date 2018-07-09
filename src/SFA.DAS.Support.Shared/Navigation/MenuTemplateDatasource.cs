using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace SFA.DAS.Support.Shared.Navigation
{
    /// <summary>
    ///     Obtains the available menu templates
    /// </summary>
    public class MenuTemplateDatasource : IMenuTemplateDatasource
    {
        private readonly string _embeddedDataSource;

        private readonly FileInfo _fileDataSource;

        public MenuTemplateDatasource(FileInfo fileMenuTempalteDataSource)
        {
            _fileDataSource = fileMenuTempalteDataSource;

            var embeddedPath = typeof(MenuTemplateDatasource).Namespace;
            _embeddedDataSource = $"{embeddedPath}.MenuTemplates.json";
        }

        public MenuTemplateDatasource(string fileMenuTempalteDataSource)
        {
            var path = HttpContext.Current?.Server?.MapPath(fileMenuTempalteDataSource) ??
                       $@"c:\{fileMenuTempalteDataSource}";
            _fileDataSource = new FileInfo(path);

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
                            Text = "Overview",
                            NavigateUrl = "users/{userId}",
                            Ordinal = 0
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
                            NavigateUrl = "accounts/{accountId}/organisations",
                            Ordinal = 0
                        },
                        new MenuItem
                        {
                            Key = "Account.Finance",
                            Text = "Finance",
                            NavigateUrl = "accounts/{accountId}/finance",
                            Ordinal = 1,
                            MenuItems = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Key = "Account.Finance.PAYE",
                                    Text = "PAYE",
                                    NavigateUrl = "accounts/{accountId}/finance/paye",
                                    Ordinal = 0
                                },
                                new MenuItem
                                {
                                    Key = "Account.Finance.Transactions",
                                    Text = "Transactions",
                                    NavigateUrl = "accounts/{accountId}/finance/transactions",
                                    Roles = new[] {"Tier2"},
                                    Ordinal = 1
                                }
                            }
                        },
                        new MenuItem
                        {
                            Key = "Account.Commitments",
                            Text = "Commitments",
                            NavigateUrl = "commitments/accounts/{accountId}",
                            Ordinal = 0,
                            MenuItems = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Key = "Account.Commitments.Apprentices",
                                    Text = "Apprentices",
                                    NavigateUrl = "commitments/accounts/{accountId}/apprentices",
                                    Ordinal = 0
                                },
                                new MenuItem
                                {
                                    Key = "Account.Commitments.Payments",
                                    Text = "Payments",
                                    NavigateUrl = "commitments/accounts/{accountId}/payments",
                                    Ordinal = 1
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
            var thisAssembly = Assembly.GetExecutingAssembly();
            var resourceStream = thisAssembly.GetManifestResourceStream(_embeddedDataSource);
            if (resourceStream == null) return new List<MenuRoot>();
            var br = new BinaryReader(resourceStream);
            var ba = new byte[resourceStream.Length];
            resourceStream.Read(ba, 0, ba.Length);
            br.Close();
            var data = Encoding.UTF8.GetString(ba);
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