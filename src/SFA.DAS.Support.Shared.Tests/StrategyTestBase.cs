using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Moq;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using SFA.DAS.NLog.Logger;

namespace SFA.DAS.Support.Shared.Tests
{
    public abstract class TestBase<T> where T : class
    {
        protected T Unit;

        [SetUp]
        public virtual void Setup()
        {
            Arrange();
            Act();
        }

        protected virtual void Arrange()
        {
            Unit = Activator.CreateInstance<T>();
        }

        protected virtual void Act()
        {
        }
    }

    public abstract class StrategyTestBase<T> : TestBase<T> where T : class
    {
        protected HttpClient HttpClient;
        protected MockHttpMessageHandler MockHttpMessageHandler;
        protected Mock<ILog> MockLogger;
        protected Exception TestException = new Exception("A test exception");

        protected override void Arrange()
        {
            MockHttpMessageHandler = new MockHttpMessageHandler();

            HttpClient = new HttpClient(MockHttpMessageHandler);
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "value");
            MockLogger = new Mock<ILog>();
            Unit = Activator.CreateInstance(typeof(T), MockLogger.Object) as T;
        }
    }
}