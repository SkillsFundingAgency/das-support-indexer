using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SFA.DAS.Support.Shared.Navigation
{
    public interface INavigationService
    {
        List<MenuRoot> GetMenu(SupportMenuPerspectives employerAccount);
    }

    public class NavigationService : INavigationService
    {
        private DirectoryInfo _directoryInfo;
        private readonly IMenuTemplateDatasource _menuTemplateDatasource;
        private readonly IMenuClient _menuClient;
        private List<MenuRoot> _menuRoots;

        public NavigationService(DirectoryInfo directoryInfo, IMenuTemplateDatasource menuTemplateDatasource, IMenuClient menuClient)
        {
            _directoryInfo = directoryInfo;
            _menuTemplateDatasource = menuTemplateDatasource;
            _menuClient = menuClient;
        }

        public List<MenuRoot> GetMenu(SupportMenuPerspectives perspectives)
        {
            if (_menuRoots.Any())
            {
                return FromCache(perspectives);
            }
            _menuRoots = _menuTemplateDatasource.Provide();
            if (_menuRoots.Any())
            {
                return FromCache(perspectives);
            }
            _menuRoots = _menuClient.GetMenuForPerspective(SupportMenuPerspectives.All).ToList();
            if (_menuRoots.Any())
            {
                return FromCache(perspectives);
            }
            return new List<MenuRoot>();
        }

        private List<MenuRoot> FromCache(SupportMenuPerspectives perspectives)
        {
           return _menuRoots.Where(x => x.Perspective.HasFlag(perspectives)).ToList();
        }
    }
}
