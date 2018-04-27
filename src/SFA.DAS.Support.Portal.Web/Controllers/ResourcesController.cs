using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SFA.DAS.Support.Portal.ApplicationServices.Models;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.SiteConnection;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly ISiteConnector _siteConnector;

        public ResourcesController(ISiteConnector siteConnector)
        {
            _siteConnector = siteConnector;
        }

        [HttpGet]
        [Route("views/{*path")]
        public async Task<ActionResult> Index(string path)
        {

            var pathElements = (path ?? string.Empty).Split('/');

            if (pathElements.Length < 2)
                return View("Missing");

            var service = (SupportServiceIdentity)Enum.Parse(typeof(SupportServiceIdentity), pathElements[0]);

            var viewPath = pathElements.Skip(1)
                        .Take(int.MaxValue)
                        .Aggregate(string.Empty,
                            (current, item) => current +
                                               $"{(current.Length == 0 ? string.Empty : "/")}{item}");
            var uri = new Uri(viewPath, UriKind.Relative);

            string resource = await _siteConnector.Download(service, uri);

            var resourceResultModel = new ResourceResultModel
            {
                Resource = resource,
                Exception = _siteConnector.LastException,
                StatusCode = _siteConnector.LastCode
            };
            return View("Resource", resourceResultModel);
        }
    }
}