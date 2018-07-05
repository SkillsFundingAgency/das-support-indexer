using System.Web.Hosting;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Views;

namespace SFA.DAS.Support.Shared.Tests.Views
{
    public class WhenTestingEmbeddedResourceViewPathProvider
    {
        private EmbeddedResourceViewPathProvider _unit;

        [SetUp]
        public void Setup()
        {
            _unit = new EmbeddedResourceViewPathProvider();
        }

        [Test]
        public void ItShouldDetectAViewInTheSharedLibrary()
        {
            var path = "/Views/Shared/PanelLayout.cshtml";
            var itemExists = _unit.FileExists(path);
            Assert.IsTrue(itemExists);


            var item = _unit.GetFile(path);
            Assert.IsInstanceOf<VirtualFile>(item);
            var file = item.Open();
            Assert.IsNotNull(file);
        }

        [Test]
        public void ItShouldResolveAViewInTheSharedLibrary()
        {
            var path = "/Views/Shared/PanelLayout.cshtml";
            var item = _unit.GetFile(path);
            Assert.IsInstanceOf<VirtualFile>(item);
        }

        [Test]
        public void ItShouldRetrieveAViewFromTheSharedLibrary()
        {
            var path = "/Views/Shared/PanelLayout.cshtml";
            var item = _unit.GetFile(path);
            var file = item.Open();
            Assert.IsNotNull(file);
        }
    }
}