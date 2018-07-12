using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using SFA.DAS.NLog.Logger;

namespace SFA.DAS.Support.Shared.Navigation
{
    /// <summary>
    ///     Obtains the available menu templates
    /// </summary>
    public class MenuTemplateDatasource : IMenuTemplateDatasource
    {
        private readonly ILog _logger;
        private readonly string _embeddedDataSource;

        private readonly FileInfo _fileDataSource;
        private readonly List<MenuRoot> _emptyList = new List<MenuRoot>();


        public MenuTemplateDatasource(FileInfo fileMenuTempalteDataSource, ILog logger)
        {
            _fileDataSource = fileMenuTempalteDataSource;
            _logger = logger;

            var embeddedPath = typeof(MenuTemplateDatasource).Namespace;
            _embeddedDataSource = $"{embeddedPath}.MenuTemplates.json";

            _logger.Trace($"{nameof(MenuTemplateDatasource)}.ctor File: {_fileDataSource.FullName}, Embedded: {_embeddedDataSource}");

        }

        public MenuTemplateDatasource(string menuTemplateFilePath, ILog logger)
        {
            _logger = logger;
            var path = HttpContext.Current?.Server?.MapPath(menuTemplateFilePath) ??
                       $@"{menuTemplateFilePath}";

            _fileDataSource = new FileInfo($"{path}/MenuTemplates.json".Replace(@"//", @"/"));

            var embeddedPath = typeof(MenuTemplateDatasource).Namespace;
            _embeddedDataSource = $"{embeddedPath}.MenuTemplates.json";

            _logger.Trace($"{nameof(MenuTemplateDatasource)}.ctor File: {_fileDataSource.FullName}, Embedded: {_embeddedDataSource}");


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
            _logger.Info($"Obtaining menu templates from source code.");
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
                            NavigateUrl = "views/employers/users/{userId}",
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
                            NavigateUrl = "views/employers/accounts/{accountId}/organisations",
                            Ordinal = 0
                        },
                        new MenuItem
                        {
                            Key = "Account.Finance",
                            Text = "Finance",
                            NavigateUrl = "views/employers/accounts/{accountId}/finance/payeschemes",
                            Ordinal = 1,
                            MenuItems = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Key = "Account.Finance.PAYE",
                                    Text = "PAYE schemes",
                                    NavigateUrl = "views/employers/accounts/{accountId}/finance/payeschemes",
                                    Ordinal = 0,
                                    MenuItems = new List<MenuItem>()
                                    {
                                        new MenuItem()
                                        {
                                            Key = "Account.Finance.PAYE.Detail",
                                            Text = "",
                                            Ordinal = 0,
                                            NavigateUrl = "views/employers/accounts/{accountId}/finance/payeschemes/{schemeId}",
                                            Roles = new string[]{},
                                            MenuItems = new List<MenuItem>(){}
                                        }
                                    }
                                },
                                new MenuItem
                                {
                                    Key = "Account.Finance.Transactions",
                                    Text = "Transactions",
                                    NavigateUrl = "views/employers/accounts/{accountId}/finance/transactions",
                                    Roles = new[] {"Tier2"},
                                    Ordinal = 1
                                }
                            }
                        },
                        new MenuItem
                        {
                            Key = "Account.Teams",
                            Text = "Teams",
                            NavigateUrl = "views/employers/accounts/{accountId}/teams",
                            Ordinal = 2,
                            MenuItems = new List<MenuItem>(){}

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
                _logger.Info($"Obtaining menu templates from embedded resource {_embeddedDataSource}");
                return JsonConvert.DeserializeObject<List<MenuRoot>>(data);
            }
            catch (Exception e)
            {
                _logger.Error(e, $"Exception occured obtaining menu templates from embedded resource {_embeddedDataSource}");

                return new List<MenuRoot>();
            }
        }

        private List<MenuRoot> SourceFromFile()
        {
            if (_fileDataSource == null)
            {
                _logger.Info($"Not Obtaining menu templates from local file as file info is not provided.");
                return _emptyList;
            }
            if (!_fileDataSource.Exists)
            {
                _logger.Info($"Not Obtaining menu templates from local file {_fileDataSource.FullName} as it was not found.");
                return _emptyList;
            }
            try
            {
                _logger.Info($"Obtaining menu templates from local file {_fileDataSource.FullName}.");
                return JsonConvert.DeserializeObject<List<MenuRoot>>(File.ReadAllText(_fileDataSource.FullName));
            }
            catch (Exception e)
            {
                // ignore
                _logger.Error(e, $"Exception occured obtaining menu templates from local file {_fileDataSource.FullName}.");

            }

            return _emptyList;
        }
    }
}