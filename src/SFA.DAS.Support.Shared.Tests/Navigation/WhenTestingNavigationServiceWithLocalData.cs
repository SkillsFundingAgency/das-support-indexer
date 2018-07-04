using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    [TestFixture]
    public class WhenTestingNavigationServiceWithLocalData : TestBase<NavigationService>
    {
        private List<MenuRoot> _rootMenus;
        private Mock<IMenuClient> _mockMenuClient;
        private Mock<IMenuTemplateDatasource> _mockMenuTemplateDataSource;
        private List<MenuRoot> _testMenuTemplates = new List<MenuRoot>();
        private string _testMenuFile = @"..\TestMenu.json";


        protected override void Arrange()
        {
            _testMenuTemplates = new MenuTemplateDatasource(new FileInfo($@"./MenuTemplates.json")).Provide();
            _mockMenuClient = new Mock<IMenuClient>();
            _mockMenuTemplateDataSource = new Mock<IMenuTemplateDatasource>();

            Unit = new NavigationService(new DirectoryInfo($@"..\"), _mockMenuTemplateDataSource.Object, _mockMenuClient.Object);

            _mockMenuTemplateDataSource.Setup(x => x.Provide()).Returns(_testMenuTemplates);           
           
        }

        protected override void Act()
        {
            _rootMenus = Unit.GetMenu(SupportMenuPerspectives.EmployerAccount);
        }

        [Test]
        public void ItShouldResourceTheNavigation()
        {
            Assert.IsNotEmpty(_rootMenus);
        }

        [Test]
        public void ItShouldResourceTheNavigationLocally()
        {
            _mockMenuTemplateDataSource.Verify(x => x.Provide(), Times.Once);
        }

        [Test]
        public void ItShouldNotResourceTheNavigationRemotely()
        {
            _mockMenuClient.Verify(x => x.GetMenuForPerspective(It.IsAny<SupportMenuPerspectives>()), Times.Never);
        }
    }
}