using Problems.ArrayProblems;
using Xunit;

namespace UnitTests.ArrayProblems
{
    public class MinSwapTests
    {
        [Theory]
        [InlineData(new[] {2,1}, 1)]
        [InlineData(new[] {1,2,3,4}, 0)]
        [InlineData(new[] {4, 3, 1, 2}, 3)]
        [InlineData(new[] {1, 3, 5, 2, 4, 6, 7}, 3)]
        [InlineData(new[] {7, 1, 3, 2, 4, 5, 6}, 5)]
        public void TestCases(int[] array, int swapCount)
        {
            Assert.Equal(swapCount, MinSwap.minimumSwaps(array));
        }
    }
}