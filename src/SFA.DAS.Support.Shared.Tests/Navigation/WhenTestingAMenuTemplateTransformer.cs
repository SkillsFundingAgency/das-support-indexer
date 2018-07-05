using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    /// <summary>
    ///     Transforms Menu templates into usable navigable Uri's
    /// </summary>
    public class WhenTestingAMenuTemplateTransformer
    {
        private IMenuTemplateDatasource _datasource;
        private List<MenuRoot> _templates;
        private MenuTemplateTransformer _unit;

        [SetUp]
        public void Setup()
        {
            _datasource = new MenuTemplateDatasource(new FileInfo("/"));
            _templates = _datasource.Provide();
            _unit = new MenuTemplateTransformer();
        }

        [Test]
        public void ItShouldTransformAllTemplatesForOnePerspective()
        {
            var actual = _unit.TransformMenuTemplates(
                _templates.Single(x => x.Perspective == SupportMenuPerspectives.EmployerAccount).MenuItems,
                new Uri("https://localhost:44300"),
                new Dictionary<string, string> {{"accountId", "123"}});
            Assert.IsNotEmpty(actual);
            Assert.AreEqual(
                _templates.Single(x => x.Perspective == SupportMenuPerspectives.EmployerAccount).MenuItems.Count,
                actual.Count);
        }


        [Test]
        public void ItShouldTransformAllTemplatesForOneOtherPerspective()
        {
            var actual = _unit.TransformMenuTemplates(
                _templates.Single(x => x.Perspective == SupportMenuPerspectives.EmployerUser).MenuItems,
                new Uri("https://localhost:44300"),
                new Dictionary<string, string> {{"userId", "123"}});
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
                new Uri("https://localhost:44300"),
                new Dictionary<string, string> {{"accountId", "123"}});
            Assert.IsEmpty(actual);
        }
    }
}