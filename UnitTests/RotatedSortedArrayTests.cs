using RotatedSortedArraySearch;
using Xunit;

namespace UnitTests
{
    public class RotatedSortedArrayTests
    {
        [Fact]
        public void SearchForExistingElement()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 0, 0, 1, 1, 2, 0 };

            Assert.True(rotatedArray.Search(nums,2));
            
        }

        [Fact]
        public void NonExistingElement()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 1, 2, 1 };

            Assert.False(rotatedArray.Search(nums, 0));
            
        }

        [Fact]
        public void AllElementsAreSame()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 0, 0, 0, 0, 0 };
            Assert.True(rotatedArray.Search(nums,0));

            Assert.False(rotatedArray.Search(nums, 1));
            
        }

        [Fact]
        public void TestSearch()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 0, 0, 1, 2, 2, 5, 6 };
            Assert.True(rotatedArray.Search(nums, 0));
            Assert.False(rotatedArray.Search(nums, 3));
            
        }

        [Fact]
        public void MoreSearch()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 2, 5, 6, 0, 0, 1, 2 };
            Assert.True(rotatedArray.Search(nums, 0));

            Assert.False(rotatedArray.Search(nums, 3));
            Assert.False(rotatedArray.Search(nums, 4));
            Assert.True(rotatedArray.Search(nums, 6));
            Assert.True(rotatedArray.Search(nums, 1));
            
        }
    }
}