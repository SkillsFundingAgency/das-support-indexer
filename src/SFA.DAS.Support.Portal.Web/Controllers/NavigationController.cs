using System.Threading.Tasks;
using System.Web.Http;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    [RoutePrefix("navigation")]
    public class NavigationController : ApiController
    {
        private IMenuTemplateHandler _menuTemplateHandler;  
        public NavigationController(IMenuTemplateHandler menuTemplateHandler)
        {
            _menuTemplateHandler = menuTemplateHandler;
        }
        [HttpGet]
        public IHttpActionResult Index(SupportMenuPerspectives perspective)
        {
            var menuForPerspective = _menuTemplateHandler.GetMenuForPerspective(perspective);
            return Ok(menuForPerspective);
        }

    }
}
