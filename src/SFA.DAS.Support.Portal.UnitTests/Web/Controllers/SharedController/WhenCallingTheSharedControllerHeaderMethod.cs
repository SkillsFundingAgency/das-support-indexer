using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using SFA.DAS.Support.Portal.Web.ViewModels;

namespace SFA.DAS.Support.Portal.UnitTests.Web.Controllers.SharedController
{
    [TestFixture]
    public class
        WhenCallingTheSharedControllerHeaderMethod : WhenTestingAnMvcControllerOfType<
            Portal.Web.Controllers.SharedController>
    {
        private Mock<IUserProfileService> _mockIUserProfileService;
        [SetUp]
        public override void Setup()
        {
            _mockIUserProfileService = new Mock<IUserProfileService>();
            Unit = new Portal.Web.Controllers.SharedController(_mockIUserProfileService.Object);
            ActionResultResponse = Unit.Header();
        }

        [Test]
        public void ItShouldReturnAPartialHeaderView()
        {
            Assert.IsInstanceOf<PartialViewResult>(ActionResultResponse);

            var expected = "_Header";
            Assert.AreEqual(expected, (ActionResultResponse as PartialViewResult).ViewName);
        }

        [Test]
        public void ItShouldReturnAUsernameInTheViewModel()
        {
            Assert.IsInstanceOf<HeaderViewModel>((ActionResultResponse as PartialViewResult).Model);
            Assert.IsNotNull(((HeaderViewModel) (ActionResultResponse as PartialViewResult).Model).Username);
        }
    }
}