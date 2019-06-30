using Xunit;
using ReorderedPowerOfTwo = Problems.ReorderedPowerOfTwo;

namespace UnitTests
{
    public class ReorderedPowerOfTwoTests
    {
        [Theory]
        [InlineData(16, true)]
        [InlineData(46, true)]
        [InlineData(24, false)]
        public void IsReorderedPowerOfTwo(int input, bool expectedResult)
        {
            var s = new ReorderedPowerOfTwo();
            Assert.Equal(expectedResult, s.ReorderedPowerOf2(input));
        }
    }
}