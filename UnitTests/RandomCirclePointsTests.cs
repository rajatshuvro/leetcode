using Problems;
using Xunit;

namespace UnitTests
{
    public class RandomCirclePointsTests
    {
        [Theory]
        //[InlineData(1,0,0)]
        [InlineData(10, 5.0, -7.50)]
        public void ArePointsInCircle(double radius, double xCenter, double yCenter)
        {
            var sol = new RandomPointsInCircle(radius, xCenter, yCenter);

            for (int i = 0; i < 100; i++)
            {
                var xy = sol.RandPoint();
                var radiusSquare = radius * radius;
                var xSquare = (xy[0]- xCenter) * (xy[0] - xCenter);
                var ySquare = (xy[1] - yCenter) * (xy[1] - yCenter);
                Assert.True(radiusSquare.CompareTo(xSquare+ySquare) > 0);
            }
        }
    }
}