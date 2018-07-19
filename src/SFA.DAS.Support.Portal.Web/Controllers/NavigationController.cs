using System.Diagnostics;
using System.Web.Http;
using Newtonsoft.Json;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    [AllowAnonymous] // TODO: Take off
    [RoutePrefix("api/navigation")]
    public class NavigationController : ApiController
    {
        private readonly IMenuTemplateHandler _menuTemplateHandler;

        public NavigationController(IMenuTemplateHandler menuTemplateHandler)
        {
            _menuTemplateHandler = menuTemplateHandler;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(SupportMenuPerspectives id = SupportMenuPerspectives.All)
        {
            var menuForPerspective = _menuTemplateHandler.GetMenuForPerspective(id);
            Debug.WriteLine($"Serving menu Data: {JsonConvert.SerializeObject(menuForPerspective)}");
            return Ok(menuForPerspective);
        }
    }
}