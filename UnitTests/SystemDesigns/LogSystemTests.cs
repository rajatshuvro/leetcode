using System.Linq;
using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class LogSystemTests
    {
        [Theory]
        [InlineData("2017:01:01:20:30:40", "Year",  "2017:12:31:23:59:59")]
        [InlineData("2017:01:01:20:30:40", "Month",  "2017:01:31:23:59:59")]
        [InlineData("2017:01:01:22:59:59", "Day",  "2017:01:01:23:59:59")]
        [InlineData("2017:01:01:22:30:59", "Hour",  "2017:01:01:22:59:59")]
        [InlineData("2017:01:01:20:30:40", "Minute",  "2017:01:01:20:30:59")]
        [InlineData("2017:01:01:20:30:40", "Second",  "2017:01:01:20:30:40")]
        public void RoundUpTimeTests(string time, string granularity, string expected)
        {
            Assert.Equal(expected, LogSystemUtilities.GetRoundUpTime(time, granularity));
        }
        
        [Theory]
        [InlineData("2017:01:01:20:30:40", "Year",  "2017:00:00:00:00:00")]
        [InlineData("2017:01:01:20:30:40", "Month",  "2017:01:00:00:00:00")]
        [InlineData("2017:01:01:22:59:59", "Day",  "2017:01:01:00:00:00")]
        [InlineData("2017:01:01:22:30:59", "Hour",  "2017:01:01:22:00:00")]
        [InlineData("2017:01:01:20:30:40", "Minute",  "2017:01:01:20:30:00")]
        [InlineData("2017:01:01:20:30:40", "Second",  "2017:01:01:20:30:40")]
        public void RoundDownTimeTests(string time, string granularity, string expected)
        {
            Assert.Equal(expected, LogSystemUtilities.GetRoundDownTime(time, granularity));
        }

        [Fact]
        public void Case_0()
        {
            var ls = new LogSystem();
            ls.Put(1, "2017:01:01:23:59:59");
            ls.Put(2, "2017:01:01:22:59:59");
            ls.Put(3, "2016:01:01:00:00:00");

            var result = ls.Retrieve("2016:01:01:01:01:01", "2017:01:01:23:00:00", "Year").ToList();
            result.Sort();
            Assert.Equal(new []{1,2,3}, result);

            result = ls.Retrieve("2016:01:01:01:01:01", "2017:01:01:23:00:00", "Hour").ToList();
            result.Sort();
            Assert.Equal(new []{1,2}, result);
        }
    }
}