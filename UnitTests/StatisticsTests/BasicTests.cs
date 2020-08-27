using Xunit;

namespace UnitTests.StatisticsTests
{
    public class BasicTests
    {
        [Theory]
        [InlineData(new [] {1}, 1)]
        [InlineData(new [] {1,2,3,4,5,6,7,8}, 4.5)]
        [InlineData(new [] {1,2,3,4,5,6,7}, 4)]
        public void MedianTests(int[] nums, double median)
        {
            Assert.Equal(median, Statistics.StatUtilities.GetMedian(nums));
        }
        
        [Theory]
        [InlineData(new [] {1},0,0, 1)]
        [InlineData(new [] {1,2,3,4,5,6,7,8},3,7, 6)]
        [InlineData(new [] {1,2,3,4,5,6,7},1,5, 4)]
        public void MedianOfSubArrayTests(int[] nums, int i, int j, double median)
        {
            Assert.Equal(median, Statistics.StatUtilities.GetMedian(nums,i,j));
        }

        [Theory]
        [InlineData(new[] {1,2}, 1,1.5,2)]
        [InlineData(new[] {1,2,3}, 1,2,3)]
        [InlineData(new[] {1,2,3,4}, 1.5,2.5,3.5)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7, 8},  2.5,4.5, 6.5)]
        [InlineData(new[] {1, 2, 3, 4, 5, 6, 7},  2,4, 6)]
        [InlineData(new[] {3,5,7,8,12,13,14,18,21}, 6, 12, 16)]
        public void QuartileTests(int[] nums, double q1, double q2, double q3)
        {
            Assert.Equal((q1, q2, q3), Statistics.StatUtilities.GetQuartiles(nums));
        }
    }
}