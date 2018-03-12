using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using SFA.DAS.Support.Portal.ApplicationServices.Services;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UserProfile UserProfile = new UserProfile() { Created = DateTimeOffset.MinValue, Identity = "anonymous", AgreedTermsAndConditions  = DateTimeOffset.MaxValue };
        protected IUserProfileService UserProfileService;
       
        public BaseController(IUserProfileService userProfileService)
        {
            UserProfileService = userProfileService;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            GetUserProfile();

            if (filterContext.Controller.GetType() == typeof(SharedController) || 
                filterContext.Controller.GetType() == typeof(ConsentController)
            )
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                if (!UserProfile.AgreedTermsAndConditions.HasValue  ||
                    UserProfile.AgreedTermsAndConditions.Value < UserProfileService.TermsAndConditionsApplyFrom)
                {
                    filterContext.Result = RedirectToAction("Index", "Consent", new { ReturnUrl = Request.Url });
                }
                else
                {
                    base.OnActionExecuting(filterContext);
                }
            }
        }

        private void GetUserProfile()
        {
            var userEmail = (User.Identity as ClaimsIdentity)?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            if (userEmail == null) return;
            UserProfile = UserProfileService.RetrieveProfileForUser(userEmail.Value) ??
                          UserProfileService.StoreProfileForUser(userEmail.Value);
        }
    }
}