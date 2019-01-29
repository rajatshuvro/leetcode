using Problems;
using Xunit;

namespace UnitTests
{
    public class ClimbingStairsTests
    {
        [Theory]
        [InlineData(new int[] { 10, 15, 20 }, 15)]
        [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
        public void Test_1(int[] costs, int expectedResult)
        {
            var sol = new MinCostStairs();

            Assert.Equal(expectedResult, sol.MinCostClimbingStairs(costs));
        }
    }
}