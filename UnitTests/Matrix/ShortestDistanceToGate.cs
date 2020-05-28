using Problems.Matrix;
using Xunit;

namespace UnitTests.Matrix
{
    public class ShortestDistanceToGate
    {
        [Fact]
        public void Case_0()
        {
            var rooms = new[]
            {
                new []{int.MaxValue, -1, 0, int.MaxValue},
                new []{int.MaxValue, int.MaxValue, int.MaxValue, -1},
                new []{int.MaxValue, -1, int.MaxValue, -1},
                new []{0, -1, int.MaxValue, int.MaxValue}
            };

            var expected = new[]
            {
                new []{3,  -1,   0,   1},
                new []{2 ,  2 ,  1 , -1},
                new []{ 1 , -1 ,  2 , -1},
                new []{0 , -1 ,  3 ,  4}
            };
            
            var toGate = new ShortestDistanceToGates();
            toGate.WallsAndGates(rooms);
            
            Assert.Equal(expected, rooms);
        }
        
        //[[2147483647,0,2147483647,2147483647,0,2147483647,-1,2147483647]]
        [Fact]
        public void Case_5()
        {
            var rooms = new[]
            {
                new []{int.MaxValue, 0, int.MaxValue, int.MaxValue, 0, int.MaxValue, -1, int.MaxValue}
            };

            var expected = new[]
            {
                new []{1, 0, 1, 1, 0, 1, -1, int.MaxValue}
            };
            
            var toGate = new ShortestDistanceToGates();
            toGate.WallsAndGates(rooms);
            
            Assert.Equal(expected, rooms);
        }
        
    }
}