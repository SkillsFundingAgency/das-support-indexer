using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    public class WhenTestingActiveMenuViewModel
    {
        private  List<MenuRoot> _rootMenus ;
        private readonly IMenuTemplateDatasource _menuTemplateDatasource = new MenuTemplateDatasource(@".\");
        private readonly MenuViewModel _unit = new MenuViewModel();

        [SetUp]
        public void Setup()
        {

            _rootMenus = _menuTemplateDatasource.Provide();

            var items = _rootMenus.First(x=>x.Perspective == SupportMenuPerspectives.EmployerAccount).MenuItems;
            _unit.SetMenu(items, "Account.Finance.PAYE");
        }
        [Test]
        public void ItShouldHaveAListOfMenuItems()
        {
            Assert.IsNotEmpty(_unit.MenuItems);
            Assert.AreEqual(3, _unit.MenuItems.Count);
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