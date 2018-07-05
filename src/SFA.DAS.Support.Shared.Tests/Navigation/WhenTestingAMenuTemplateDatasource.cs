using System.IO;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    /// <summary>
    ///     Obtains the menu templates for a specific support journey perspective
    /// </summary>
    public class WhenTestingAMenuTemplateDatasource
    {
        private IMenuTemplateDatasource _unit;

        [SetUp]
        public void Setup()
        {
            _unit = new MenuTemplateDatasource(new FileInfo($@"./MenuTemplates.json"));
        }

        [Test]
        public void ItShouldProvideTheCompleteSetOfMenuTemplates()
        {
            Assert.IsNotEmpty(_unit.Provide());
        }

        [Test]
        public void ItShouldProvideTherightCountOfMenuTemplateSets()
        {
            Assert.AreEqual(2, _unit.Provide().Count);
        }
    }
}