using Problems.DynamicProgramming;
using Xunit;

namespace UnitTests.DynamicProgramming
{
    public class NumRollsToTargetTests
    {
        [Theory]
        [InlineData(1,2,3,0)]
        [InlineData(1,6,3,1)]
        [InlineData(2, 6, 7, 6)]
        [InlineData(2, 5, 10, 1)]
        [InlineData(30, 30, 500, 222616187)]
        public void CountNumWays(int d, int f, int target, int ways)
        {
            var dice = new NumDiceRolls();
            Assert.Equal(ways, dice.NumRollsToTarget(d, f, target));
        }
    }
}