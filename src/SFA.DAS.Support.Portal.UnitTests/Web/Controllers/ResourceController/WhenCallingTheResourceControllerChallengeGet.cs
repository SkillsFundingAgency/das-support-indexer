﻿using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;
using SFA.DAS.Support.Portal.ApplicationServices.Models;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Portal.UnitTests.Web.Controllers.ResourceController
{
    [TestFixture]
    public class WhenCallingTheResourceControllerChallengeGet : WhenTestingTheResourceController
    {
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _id = "id";
            _resourceId = "resourceId";
            _key = "key";
            _url = "";
        }

        private string _id;
        private string _resourceId;
        private string _key;
        private string _url;


        [Test]
        public async Task ItShouldProvideTheChallengeMissingViewIfGetChallengeFormThrowsAnyException()
        {
            var navResponse =
                new NavViewModel {Current = "", Items = new[] {new NavItem {Href = "", Key = "", Title = ""}}};
            MockManifestRepository.Setup(x => x.ChallengeExists(_key)).Returns(Task.FromResult(true));
            MockManifestRepository.Setup(x => x.GetNav(_key, _resourceId)).Returns(Task.FromResult(navResponse));
            MockManifestRepository.Setup(x => x.GenerateHeader(_key, _resourceId))
                .Returns(Task.FromResult(new ResourceResultModel()));
            MockManifestRepository.Setup(x => x.GetChallengeForm(_key, _resourceId, _url)).Throws<Exception>();


            ActionResultResponse = await Unit.Challenge(_id, _resourceId, _key, _url);

            Assert.IsInstanceOf<ViewResult>(ActionResultResponse);
            var viewResult = (ViewResult) ActionResultResponse;

            Assert.IsInstanceOf<NavViewModel>(viewResult.ViewBag.SubNav);
            Assert.IsInstanceOf<object>(viewResult.ViewBag.SubHeader);
            Assert.AreEqual("Missing", viewResult.ViewName);
            Assert.IsNull(viewResult.Model);
        }

        [Test]
        public async Task ItShouldProvideTheChallengeSubView()
        {
            var navResponse =
                new NavViewModel {Current = "", Items = new[] {new NavItem {Href = "", Key = "", Title = ""}}};
            MockManifestRepository.Setup(x => x.ChallengeExists(_key)).Returns(Task.FromResult(true));
            MockManifestRepository.Setup(x => x.GetNav(_key, _resourceId)).Returns(Task.FromResult(navResponse));
            MockManifestRepository.Setup(x => x.GenerateHeader(_key, _resourceId))
                .Returns(Task.FromResult(new ResourceResultModel()));
            MockManifestRepository.Setup(x => x.GetChallengeForm(_key, _resourceId, _url))
                .Returns(Task.FromResult("<div></div."));

            ActionResultResponse = await Unit.Challenge(_id, _resourceId, _key, _url);

            Assert.IsInstanceOf<ViewResult>(ActionResultResponse);
            var viewResult = (ViewResult) ActionResultResponse;

            Assert.IsInstanceOf<NavViewModel>(viewResult.ViewBag.SubNav);
            Assert.IsInstanceOf<object>(viewResult.ViewBag.SubHeader);
            Assert.AreEqual("Sub", viewResult.ViewName);
            Assert.IsInstanceOf<string>(viewResult.Model);
        }

        [Test]
        public async Task ItShouldReturnHttpNotFoundIfTheChallengeDoesNotExist()
        {
            MockManifestRepository.Setup(x => x.ChallengeExists(_key)).Returns(Task.FromResult(false));

            ActionResultResponse = await Unit.Challenge(_id, _resourceId, _key, _url);

            Assert.IsInstanceOf<HttpNotFoundResult>(ActionResultResponse);
        }
    }
}