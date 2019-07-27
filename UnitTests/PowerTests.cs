using Problems;
using Xunit;

namespace UnitTests
{
    public class PowerTests
    {
        [Theory]
        [InlineData(4.5, 5, 1845.28125)]
        [InlineData(1.5, 15, 437.893890380859375)]
        public void BasicTheory(double x, int y, double result)
        {
            Assert.Equal(result, EfficientPower.Power(x,y));
        }
    }
}