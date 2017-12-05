using log4net.Core;
using SharpRaven.Data;
using Xunit;

namespace SharpRaven.Log4Net.Core.Tests
{

    public class ErrorLevelTests
    {
        [Fact]
        public void Translate_Debug_ReturnsDebug()
        {
            var level = SentryAppender.Translate(Level.Debug);
            Assert.Equal(ErrorLevel.Debug, level);
        }


        [Fact]
        public void Translate_Error_ReturnsError()
        {
            var level = SentryAppender.Translate(Level.Error);
            Assert.Equal(ErrorLevel.Error, level);
        }


        [Fact]
        public void Translate_Fatal_ReturnsFatal()
        {
            var level = SentryAppender.Translate(Level.Fatal);
            Assert.Equal(ErrorLevel.Fatal, level);
        }


        [Fact]
        public void Translate_Info_ReturnsInfo()
        {
            var level = SentryAppender.Translate(Level.Info);
            Assert.Equal(ErrorLevel.Info, level);
        }


        [Fact]
        public void Translate_Notice_ReturnsInfo()
        {
            var level = SentryAppender.Translate(Level.Notice);
            Assert.Equal(ErrorLevel.Info, level);
        }


        [Fact]
        public void Translate_UnknownLevel_ReturnsError()
        {
            var level = SentryAppender.Translate(Level.Alert);
            Assert.Equal(ErrorLevel.Error, level);

        }

        [Fact]
        public void Translate_Warn_ReturnsWarning()
        {
            var level = SentryAppender.Translate(Level.Warn);
            Assert.Equal(ErrorLevel.Warning, level);
        }
    }
}
