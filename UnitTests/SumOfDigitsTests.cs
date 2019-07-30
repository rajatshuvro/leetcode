using Problems;
using Xunit;

namespace UnitTests
{
    public class SumOfDigitsTests
    {
        [Theory]
        [InlineData(123, 6)]
        [InlineData(145783, 28)]
        [InlineData(3_798_145_783, 55)]
        public void TestUints(uint x, uint sum)
        {
            var digitAdder = new SumOfDigits();

            Assert.Equal(sum, digitAdder.EfficientSum(x));
        }
    }
}