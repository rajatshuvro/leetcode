using Problems;
using Xunit;

namespace UnitTests
{
    public class MinPathSumTests
    {
        [Fact]
        public void Case0()
        {
            var grid = new int[1][];
            grid[0] = new[] {1, 2, 3};

            var pathSummer = new MinimumPathSum();
            Assert.Equal(6, pathSummer.MinPathSum(grid));
        }
        
        [Fact]
        public void Case1()
        {
            var grid = new int[2][];
            grid[0] = new[] {1, 2, 3};
            grid[1] = new[] {2, 1, 1};

            var pathSummer = new MinimumPathSum();
            Assert.Equal(5, pathSummer.MinPathSum(grid));
        }
        
        [Fact]
        public void Case2()
        {
            var grid = new int[2][];
            grid[0] = new[] {1, 1, 3};
            grid[1] = new[] {3, 1, 1};

            var pathSummer = new MinimumPathSum();
            Assert.Equal(4, pathSummer.MinPathSum(grid));
        }
        
        [Fact]
        public void Case3()
        {
            var grid = new int[3][];
            grid[0] = new[] {1, 3, 1};
            grid[1] = new[] {1, 5, 1};
            grid[2] = new[] {4, 2, 1};

            var pathSummer = new MinimumPathSum();
            Assert.Equal(7, pathSummer.MinPathSum(grid));
        }
    }
}