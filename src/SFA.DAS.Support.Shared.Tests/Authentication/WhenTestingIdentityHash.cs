using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Authentication;

namespace SFA.DAS.Support.Shared.Tests.Authentication
{
    [TestFixture]
    public class WhenTestingIdentityHash
    {
        private Mock<ICrypto> _mockCrypto;
        private IIdentityHash _unit;
        private string _testIdentity = "me@there.com";
        private string _hashedIdentity = "whatever";

        [SetUp]
        public void Setup()
        {
            _mockCrypto = new Mock<ICrypto>();
            _unit = new IdentityHash(_mockCrypto.Object);
            _mockCrypto.Setup(x => x.EncryptStringAES(_testIdentity)).Returns(_hashedIdentity);
            _mockCrypto.Setup(x => x.DecryptStringAES(_hashedIdentity)).Returns(_testIdentity);

        }

        [Test]
        public void ItShouldEncryptTheIdentity()
        {
            Assert.AreEqual(_hashedIdentity, _unit.Encrypt(_testIdentity));
            _mockCrypto.Verify(x => x.EncryptStringAES(_testIdentity), Times.Once);
        }

        [Test]
        public void ItShouldDecryptTheIdentity()
        {
            Assert.AreEqual(_testIdentity, _unit.Decrypt(_hashedIdentity));
            _mockCrypto.Verify(x => x.DecryptStringAES(_hashedIdentity), Times.Once);

        }
    }
}