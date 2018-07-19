using System.IO;
using Moq;
using NUnit.Framework;
using SFA.DAS.NLog.Logger;
using SFA.DAS.Support.Shared.Navigation;

namespace SFA.DAS.Support.Shared.Tests.Navigation
{
    /// <summary>
    ///     Obtains the menu templates for a specific support journey perspective
    /// </summary>
    public class WhenTestingAMenuTemplateDatasource
    {
        private Mock<ILog> _mockLogger;
        private IMenuTemplateDatasource _unit;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILog>();
            _unit = new MenuTemplateDatasource(new FileInfo($@"./MenuTemplates.json"), _mockLogger.Object);
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