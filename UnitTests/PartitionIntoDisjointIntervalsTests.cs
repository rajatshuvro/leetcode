using Problems;
using Xunit;

namespace UnitTests
{
    public class PartitionIntoDisjointIntervalsTests
    {
        [Theory]
        [InlineData(new []{ 5, 0, 3, 8, 6 }, 3)]
        [InlineData(new[] { 1, 1, 1, 0, 6, 12 }, 4)]
        [InlineData(new []{90, 47, 69, 10, 43, 92, 31, 73, 61, 97}, 9)]
        public void PartitionTest(int[] array, int leftPartitionLength)
        {
            var partitioner = new PartitionIntoDisjointIntervals();

            Assert.Equal(leftPartitionLength, partitioner.PartitionDisjoint(array));
        }
    }
}