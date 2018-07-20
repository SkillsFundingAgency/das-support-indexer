﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moq;
using NUnit.Framework;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    /// <summary>
    ///     Transforms Menu templates into usable navigable Uri's
    /// </summary>
    public class WhenTestingAMenuTemplateTransformer
    {
        private IMenuTemplateDatasource _datasource;
        private Mock<ILog> _mockLogger;
        private readonly Uri _supportPortalUri = new Uri("https://localhost:44300");
        private List<MenuRoot> _templates;
        private MenuTemplateTransformer _unit;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILog>();
            _datasource = new MenuTemplateDatasource(new FileInfo("/"), _mockLogger.Object);
            _templates = _datasource.Provide();

            _unit = new MenuTemplateTransformer(_supportPortalUri);
        }

        [Test]
        public void ItShouldTransformAllTemplatesForOnePerspective()
        {
            var templateItems = _templates.Single(x => x.Perspective == SupportMenuPerspectives.EmployerAccount).MenuItems;
            var templateItemsAsList = templateItems.Map(s => true, n => n.MenuItems).ToList();
            var _countOfUnIdentifiableMenuItems = 1;
            var actual = _unit.TransformMenuTemplates(templateItems, new Dictionary<string, string> { { "accountId", "123" } });
            Assert.IsNotEmpty(actual);

            var actualItemsAsList = actual.Map(s => true, n => n.MenuItems).ToList();
            
            Assert.AreEqual(actualItemsAsList.Count, templateItemsAsList.Count - _countOfUnIdentifiableMenuItems);
        }


        [Test]
        public void ItShouldTransformAllTemplatesForOneOtherPerspective()
        {
            var actual = _unit.TransformMenuTemplates(
                _templates.Single(x => x.Perspective == SupportMenuPerspectives.EmployerUser).MenuItems,
                new Dictionary<string, string> { { "userId", "123" } });
            Assert.IsNotEmpty(actual);
            Assert.AreEqual(
                _templates.Single(x => x.Perspective == SupportMenuPerspectives.EmployerUser).MenuItems.Count,
                actual.Count);
        }


        [Test]
        public void ItShouldRemoveUntransformedTemplates()
        {
            var actual = _unit.TransformMenuTemplates(
                _templates.Single(x => x.Perspective == SupportMenuPerspectives.EmployerUser).MenuItems,
                new Dictionary<string, string> { { "accountId", "123" } });
            Assert.IsEmpty(actual);
        }
    }
}