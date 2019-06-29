using Algorithms;
using Xunit;

namespace UnitTests
{
    public class ArrayUtilsTests
    {
        [Theory]
        [InlineData(new[] { 4, 2, 7, 8, 9, 1, 5 }, 6, 3)]
        [InlineData(new[] { 4, 2, 7, 8, 9, 1, 5 }, 5, 0)]
        [InlineData(new[] { 4, 2, 7, 8, 9, 1, 5 }, 4, 6)]
        [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 2, 4)]
        [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 7, 7)]
        [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 5, 5)]
        public void PartitionTester(int[] array, int index, int expectedResult)
        {
            var pivotIndex = ArrayUtils.Partition(array, 0, array.Length - 1, index);
            Assert.Equal(expectedResult, pivotIndex);
        }

        [Theory]
        [InlineData(new[] { 4, 2, 7, 8, 9, 1, 5 }, 0, 3, 0)]
        [InlineData(new[] { 4, 2, 7, 8, 9, 1, 5 }, 2, 6, 6)]
        [InlineData(new[] { 4, 2, 7, 8, 9, 1, 5 }, 4, 6, 4)]
        [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 0, 5, 4)]
        [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 4, 8, 7)]
        [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 1, 7, 3)]
        public void SubArrayMidPartitionTester(int[] array, int start, int end,  int expectedResult)
        {
            var index = (start + end) / 2;
            var pivotIndex = ArrayUtils.Partition(array, start, end, index);
            Assert.Equal(expectedResult, pivotIndex);
        }

        [Theory]
        [InlineData(new[] { 3, 2, 1, 5, 6, 4 }, 4, 5)]
        [InlineData(new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 }, 6, 5)]
        public void FindingKthElement(int[] nums, int k, int expectedNum)
        {
            var kthElement = ArrayUtils.FindKthElement(nums,0, nums.Length-1, k);
            Assert.Equal(expectedNum, kthElement);
        }

    }
}