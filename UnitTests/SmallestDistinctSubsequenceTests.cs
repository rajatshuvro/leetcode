using Problems;
using Xunit;

namespace UnitTests
{
    public class SmallestDistinctSubsequenceTests
    {
        [Theory]
        [InlineData("cdadabcc", "adbc")]
        [InlineData("abcd", "abcd")]
        [InlineData("ecbacba", "eacb")]
        [InlineData("leetcode", "letcod")]
        public void Examples(string text, string result)
        {
            var sol = new SmallestDistinctSubsequence();
            Assert.Equal(result, sol.SmallestSubsequence(text));
        }
    }
}