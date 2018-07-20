using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    public class WhenTestingActiveMenuViewModel
    {
        private readonly MenuViewModel _unit = new MenuViewModel();
        private IMenuTemplateDatasource _menuTemplateDatasource;
        private Mock<ILog> _mockLogger;
        private List<MenuRoot> _rootMenus;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILog>();
            _menuTemplateDatasource = new MenuTemplateDatasource(@".\", _mockLogger.Object);
            _rootMenus = _menuTemplateDatasource.Provide();
            var items = _rootMenus.First(x => x.Perspective == SupportMenuPerspectives.EmployerAccount).MenuItems;
            _unit.SetMenu(items, "Account.Finance.PAYE");
        }

        [Test]
        public void ItShouldHaveAListOfMenuItems()
        {
            Assert.IsNotEmpty(_unit.MenuItems);
        }

        [Test]
        public void ItShouldHaveActiveMenuKeys()
        {
            Assert.IsNotEmpty(_unit.SelectedMenuItemKeys);
        }

        [Test]
        public void ItRootSelectedMenuShouldBeSetCorrectly()
        {
            Assert.AreEqual(_unit.SelectedMenuItemKeys.FirstOrDefault(), "Account");
        }

        [Test]
        public void ItActualSelectedMenuShouldBeSetCorrectly()
        {
            Assert.AreEqual(_unit.SelectedMenuItemKeys.LastOrDefault(), "Account.Finance.PAYE");
        }
    }
}