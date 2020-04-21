using Problems.StringProblems;
using Xunit;

namespace UnitTests.StringProblems
{
    public class LastSubStringTests
    {
        [Theory]
        [InlineData("abab", "bab")]
        [InlineData("leetcode", "tcode")]
        [InlineData("cacacb", "cb")]
        public void FindLexicographicallyLastSubstring(string s, string expected)
        {
            var lastSub = new LastSubString();
            Assert.Equal(expected, lastSub.LastSubstring(s));
        }
    }
}