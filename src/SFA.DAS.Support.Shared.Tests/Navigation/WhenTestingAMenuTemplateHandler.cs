using System.IO;
using System.Linq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    /// <summary>
    /// Serves the menu templates for a specific support journey perspective
    /// </summary>
    public class WhenTestingAMenuTemplateHandler
    {
        private MenuTemplateHandler _unit;

        [SetUp]
        public void Setup()
        {
            _unit = new MenuTemplateHandler(new MenuTemplateDatasource(new FileInfo($@".\MenuTempaltes.json")));
        }

        [Test]
        public void ItShouldProvideThemMenuTempalteForAPerspective()
        {
            var menu = _unit.GetMenuForPerspective(SupportMenuPerspectives.All);
            Assert.AreEqual(2, menu.Count());
        }

    }
}