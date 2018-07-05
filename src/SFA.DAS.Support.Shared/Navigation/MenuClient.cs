using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SFA.DAS.Support.Shared.SiteConnection;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class MenuClient : IMenuClient
    {
        private readonly ISiteConnector _siteConnector;

        public MenuClient(ISiteConnector siteConnector)
        {
            _siteConnector = siteConnector;
        }

        public async Task<List<MenuRoot>> GetMenuForPerspective(SupportMenuPerspectives perspectives, Uri source)
        {
            var menuTemplates = await _siteConnector.Download<List<MenuRoot>>(source);
            if (_siteConnector.LastCode == HttpStatusCode.OK) return menuTemplates;

            return new List<MenuRoot>();
        }
    }
}