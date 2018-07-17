using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SFA.DAS.Support.Shared.Authentication;
using SFA.DAS.Support.Shared.Challenge;

namespace SFA.DAS.Support.Shared.Navigation
{
    public abstract class BaseController : Controller
    {
        public const string ResourceIdentityHeader = "X-ResourceIdentity";
        public const string ResourceRequestHeader = "X-ResourceRequest";

        protected static readonly MenuRoot EmptyMenu =
            new MenuRoot {MenuItems = new List<MenuItem>(), Perspective = SupportMenuPerspectives.None};

        /// Pull up to basecontroller
        private readonly int _challengeExpiryMinutes;

        /// Pull up to basecontroller
        private readonly int _challengeMaxTries;

        /// Pull up to basecontroller
        private readonly IChallengeService _challengeService;

        private readonly IIdentityHandler _identityHandler;

        private readonly MenuViewModel _menuViewModel = new MenuViewModel {MenuOrientation = MenuOrientations.Vertical};
        protected readonly IMenuService MenuService;
        protected readonly IMenuTemplateTransformer MenuTemplateTransformer;

        protected BaseController(IMenuService menuService,
            IMenuTemplateTransformer menuTemplateTransformer,
            IChallengeService challengeService,
            IIdentityHandler identityHandler)
        {
            MenuService = menuService;
            MenuTemplateTransformer = menuTemplateTransformer;
            _challengeService = challengeService;
            _identityHandler = identityHandler;
        }

        protected MenuRoot RootMenu { get; set; } = EmptyMenu;

        protected Dictionary<string, string> MenuTransformationIdentifiers { get; set; } =
            new Dictionary<string, string>();

        protected SupportMenuPerspectives MenuPerspective { get; set; } = SupportMenuPerspectives.None;
        protected string MenuSelection { get; set; } = null;

        public string ResourceIdentity { get; set; }

        /// <summary>
        ///     Signals to the 'OnActionExecuted' to ignore the menu generation processing if this request a resource (sub-view)
        /// </summary>
        public bool IsAResourceRequest => HttpContext.Request.Headers.AllKeys.Contains(ResourceRequestHeader);

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ResourceIdentity = _identityHandler.GetIdentity(Request);

            base.OnActionExecuted(filterContext);

            if (MenuSelection == null || MenuPerspective == SupportMenuPerspectives.None || IsAResourceRequest) return;

            ProcessMenu();
        }


        /// <summary>
        ///     Sets up the view bag to drive the CSHMTL menu rendering within the Views/Shared/PanelLayout.cshtml and
        ///     Views/Shared/_navigation.cshtml views
        /// </summary>
        private void ProcessMenu()
        {
            RootMenu = MenuService.GetMenu(MenuPerspective).Result.FirstOrDefault();

            if (RootMenu == null) return;

            var menuItems =
                MenuTemplateTransformer.TransformMenuTemplates(RootMenu.MenuItems, MenuTransformationIdentifiers);

            if (!menuItems.Any()) return;

            _menuViewModel.SetMenu(menuItems, MenuSelection);

            ViewBag.Menu = _menuViewModel;
        }
    }
}