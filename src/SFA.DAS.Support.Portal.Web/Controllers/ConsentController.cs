using System;
using System.Web.Mvc;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using SFA.DAS.Support.Portal.Web.Models;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    public class ConsentController : BaseController
    {
        public ConsentController(IUserProfileService userProfileService) : base(userProfileService)
        {
            UserProfileService = userProfileService;
        }

        public ActionResult Index(string returnUrl)
        {
            return View(new ConsentModel {ReturnUrl = returnUrl});
        }

        public ActionResult Denied(string resourceUrl)
        {
            if (string.IsNullOrWhiteSpace(resourceUrl)) resourceUrl = new Uri("~/", UriKind.Relative).ToString();
            UserProfile.AgreedTermsAndConditions = null;
            UserProfileService.StoreProfileForUser(UserProfile);
            return View(new ConsentModel {ReturnUrl = resourceUrl});
        }

        public RedirectResult Granted(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl)) returnUrl = new Uri("~/", UriKind.Relative).ToString();
            UserProfile.AgreedTermsAndConditions = DateTimeOffset.UtcNow;
            UserProfileService.StoreProfileForUser(UserProfile);
            return Redirect(returnUrl);
        }
    }
}