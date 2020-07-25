using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class LoggerTests
    {
        [Fact]
        public void Case_0()
        {
            var logger = new Logger();
            Assert.True(logger.ShouldPrintMessage(1, "foo"));
            Assert.True(logger.ShouldPrintMessage(2,"bar"));
            Assert.False(logger.ShouldPrintMessage(3,"foo"));
            Assert.False(logger.ShouldPrintMessage(8,"bar"));
            Assert.False(logger.ShouldPrintMessage(10,"foo"));
            Assert.True(logger.ShouldPrintMessage(11,"foo"));
        }
    }
}