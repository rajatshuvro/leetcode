using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class SurfaceAreaTests
    {
        [Fact]
        public void SingleBlockTest()
        {
            var grid = new int[1][];
            grid[0] = new[] {1};

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(6, surfaceAreaCalculator.SurfaceArea(grid));
        }

        [Fact]
        public void TwoBlocks_Stacked_Test()
        {
            var grid = new int[1][];
            grid[0] = new[] { 2 };

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(10, surfaceAreaCalculator.SurfaceArea(grid));
        }
        [Fact]
        public void TwoBlocks_side_adjacent_Test()
        {
            var grid = new int[1][];
            grid[0] = new[] { 1,1 };

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(10, surfaceAreaCalculator.SurfaceArea(grid));
        }
        [Fact]
        public void TwoPiles_adjacent_Test()
        {
            var grid = new int[1][];
            grid[0] = new[] { 2, 1 };

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(14, surfaceAreaCalculator.SurfaceArea(grid));
        }

        [Fact]
        public void TestCase_2()
        {
            var grid = new int[2][];
            grid[0] = new[] { 1,2 };
            grid[1] = new[] {3, 4};

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(34, surfaceAreaCalculator.SurfaceArea(grid));
        }
        [Fact]
        public void TestCase_3()
        {
            var grid = new int[2][];
            grid[0] = new[] { 1, 0 };
            grid[1] = new[] { 0, 2 };

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(16, surfaceAreaCalculator.SurfaceArea(grid));
        }
        [Fact]
        public void TestCase_4()
        {
            var grid = new int[3][];
            grid[0] = new[] { 1, 1, 1 };
            grid[1] = new[] { 1, 0, 1 };
            grid[2] = new[] {1, 1, 1};

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(32, surfaceAreaCalculator.SurfaceArea(grid));
        }
        [Fact]
        public void TestCase_5()
        {
            var grid = new int[3][];
            grid[0] = new[] { 2, 2, 2 };
            grid[1] = new[] { 2, 1, 2 };
            grid[2] = new[] { 2, 2, 2 };

            var surfaceAreaCalculator = new SurfaceAreaOfCubes();

            Assert.Equal(46, surfaceAreaCalculator.SurfaceArea(grid));
        }
    }
}