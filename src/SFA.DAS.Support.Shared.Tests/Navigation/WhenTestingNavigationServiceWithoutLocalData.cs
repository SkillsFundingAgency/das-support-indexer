using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    [TestFixture]
    public class WhenTestingNavigationServiceWithoutLocalData : TestBase<NavigationService>
    {
        private List<MenuRoot> _rootMenus;

        protected override void Arrange()
        {
            Unit = new NavigationService(new DirectoryInfo($@"..\"), new MenuTemplateDatasource(new FileInfo(@"..\")), new MenuClient());

        }

        protected override void Act()
        {
            _rootMenus = Unit.GetMenu(SupportMenuPerspectives.EmployerAccount);
        }

        [Test]
        public void ItShouldResourceTheNavigationRemotely()
        {
            Assert.IsNotEmpty(_rootMenus);
        }
    }

}
