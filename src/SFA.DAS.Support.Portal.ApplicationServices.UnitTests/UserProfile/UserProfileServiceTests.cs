using NUnit.Framework;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.UserProfile
{

    [TestFixture]
    public class UserProfileServiceTests
    {
        private const string TestUserIdentity = "test.user@test.org";
        private UserProfileService _unit;
        private readonly UserProfile _testUserProfile = new UserProfile() {Identity = TestUserIdentity };

        [SetUp]
        public void Setup()
        {
            _unit = new UserProfileService();
        }

        [Test]
        public void ItShouldCreateUserProfile()
        {
            Assert.IsNotNull( _unit.Store(TestUserIdentity));
        }

        [Test]
        public void ItShouldRetrieveAUserProfile()
        {
            Assert.IsNotNull( _unit.Retrieve(TestUserIdentity));
        }

        [Test]
        public void ItShouldUpdateAUserProfile()
        {
            Assert.DoesNotThrow(()=> _unit.Store(_testUserProfile));
        }
    }
}
