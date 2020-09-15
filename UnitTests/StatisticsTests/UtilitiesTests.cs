using Statistics;
using Xunit;

namespace UnitTests.StatisticsTests
{
    public class UtilitiesTests
    {
        [Theory]
        [InlineData(new [] {1}, 1)]
        [InlineData(new [] {1,2,3,4,5,6,7,8}, 4.5)]
        [InlineData(new [] {1,2,3,4,5,6,7}, 4)]
        public void MedianTests(int[] nums, double median)
        {
            Assert.Equal(median, StatUtilities.GetMedian(nums));
        }
        
        [Theory]
        [InlineData(new [] {1},0,0, 1)]
        [InlineData(new [] {1,2,3,4,5,6,7,8},3,7, 6)]
        [InlineData(new [] {1,2,3,4,5,6,7},1,5, 4)]
        public void MedianOfSubArrayTests(int[] nums, int i, int j, double median)
        {
            Assert.Equal(median, StatUtilities.GetMedian(nums,i,j));
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
            Assert.Equal((q1, q2, q3), StatUtilities.GetQuartiles(nums));
        }

        [Theory]
        [InlineData(-1, -0.8427006897475899)]
        [InlineData(1, 0.8427006897475899)]
        [InlineData(-2, -0.9953221395812188)]
        [InlineData(2, 0.9953221395812188)]
        public void ErrorFunctionTests(double x, double expected)
        {
            Assert.Equal(expected, StatUtilities.ErrorFunction(x));
        }

        [Theory]
        [InlineData(10, 5, 0.5, 0.24609375)]
        [InlineData(10, 8, 0.5, 0.0439453125)]
        public void BinomialExactTest(int n, int k, double p, double expected)
        {
            Assert.Equal(expected, BinomialDistribution.Probability(n, k, p));
        }
        
        [Theory]
        [InlineData(10, 5, 0.5, 0.623046875)]
        [InlineData(6, 3, 1.09/2.09, 0.6957033161509107)]
        [InlineData(10, 2, 0.12, 0.3417249657959586)]
        public void BinomialAtLeastTest(int n, int k, double p, double expected)
        {
            Assert.Equal(expected, BinomialDistribution.AtLeastProbability(n, k, p));
        }
        
        [Theory]
        [InlineData(10, 2, 0.12, 0.8913182062780246)]
        public void BinomialAtMostTest(int n, int k, double p, double expected)
        {
            Assert.Equal(expected, BinomialDistribution.AtMostProbability(n, k, p));
        }
    }
}