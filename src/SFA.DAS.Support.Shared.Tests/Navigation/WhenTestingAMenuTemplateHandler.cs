using System.IO;
using System.Linq;
using Moq;
using NUnit.Framework;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    /// <summary>
    ///     Serves the menu templates for a specific support journey perspective
    /// </summary>
    public class WhenTestingAMenuTemplateHandler
    {
        private MenuTemplateHandler _unit;
        private Mock<ILog> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILog>();
            _unit = new MenuTemplateHandler(new MenuTemplateDatasource(new FileInfo($@".\MenuTempaltes.json"), _mockLogger.Object));
        }

        [Test]
        public void ItShouldProvideThemMenuTempalteForAPerspective()
        {
            var menu = _unit.GetMenuForPerspective(SupportMenuPerspectives.All);
            Assert.AreEqual(2, menu.Count());
        }
    }
}