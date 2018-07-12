using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SFA.DAS.Support.Shared.Navigation
{
    public abstract class BaseController : Controller
    {
        public const string ResourceRequestHeader = "X-ResourceRequest";
        protected readonly IMenuService MenuService;
        protected readonly IMenuTemplateTransformer MenuTemplateTransformer;
        protected static readonly MenuRoot EmptyMenu = new MenuRoot() { MenuItems = new List<MenuItem>(), Perspective = SupportMenuPerspectives.None };
        protected MenuRoot RootMenu { get; set; } = EmptyMenu;
        protected Dictionary<string, string> MenuTransformationIdentifiers { get; set; } = new Dictionary<string, string>();
        protected SupportMenuPerspectives MenuPerspective { get; set; } = SupportMenuPerspectives.None;
        protected string MenuSelection { get; set; } = null;

        private readonly MenuViewModel _menuViewModel = new MenuViewModel() { MenuOrientation = MenuOrientations.Vertical };

        protected BaseController(IMenuService menuService, IMenuTemplateTransformer menuTemplateTransformer)
        {
            MenuService = menuService;
            MenuTemplateTransformer = menuTemplateTransformer;

        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (MenuSelection == null || MenuPerspective == SupportMenuPerspectives.None || IsAResourceRequest) return;

            ProcessMenu();
        }
        /// <summary>
        /// Sets up the view bag to drive the CSHMTL menu rendering within the Views/Shared/PanelLayout.cshtml and Views/Shared/_navigation.cshtml views
        /// </summary>
        private void ProcessMenu()
        {
            RootMenu = MenuService.GetMenu(MenuPerspective).Result.FirstOrDefault();

            if (RootMenu == null) return;

            var menuItems = MenuTemplateTransformer.TransformMenuTemplates(RootMenu.MenuItems, MenuTransformationIdentifiers);

            if (!menuItems.Any()) return;

            _menuViewModel.SetMenu(menuItems, MenuSelection);

            ViewBag.Menu = _menuViewModel;
        }

        /// <summary>
        /// Signals to the 'OnActionExecuted' to ignore the menu generation processing if this request a resource (sub-view)
        /// </summary>
        public bool IsAResourceRequest { get { return HttpContext.Request.Headers.AllKeys.Contains(ResourceRequestHeader); } }
    }
}
