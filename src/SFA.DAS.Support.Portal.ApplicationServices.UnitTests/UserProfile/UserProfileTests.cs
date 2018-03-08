using NUnit.Framework;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.UserProfile
{
    [TestFixture]
    public class UserProfileTests
    {
        private ApplicationServices.Services.UserProfile _unit;

        [SetUp]
        public void Setup()
        {
            _unit = new ApplicationServices.Services.UserProfile();
        }

        [Test]
        public void ItShouldBeKeyedByUserIdentityWhichIsNullByDefault()
        {
            Assert.IsNull(_unit.Identity);
        }

        [Test]
        public void ItShouldNotHaveRecordedIfTheUserHasAgreedTheTermsAndConditions()
        {
            Assert.IsNull(_unit.AgreedTermsAndConditions);
        }
    }
}