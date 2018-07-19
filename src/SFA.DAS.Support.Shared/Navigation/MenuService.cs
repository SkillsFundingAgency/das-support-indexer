using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.DAS.Support.Shared.Navigation
{
    public class MenuService : IMenuService
    {
        private readonly IMenuClient _menuClient;
        private readonly Uri _menuSource;
        private readonly IMenuTemplateDatasource _menuTemplateDatasource;
        private List<MenuRoot> _menuRoots = new List<MenuRoot>();

        public MenuService(IMenuTemplateDatasource menuTemplateDatasource,
            IMenuClient menuClient, Uri menuSource)
        {
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