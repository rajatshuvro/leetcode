using Problems.StringProblems;
using Xunit;

namespace UnitTests.StringProblems
{
    public class CoordinateCombinationsTests
    {
        [Fact]
        public void Test1()
        {
            var cc = new CoordinateCombinations();
            var combinations = cc.AmbiguousCoordinates("(123)");
            
            Assert.Equal(4, combinations.Count);
        }
        
        [Fact]
        public void Test2()
        {
            var cc = new CoordinateCombinations();
            var combinations = cc.AmbiguousCoordinates("(00011)");
            
            Assert.Equal(2, combinations.Count);
        }
        [Fact]
        public void Test3()
        {
            var cc = new CoordinateCombinations();
            var combinations = cc.AmbiguousCoordinates("(0123)");
            
            Assert.Equal(6, combinations.Count);
        }
        [Fact]
        public void Test4()
        {
            var cc = new CoordinateCombinations();
            var combinations = cc.AmbiguousCoordinates("(100)");
            
            Assert.Equal(1, combinations.Count);
        }

    }
}