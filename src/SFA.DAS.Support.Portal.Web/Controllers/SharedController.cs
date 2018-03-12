using System.Threading;
using System.Web.Mvc;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using SFA.DAS.Support.Portal.Web.ViewModels;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    public class SharedController : BaseController
    {
        public SharedController(IUserProfileService userProfileService) : base(userProfileService)
        {
            UserProfileService = userProfileService;
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public PartialViewResult Header()
        {
            var viewModel = new HeaderViewModel
            {
                Username = Thread.CurrentPrincipal.Identity.Name
            };
            return PartialView("_Header", viewModel);
        }
    }
}