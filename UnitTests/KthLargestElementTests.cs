using Problems;
using Xunit;

namespace UnitTests
{
    public class KthLargestElementTests
    {
        [Theory]
        [InlineData(new[] { -1 , 0 , 2}, 2, 0)]
        [InlineData(new []{ 3, 2, 1, 5, 6, 4 }, 2, 5)]
        [InlineData(new [] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 4)]
        public void FindingKthElement(int[] nums, int k, int expectedNum)
        {
            var kthFinder = new KthLargestElement();

            var kthElement = kthFinder.FindKthLargest(nums, k);
            Assert.Equal(expectedNum, kthElement);
        }
    }
}