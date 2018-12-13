using Algorithms;
using Xunit;

namespace UnitTests
{
    public class ArrayUtilsTests
    {
        [Fact]
        public void Partition_median()
        {
            var array = new[] { 4,2,7,8,9,1,5};

            var pivotIndex = ArrayUtils.Partition(array, 0, array.Length - 1, 6);

            Assert.Equal(3, pivotIndex);
        }

        [Fact]
        public void Partition_min()
        {
            var array = new[] { 4, 2, 7, 8, 9, 1, 5 };

            var pivotIndex = ArrayUtils.Partition(array, 0, array.Length - 1, 5);

            Assert.Equal(0, pivotIndex);
        }

        [Fact]
        public void Partition_max()
        {
            var array = new[] { 4, 2, 7, 8, 9, 1, 5 };

            var pivotIndex = ArrayUtils.Partition(array, 0, array.Length - 1, 4);

            Assert.Equal(array.Length-1, pivotIndex);
        }
    }
}