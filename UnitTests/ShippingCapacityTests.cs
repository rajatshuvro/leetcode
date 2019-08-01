using Problems;
using Xunit;

namespace UnitTests
{
    public class ShippingCapacityTests
    {
        [Theory]
        [InlineData(new[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, 15)]
        public void TestCases(int[] weights, int days, int capacity)
        {
            var shippingCapacity = new ShippingCapacity();
            Assert.Equal(capacity, shippingCapacity.ShipWithinDays(weights, days));
        }
    }
}