using NUnit.Framework;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    [TestFixture]
    public class WhenTestingRouteToServiceMapper
    {
        private RouteToServiceMapper _unit;

        [SetUp]
        public void Setup()
        {
            _unit = new RouteToServiceMapper();
        }

        [Test]
        public void ItShouldMapToPortalByDefault()
        {
            Assert.AreEqual(SupportServiceIdentity.SupportPortal , _unit.Service(null));
        }


        [Test]
        public void ItShouldMapToPortalWhenUnknown()
        {
            Assert.AreEqual(SupportServiceIdentity.SupportPortal, _unit.Service("something/unknown"));
        }

        [Test]
        public void ItShouldMapToEmployerUsersWhenRouteStartsWithUsers()
        {
            Assert.AreEqual(SupportServiceIdentity.SupportEmployerUser, _unit.Service("employerusers/whatever"));
        }

        [Test]
        public void ItShouldMapToEmployerWhenRouteStartsWithEmployers()
        {
            Assert.AreEqual(SupportServiceIdentity.SupportEmployerAccount, _unit.Service("employers/whatever"));
        }

        [Test]
        public void ItShouldMapToCommitmentsWhenRouteStartsWithCommitments()
        {
            Assert.AreEqual(SupportServiceIdentity.SupportCommitments, _unit.Service("commitments/whatever"));
        }

    }
}
