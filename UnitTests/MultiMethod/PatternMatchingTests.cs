using Problems.MultiMethod;
using Xunit;

namespace UnitTests.MultiMethod
{
    public class PatternMatchingTests
    {
        [Theory]
        [InlineData("", "a*", true)]
        [InlineData("a", "a", true)]
        [InlineData("aa", "a", false)]
        [InlineData("a", ".", true)]
        [InlineData("a", ".*", true)]
        [InlineData("aa", ".*", true)]
        [InlineData("abcd", "ab.d", true)]
        [InlineData("abcd", "ab.c", false)]
        [InlineData("abcd", "ab..", true)]
        [InlineData("abc", "ab*c", true)]
        [InlineData("abbc", "ab*c", true)]
        [InlineData("abbc", "ab.*c", false)]
        [InlineData("abbc", "ab.*", true)]
        [InlineData("abbc", "a.*c", true)]
        [InlineData("abbccd", "a.*.*d", true)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "mis*is*p*.", false)]
        public void RegExMatchingTests(string s, string p, bool result)
        {
            var pm = new PatternMatching();
            Assert.Equal(result, pm.IsMatch(s,p));
        }
    }
}