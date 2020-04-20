using Problems.Heap;
using Xunit;

namespace UnitTests.Heap
{
    public class IpoTests
    {
        [Theory]
        [InlineData(2, 0, new[] {1, 2, 3}, new[] {0, 1, 1}, 4)]
        public void GetMaximizedCapital(int k, int initialCapital, int[] profits, int[] capitals, int expectedCapital)
        {
            var ipo = new IPO();
            Assert.Equal(expectedCapital, ipo.FindMaximizedCapital(k, initialCapital, profits, capitals));
        }
    }
}