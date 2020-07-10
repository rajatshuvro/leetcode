using DataStructures;
using Problems.DynamicProgramming;
using Xunit;

namespace UnitTests.DynamicProgramming
{
    public class IntervalCoverTests
    {
        [Fact]
        public void Case_0()
        {
            var nums = new[] { 1,2,3,4,5,6,7,8,9,10};
            var starts = new[] {1,3,5,8 };
            var ends = new[] {4,6,10,10};
            var costs = new[] { 4, 2, 6, 2};

            var expected = new[]
            {
                new Interval(1,4),
                new Interval(5,10),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, starts, ends, costs);
            
            Assert.Equal(expected, observed);
        }
    }
}