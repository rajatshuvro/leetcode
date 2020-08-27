using Problems.ArrayProblems;
using Xunit;

namespace UnitTests.ArrayProblems
{
    public class NewYearChaosTests
    {
        [Theory]
        [InlineData(new []{2, 1}, 1)]
        [InlineData(new []{3, 2, 1}, 3)]
        [InlineData(new []{4, 3, 2, 1}, -1)]
        [InlineData(new []{2, 1, 5, 3, 4}, 3)]
        [InlineData(new []{2, 5, 1, 3, 4}, -1)]
        public void TestCases(int[] A, int expected)
        {
            var count = NewYearChaos.GetBribeCount(A);
            Assert.Equal(expected, count);
        }
    }
}