﻿using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    [TestFixture]
    public class WhenTestingNavigationServiceWithoutLocalData : TestBase<MenuService>
    {
        private List<MenuRoot> _rootMenus;
        private Mock<IMenuClient> _mockMenuClient;
        private Mock<IMenuTemplateDatasource> _mockMenuTemplateDataSource;
        private List<MenuRoot> _testMenuTemplates = new List<MenuRoot>();


        protected override void Arrange()
        {
            _testMenuTemplates = new MenuTemplateDatasource(new FileInfo($@"./MenuTemplates.json")).Provide();
            _mockMenuClient = new Mock<IMenuClient>();
            _mockMenuTemplateDataSource = new Mock<IMenuTemplateDatasource>();
            var directoryInfo = new DirectoryInfo($@"..\");
            var menuRemoteSource = new Uri("https://localhost/api/navigation/0");
            Unit = new MenuService(directoryInfo, _mockMenuTemplateDataSource.Object, _mockMenuClient.Object,
                menuRemoteSource);
            _mockMenuTemplateDataSource.Setup(x => x.Provide()).Returns(new List<MenuRoot>());
            _mockMenuClient.Setup(x => x.GetMenuForPerspective(It.IsAny<SupportMenuPerspectives>(), It.IsAny<Uri>()))
                .ReturnsAsync(_testMenuTemplates);
        }

        protected override void Act()
        {
            _rootMenus = Unit.GetMenu(SupportMenuPerspectives.EmployerAccount).Result;
        }

        [Test]
        public void ItShouldNotResourceTheNavigationRemotely()
        {
            _mockMenuClient.Verify(x => x.GetMenuForPerspective(It.IsAny<SupportMenuPerspectives>(), It.IsAny<Uri>()),
                Times.Once);
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
    }
}