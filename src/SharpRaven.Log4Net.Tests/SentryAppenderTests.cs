using System;
using log4net.Core;
using log4net.Repository;
using Moq;
using SharpRaven.Data;
using Xunit;

namespace SharpRaven.Log4Net.Core.Tests
{
    public class SentryAppenderTests
    {
        #region Derived test class
        /// <summary>Derived SentryAppender that gives us access to the raven client so that we can test</summary>
        public class SentryAppenderUnderTest : SentryAppender
        {
            public void SetRavenClient(IRavenClient ravenClient)
            {
                RavenClient = ravenClient;
            }

            public void DoAppendUnderTest(LoggingEvent loggingEvent)
            {
                DoAppend(loggingEvent);
            }
        }
        #endregion

        private readonly Mock<IRavenClient> _ravenClientMock;
        private readonly Mock<ILoggerRepository> _loggerRepositoryMock;
        private readonly SentryAppenderUnderTest _sentryAppender;

        public SentryAppenderTests()
        {
            _ravenClientMock = new Mock<IRavenClient>();
            _loggerRepositoryMock = new Mock<ILoggerRepository>();

            _sentryAppender = new SentryAppenderUnderTest();
            _sentryAppender.SetRavenClient(_ravenClientMock.Object);
        }

        [Fact]
        public void Append_WithExceptionAndMessage()
        {
            var exception = new Exception("ExceptionAndMessage");

            _sentryAppender.DoAppendUnderTest(CreateLoggingEvent("Custom message", exception));

            _ravenClientMock.Verify(rc => rc.Capture(It.Is<SentryEvent>(w => w.Message == "Custom message")));
        }

        [Fact]
        public void Append_WithJustException()
        {
            var exception = new Exception("JustException");

            _sentryAppender.DoAppendUnderTest(CreateLoggingEvent(exception));

            _ravenClientMock.Verify(rc => rc.Capture(It.Is<SentryEvent>(w => object.ReferenceEquals(w.Exception, exception))));
        }


        private LoggingEvent CreateLoggingEvent(object message, Exception exception = null)
        {
            return new LoggingEvent(typeof(SentryAppenderTests),
                _loggerRepositoryMock.Object,
                "test",
                Level.Error,
                message,
                exception);
        }
    }
}
