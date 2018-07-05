using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Support.Shared.Navigation
{
    /// <summary>
    ///     Serves the menu templates for a specific support journey perspective
    /// </summary>
    public class MenuTemplateHandler : IMenuTemplateHandler
    {
        private readonly IMenuTemplateDatasource _provider;

        public MenuTemplateHandler(IMenuTemplateDatasource provider)
        {
            _provider = provider;
        }

        public IEnumerable<MenuRoot> GetMenuForPerspective(SupportMenuPerspectives perspective)
        {
            var menuRoots = _provider.Provide()
                .Where(x => x.Perspective ==
                            (perspective == SupportMenuPerspectives.All ? x.Perspective : perspective));
            return menuRoots;
        }
    }
}