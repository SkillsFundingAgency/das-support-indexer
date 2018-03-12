using NUnit.Framework;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.UserProfile
{
    [TestFixture]
    public class UserProfileTests
    {
        private UserProfile _unit;

        [SetUp]
        public void Setup()
        {
            _unit = new UserProfile();
        }

        [Test]
        public void ItShouldBeKeyedByUserIdentityWhichIsNullByDefault()
        {
            Assert.IsNull(_unit.Identity);
        }
        [Test]
        public void ItShouldRecordIfTheUserHasNotAgreedTheTermsAndConditionsForThisVersionByDefault()
        {
            Assert.False(_unit.HasAgreedTermsAndConditions);
        }

        [Test]
        public void ItShouldProvideADateAndTimeOfFirstLogOn()
        {
            Assert.IsNull(_unit.FirstLogOn);
        }

        [Test]
        public void ItShouldProvideADateAndTimeOfLastLogOn()
        {
            Assert.IsNull(_unit.LastLogOn);
        }


    }
}