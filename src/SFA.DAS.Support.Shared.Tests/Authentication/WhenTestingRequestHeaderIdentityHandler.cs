using System.Collections.Specialized;
using System.Net.Http;
using System.Web;
using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Authentication;

namespace SFA.DAS.Support.Shared.Tests.Authentication
{
    [TestFixture]
    public class WhenTestingRequestHeaderIdentityHandler
    {
        private IIdentityHandler _unit;
        private Mock<IIdentityHash> _mockIdentityHash;
        private string _testIdentity = "me@there.com";
        private Mock<HttpRequestBase> _requestBase;
        private string _hashedIdentity = "hashedId";
        private NameValueCollection _nameValueCollection;
        private HttpClient _client;
        [SetUp]
        public void Setup()
        {
            _client = new HttpClient();
            _mockIdentityHash = new Mock<IIdentityHash>();
            _mockIdentityHash.Setup(x => x.Encrypt(_testIdentity)).Returns(_hashedIdentity);
            _mockIdentityHash.Setup(x => x.Decrypt(_hashedIdentity)).Returns(_testIdentity);

            _requestBase = new Mock<HttpRequestBase>();
            _nameValueCollection = new NameValueCollection();
            _requestBase.SetupGet(x => x.Headers).Returns(_nameValueCollection);
            _unit = new RequestHeaderIdentityHandler(_mockIdentityHash.Object);

        }

        [Test]
        public void ItShouldStoreTheIdentityreaduForRequestTransmission()
        {
            _unit.SetIdentity(_client, _testIdentity);
            Assert.IsTrue(_client.DefaultRequestHeaders.Contains(RequestHeaderIdentityHandler.XResourceRequestIdentity));
            _mockIdentityHash.Verify(x => x.Encrypt(_testIdentity), Times.Once);
            _mockIdentityHash.Verify(x => x.Decrypt(_hashedIdentity), Times.Never);
        }
    }
}