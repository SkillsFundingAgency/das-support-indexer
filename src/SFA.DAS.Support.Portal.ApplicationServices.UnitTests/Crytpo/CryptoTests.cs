﻿using NUnit.Framework;
using SFA.DAS.Support.Portal.ApplicationServices.Services;
using SFA.DAS.Support.Portal.ApplicationServices.Settings;
using SFA.DAS.Support.Portal.Core.Services;
using SFA.DAS.Support.Portal.Infrastructure.Settings;

namespace SFA.DAS.Support.Portal.ApplicationServices.UnitTests.Crytpo
{
    [TestFixture]
    public class CryptoTests
    {
        private ICrypto _unit;
        private ICryptoSettings _settings;
        private IProvideSettings _provider;
        private IProvideSettings _baseSettings;

        [SetUp]
        public void Setup()
        {
            _baseSettings = new MachineSettings("local");
            _provider = new AppConfigSettingsProvider(_baseSettings);
            _settings = new CryptoSettings(_provider);
            _unit = new Crypto(_settings);
        }

        [Test]
        public void ItShouldEncryptAndDecryptSymmetrically()
        {
            string expected = "123456";
            var encryptedValue = _unit.EncryptStringAES(expected);
            var actual = _unit.DecryptStringAES(encryptedValue);
            Assert.AreEqual(expected, actual);
        }
    }
}