using System;
using log4net;
using Xunit;

namespace SharpRaven.Log4Net.Core.Tests
{
    public class Log4NetTests
    {
        private readonly ILog _log;

        private static void DivideByZero(int stackFrames = 10)
        {
            if (stackFrames == 0)
            {
                var a = 0;
                var b = 1 / a;
            }
            else
                DivideByZero(--stackFrames);
        }


        public Log4NetTests()
        {
            _log = LogManager.GetLogger(GetType());
        }

        [Fact]
        [Trait("Debug", "Only run this test if you're going to check for the logged error in Sentry or debug the SentryAppender.")]
        public void ErrorFormatWithMessage_MessageIsLogged()
        {
            _log.ErrorFormat("This is a {0} message.", "test");
        }


        [Fact]
        [Trait("Debug", "Only run this test if you're going to check for the logged error in Sentry or debug the SentryAppender.")]
        public void ErrorWithException_ExceptionIsLogged()
        {
            var exception = Assert.Throws<DivideByZeroException>(() => DivideByZero());
            _log.Error("This is a test exception", exception);
        }

        [Fact]
        [Trait("Debug", "Only run this test if you're going to check for the logged error in Sentry or debug the SentryAppender.")]
        public void ErrorWithMessage_MessageIsLogged()
        {
            _log.Error("This is a test message.");
        }
    }
}
