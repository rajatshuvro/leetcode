using Problems.Matrix;
using Xunit;

namespace UnitTests.Matrix
{
    public class NumIslandsTests
    {
        [Fact]
        public void Case_0()
        {
            var grid = new char[4][];
            grid[0] = new[] {'0', '0', '0'};
            grid[1] = new[] {'0', '0', '0'};
            grid[2] = new[] {'0', '0', '0'};
            grid[3] = new[] {'0', '0', '0'}; 
            
            Assert.Equal(0, IslandMatrix.NumIslands(grid));
        }
        [Fact]
        public void Case_1()
        {
            var grid = new char[4][];
            grid[0] = new[] {'1', '1', '1', '1', '0'};
            grid[1] = new[] {'1', '1', '0', '1', '0'};
            grid[2] = new[] {'1', '1', '0', '0', '0'};
            grid[3] = new[] {'0', '0', '0', '0', '0'}; 
            
            Assert.Equal(1, IslandMatrix.NumIslands(grid));
        }
        
        [Fact]
        public void Case_2()
        {
            var grid = new char[4][];
            grid[0] = new[] {'1', '1', '0', '0', '0'};
            grid[1] = new[] {'1', '1', '0', '0', '0'};
            grid[2] = new[] {'0', '0', '1', '0', '0'};
            grid[3] = new[] {'0', '0', '0', '1', '1'}; 
            
            Assert.Equal(3, IslandMatrix.NumIslands(grid));
        }
    }
}