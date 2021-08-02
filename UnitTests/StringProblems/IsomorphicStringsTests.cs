using Problems.StringProblems;
using Xunit;

namespace UnitTests.StringProblems
{
    public class IsomorphicStringsTests
    {
        [Theory]
        [InlineData("egg", "add", true)]
        [InlineData("foo", "bar", false)]
        [InlineData("paper", "title", true)]
        [InlineData("badc", "baba", false)]
        public void IsIsomorphicTests(string s, string t, bool expected)
        {
            var result = IsomorphicString.IsIsomorphic(s, t);
            Assert.Equal(expected, result);
        }
    }
}