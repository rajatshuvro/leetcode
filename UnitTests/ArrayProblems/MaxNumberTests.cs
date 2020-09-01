using Problems.ArrayProblems;
using Xunit;

namespace UnitTests.ArrayProblems
{
    public class MaxNumberTests
    {
        [Fact]
        public void Case_0()
        {
            var queries = new[]
            {
                new []{1, 5, 3},
                new []{4, 8, 7},
                new []{6, 9, 1},
            };
            
            Assert.Equal(10, MaxNumber.arrayManipulation(10, queries));
        }
        
        [Fact]
        public void Case_1()
        {
            var queries = new[]
            {
                new []{1, 2, 100},
                new []{2, 5, 100},
                new []{3, 4, 100},
            };
            
            Assert.Equal(200, MaxNumber.arrayManipulation(5, queries));
        }
    }
}