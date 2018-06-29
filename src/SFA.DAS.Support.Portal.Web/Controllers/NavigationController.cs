using System.Web.Http;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    [RoutePrefix("api/navigation")]
    public class NavigationController : ApiController
    {
        private readonly IMenuTemplateHandler _menuTemplateHandler;  
        public NavigationController(IMenuTemplateHandler menuTemplateHandler)
        {
            _menuTemplateHandler = menuTemplateHandler;
        }
        [HttpGet]
        public IHttpActionResult Get(SupportMenuPerspectives id = SupportMenuPerspectives.All)
        {
            var menuForPerspective = _menuTemplateHandler.GetMenuForPerspective(id);
            return Ok(menuForPerspective);
        }

    }
}
