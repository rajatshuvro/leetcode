using Problems;
using Xunit;

namespace UnitTests
{
    public class SmallerCountTests
    {
        [Theory]
        [InlineData(new []{5,2,6,1}, new []{2,1,1,0})]
        [InlineData(new []{5,1,6,2}, new []{2,0,1,0})]
        public void CountSmallerTests(int[] nums, int[] expectedSmaller)
        {
            var smallerCounter = new SmallerCount();
            var counts = smallerCounter.CountSmaller(nums);
            
            Assert.Equal(expectedSmaller, counts);
        }
    }
}