using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Discovery;
using SFA.DAS.Support.Shared.Navigation;
using SFA.DAS.Support.Shared.SiteConnection;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    [TestFixture]
    public class WhenTestingServiceAddressMapper
    {
        [SetUp]
        public void Setup()
        {
            _mockSettings = new Mock<ISiteSettings>();
            _unit = new ServiceAddressMapper(_mockSettings.Object);

            _mockSettings.SetupGet(x => x.BaseUrls)
                .Returns($"{SupportServiceIdentity.SupportPortal}|{_testAddress}");
        }

        private Mock<ISiteSettings> _mockSettings;
        private ServiceAddressMapper _unit;
        private readonly string _testAddress = "https://localhost:44347/";

        [Test]
        public void ItShouldMapServiceEnumToAddressUri()
        {
            Assert.AreEqual(_testAddress, _unit.Addressof(SupportServiceIdentity.SupportPortal).OriginalString);
        }
    }
}