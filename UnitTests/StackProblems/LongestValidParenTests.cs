using Problems.StackProblems;
using Xunit;

namespace UnitTests.StackProblems
{
    public class LongestValidParenTests
    {
        [Theory]
        [InlineData("()", 2)]
        [InlineData("(()", 2)]
        [InlineData(")()())", 4)]
        [InlineData(")()(((())))(", 10)]
        [InlineData("((()))())", 8)]
        [InlineData(")(())(()()))(", 10)]
        [InlineData("()(((()(()))))", 14)]
        [InlineData(")(())))(())())", 6)]
        public void FindLongestValidParenthesis(string s, int maxLength)
        {
            var lvp= new LongestValidParenthesis();
            Assert.Equal(maxLength, lvp.LongestValidParentheses(s));
        }
    }
}