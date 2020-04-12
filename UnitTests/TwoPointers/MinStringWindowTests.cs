using Problems.TwoPointers;
using Xunit;

namespace UnitTests.TwoPointers
{
    public class MinStringWindowTests
    {
        [Theory]
        [InlineData("ADOBECODEBANC", "ABC", "BANC")]
        [InlineData("ADOBECODEBANC", "ABCZ", "")]
        [InlineData("a", "aa", "")]
        public void MinWindow(string s, string t, string window)
        {
            var minWindowFinder = new MinStringWindow();
            Assert.Equal(window, minWindowFinder.MinWindow(s,t));
        }
    }
}