﻿using System;
using NUnit.Framework;
using SFA.DAS.Support.Shared.Discovery;

namespace SFA.DAS.Support.Shared.Tests.Discovery
{
    [Obsolete]
    [TestFixture]
    public class WhenCallingGetChallenge
    {
        private readonly ServiceConfiguration _unit = new ServiceConfiguration
        {
            new EmployerAccountSiteManifest()
        };


        [Test]
        public void ItShouldReturnAChallengeObject()
        {
            var result = _unit.GetChallenge(SupportServiceResourceKey.EmployerAccountFinanceChallenge);
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItShouldThrowAnExceptionWhenTheKeyIsNotFound()
        {
            Assert.IsNull(_unit.GetChallenge(SupportServiceResourceKey.EmployerAccountTeam));
        }
    }
}