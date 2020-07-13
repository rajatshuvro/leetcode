using Problems;
using Xunit;

namespace UnitTests
{
    public class ReachablePointsTests
    {
        [Theory]
        [InlineData(1,1,3,5,true)]
        [InlineData(9,5,12,8,false)]
        [InlineData(3,7,3,4,false)]
        public void Reachability(int sx, int sy, int tx, int ty, bool isReachable)
        {
            var reachable = new ReachablePoints();
            Assert.Equal(isReachable, reachable.ReachingPoints(sx, sy, tx, ty));
        }
    }
}