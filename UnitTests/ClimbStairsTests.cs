using Problems;
using Xunit;

namespace UnitTests
{
    public class ClimbStairsTests
    {
        [Fact]
        public void Case_0()
        {
            var climber = new ClimbingStairs();
            
            Assert.Equal(3, climber.ClimbStairs(3));
            Assert.Equal(5, climber.ClimbStairs(4));
            Assert.Equal(8, climber.ClimbStairs(5));
        }
    }
}