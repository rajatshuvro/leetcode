using System;
using Problems.DynamicProgramming;
using Xunit;

namespace UnitTests.DynamicProgramming
{
    public class RangeSum2DTests
    {
        [Fact]
        public void Test1()
        {
            var matrix = new int[,] { {3, 0, 1, 4, 2},
                {5, 6, 3, 2, 1},
                {1, 2, 0, 1, 5},
                {4, 1, 0, 1, 7},
                {1, 0, 3, 0, 5}};

            var sol = new RangeSum2D(matrix);

            var rangeSum = sol.SumRegion(2, 1, 4, 3);
            Assert.Equal(8, rangeSum);
            
            rangeSum = sol.SumRegion(1, 1, 2, 2);
            Assert.Equal(11, rangeSum);
            
            rangeSum = sol.SumRegion(1, 2, 2, 4);
            Assert.Equal(12, rangeSum);
            
        }
    }
}