using Problems.Matrix;
using UnitTests.Utilities;
using Xunit;

namespace UnitTests.Matrix
{
    public class RottingOrangesTests
    {
        [Theory]
        [InlineData("[[2,1,1],[1,1,0],[0,1,1]]", 4)]
        [InlineData("[[2,1,1],[0,1,1],[1,0,1]]", -1)]
        public void CountingMinutes(string gridString, int time)
        {
            var grid = Deserializer.GetGrid(gridString);
            var rottingOranges = new RottenOranges();
            
            Assert.Equal(time, rottingOranges.OrangesRotting(grid));
        }
    }
}