using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class MenuService : IMenuService
    {
        private readonly IMenuClient _menuClient;
        private readonly Uri _menuSource;
        private readonly IMenuTemplateDatasource _menuTemplateDatasource;
        private DirectoryInfo _directoryInfo;
        private List<MenuRoot> _menuRoots = new List<MenuRoot>();

        public MenuService(DirectoryInfo directoryInfo, IMenuTemplateDatasource menuTemplateDatasource,
            IMenuClient menuClient, Uri menuSource)
        {
            _directoryInfo = directoryInfo;
            _menuTemplateDatasource = menuTemplateDatasource;
            _menuClient = menuClient;
            _menuSource = menuSource;
        }

        public async Task<List<MenuRoot>> GetMenu(SupportMenuPerspectives perspectives)
        {
            if (_menuRoots.Any()) return FromCache(perspectives);
            _menuRoots = _menuTemplateDatasource.Provide();
            if (_menuRoots.Any()) return FromCache(perspectives);
            _menuRoots = await _menuClient.GetMenuForPerspective(SupportMenuPerspectives.All, _menuSource);
            if (_menuRoots.Any()) return FromCache(perspectives);
            return new List<MenuRoot>();
        }

        private List<MenuRoot> FromCache(SupportMenuPerspectives perspectives)
        {
            return _menuRoots.Where(x => x.Perspective.HasFlag(perspectives)).ToList();
        }
    }
}