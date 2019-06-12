using Problems;
using Xunit;

namespace UnitTests
{
    public class MedianTests
    {
        [Fact]
        public void Median_odd_length()
        {
            Assert.Equal(5, MedianOfTwoSortedArrays.FindMedianSortedArray(new []{1,2,3,4,5,6,7,8,9}));
        }

        [Fact]
        public void Median_even_length()
        {
            Assert.Equal(5.5, MedianOfTwoSortedArrays.FindMedianSortedArray(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,10 }));
        }

        [Theory]
        [InlineData(new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, 5)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, 1)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10, 10)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, 0)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 15, 11)]
        public void Array_rank(int[] nums, int x, int rank)
        {
            Assert.Equal(rank, MedianOfTwoSortedArrays.GetSortedArrayRank(x, nums));
        }
    }
}