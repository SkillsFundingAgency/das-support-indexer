﻿using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using SFA.DAS.Support.Portal.ApplicationServices.Models;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using SFA.DAS.Support.Portal.Web.Services;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Portal.Web.Controllers
{
    public class ResourceController : Controller
    {
        private readonly ICheckPermissions _checker;
        private readonly IGrantPermissions _granter;
        private readonly IManifestRepository _repository;

        public ResourceController(
            IManifestRepository repository,
            ICheckPermissions checker,
            IGrantPermissions granter)
        {
            _repository = repository;
            _checker = checker;
            _granter = granter;
        }

        [HttpGet]
        public async Task<ActionResult> Challenge(string id, string resourceId, SupportServiceResourceKey key,
            string url)
        {
            if (!await _repository.ChallengeExists(key)) return HttpNotFound();

            ViewBag.SubNav = await _repository.GetNav(key, resourceId);
            ViewBag.SubHeader = await _repository.GenerateHeader(key, resourceId);

            try
            {
                var challengeForm = await _repository.GetChallengeForm(key, resourceId, url);
                return View("Sub", new ResourceResultModel
                {
                    StatusCode = HttpStatusCode.OK,
                    Resource = challengeForm
                });
            }
            catch
            {
                return View("Missing");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Challenge(string id, string resourceId,  SupportServiceResourceKey key,
            FormCollection formData)
        {
            var pairs = formData.AllKeys.ToDictionary(k => k, v => formData[v]);
            var result = await _repository.SubmitChallenge(resourceId, pairs);

            if (result.HasRedirect)
            {
                _granter.GivePermissions(Response, User, $"{key}/{resourceId}");
                return Redirect(result.RedirectUrl);
            }

            ViewBag.SubNav = await _repository.GetNav(key, resourceId);
            ViewBag.SubHeader = await _repository.GenerateHeader(key, resourceId);
            return View("Sub", new ResourceResultModel
            {
                StatusCode = HttpStatusCode.OK,
                Resource = result.Page
            });
        }

        [HttpGet]
        public async Task<ActionResult> Index( SupportServiceResourceKey key, string id)
        {
            
            if (!await _repository.ResourceExists(key))
                return View("Sub",
                    new ResourceResultModel
                    {
                        Resource = "<h3>This resource isn't registered</h3>",
                        StatusCode = HttpStatusCode.OK,
                        Exception = null
                    });

            var resource = await _repository.GetResource(key);

            if (!string.IsNullOrEmpty(resource.Challenge))
                if (!_checker.HasPermissions(Request, Response, User, $"{key}/{id}"))
                    return RedirectToAction("Challenge",
                        new {key = resource.Challenge, resourceId = id, url = Request.RawUrl});

            ViewBag.SubNav = await _repository.GetNav(key, id);
            ViewBag.SubHeader = await _repository.GenerateHeader(key, id);

            var resourceResult = await _repository.GetResourcePage(key, id);

            return View("Sub", resourceResult);
        }
    }
}