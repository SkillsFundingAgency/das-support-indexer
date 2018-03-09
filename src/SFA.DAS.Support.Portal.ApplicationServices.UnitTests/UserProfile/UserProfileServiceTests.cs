using System;
using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Portal.ApplicationServices.Services;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.UserProfile
{

    [TestFixture]
    public class UserProfileServiceTests
    {
        private const string TestUserIdentity = "test.user@test.org";
        private UserProfileService _unit;
        private readonly ApplicationServices.Services.UserProfile _testUserProfile = new ApplicationServices.Services.UserProfile() {Identity = TestUserIdentity };
        private Mock<IKeyedItemRepository<string, ApplicationServices.Services.UserProfile>> _mockUserProfileRepository;
        [SetUp]
        public void Setup()
        {
            _mockUserProfileRepository = new Mock<IKeyedItemRepository<string, ApplicationServices.Services.UserProfile>>();
            _unit = new UserProfileService(_mockUserProfileRepository.Object, DateTimeOffset.MinValue);
        }

        [Test]
        public void ItShouldCreateANewUserProfile()
        {
            var profile = new ApplicationServices.Services.UserProfile();
            _mockUserProfileRepository.Setup(x => x.Store(It.IsAny<ApplicationServices.Services.UserProfile>())).Returns(profile);
            Assert.IsNotNull( _unit.StoreProfileForUser(TestUserIdentity));
            _mockUserProfileRepository.Verify(x => x.Store(It.IsAny<ApplicationServices.Services.UserProfile>()), Times.Once);
        }

        [Test]
        public void ItShouldRetrieveAnExistingUserProfile()
        {
            _mockUserProfileRepository.Setup(x => x.Retreive(It.IsAny<string>())).Returns(_testUserProfile);
            Assert.AreEqual(_testUserProfile, _unit.RetrieveProfileForUser(TestUserIdentity));
            _mockUserProfileRepository.Verify(x => x.Retreive(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ItShouldUpdateAnExistingUserProfile()
        {
            var profile = new ApplicationServices.Services.UserProfile();
            _mockUserProfileRepository.Setup(x => x.Store(It.IsAny<ApplicationServices.Services.UserProfile>())).Returns(profile);
            Assert.DoesNotThrow(()=> _unit.StoreProfileForUser(_testUserProfile));
            _mockUserProfileRepository.Verify(x => x.Store(It.IsAny<ApplicationServices.Services.UserProfile>()), Times.Once);
        }

    }
}
