using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    public class WhenTestingDefaultMenuProvider
    {
        private readonly MenuViewModel _unit = new MenuViewModel();


        [Test]
        public void ItShouldHaveAListOfMenuItems()
        {
            Assert.IsEmpty(_unit.MenuItems);
        }


        [Test]
        public void ItShouldHaveNoActiveMenuKeysByDefault()
        {
            Assert.IsEmpty(_unit.SelectedMenuItemKeys);
        }

        [Test]
        public void ItShouldHaveMenuItemsWhenAdded()
        {
            _unit.MenuItems.AddRange(MenuTestHelper.GetEmployerUserMenu().MenuItems);

            _unit.MenuItems.AddRange(MenuTestHelper.GetEmployerAccountMenu().MenuItems);

            Assert.IsNotEmpty(_unit.MenuItems);
        }

        [Test]
        public void ItShouldConvertToAndFromJson()
        {

            Assert.DoesNotThrow(() =>
            {
                var expected = MenuTestHelper.FullMenu();
                var menuData = JsonConvert.SerializeObject(expected);
                JsonConvert.DeserializeObject<List<MenuRoot>>(menuData);

            });

        }

    }
}