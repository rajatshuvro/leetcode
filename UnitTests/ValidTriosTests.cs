using System;
using Problems;
using Xunit;

namespace UnitTests
{
    public class ValidTriosTests
    {
        [Fact]
        public void Basic()
        {
            var triangleCounter = new ValidTriangleCounter();

            Assert.Equal(3, triangleCounter.TriangleNumber(new []{ 2, 2, 3, 4 }));
        }

        [Fact]
        public void Failed_case_1()
        {
            var triangleCounter = new ValidTriangleCounter();

            Assert.Equal(7, triangleCounter.TriangleNumber(new[] { 1, 2, 3, 4, 5, 6}));
        }

        [Fact]
        public void Failed_case_2()
        {
            var triangleCounter = new ValidTriangleCounter();

            Assert.Equal(14, triangleCounter.TriangleNumber(new[] {58, 97, 2, 8, 2, 55, 14, 54, 2 }));
        }

        [Fact]
        public void BinSearchTest()
        {
            var nums = new int[] {1,2,2,2,3,3,45,56,66 };
            var j = Array.BinarySearch(nums, 2, 4, 40);
            if (j < 0) j = ~j;

            Assert.Equal(6, j);
        }
    }
}