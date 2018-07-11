using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Portal.Web.ViewModels;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.Navigation;
using SFA.DAS.Support.Shared.SiteConnection;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    public class ViewsController : Controller
    {
        private readonly ILog _logger;
        private readonly ISiteConnector _siteConnector;
        private readonly IRouteToServiceMapper _routeToServiceMapper;
        private readonly IServiceAddressMapper _serviceToAddressMapper;

        public ViewsController(ISiteConnector siteConnector, IRouteToServiceMapper routeToServiceMapper, IServiceAddressMapper serviceAddressMapper, ILog logger)
        {
            _siteConnector = siteConnector;
            _routeToServiceMapper = routeToServiceMapper;
            _serviceToAddressMapper = serviceAddressMapper;
            _logger = logger;
        }

        [Route("views/{*path}")]
        public async Task<ActionResult> Index(string path)
        {
            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Index))} [{path}]");

            if (string.IsNullOrWhiteSpace(path)) return RedirectToRoute("Default");

            SupportServiceIdentity service = _routeToServiceMapper.Service(path);

            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Resources))} View request {path} is destined for service {service}");

            var serviceUri = _serviceToAddressMapper.Addressof(service);

            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Resources))} View request is being redirected to {serviceUri.OriginalString}");

            var contentUri = new Uri(serviceUri, path);

            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Resources))} View Content downloading from {contentUri.OriginalString}");

            var content = await _siteConnector.Download(contentUri);

            return View("index", new ViewsViewModel(){ Content = new HtmlString(content) });
        }

        [Route("resources/{*path}")]
        public async Task<MvcHtmlString> Resources(string path)
        {
            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Resources))} [{path}]");

            if (string.IsNullOrWhiteSpace(path)) return await Task.FromResult(new MvcHtmlString(string.Empty));

            SupportServiceIdentity service = _routeToServiceMapper.Service(path);

            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Resources))} Resource request {path} is destined for service {service}");

            var serviceUri = _serviceToAddressMapper.Addressof(service);

            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Resources))} Resource request is being redirected to {serviceUri.OriginalString}");

            var contentUri = new Uri(serviceUri, path);

            _logger.Trace($"{nameof(ViewsController)}.{(nameof(Resources))} Resource Content downloading from {contentUri.OriginalString}");


            _siteConnector.SetCustomHeader("X-Resource", null);

            var resource = await _siteConnector.Download(contentUri);

            _siteConnector.ClearCustomHeaders("X-Resource");

            return new MvcHtmlString(resource);
        }
    }

}