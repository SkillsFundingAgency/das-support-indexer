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
            _unit.MenuItems.Add(MenuTestHelper.GetEmployerUserMenu());

            _unit.MenuItems.Add(MenuTestHelper.GetEmployerAccountMenu());

            Assert.IsNotEmpty(_unit.MenuItems);

        }

    }
}