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
            var intervals = new[]
            {
                new Interval(1,4),
                new Interval(3,6),
                new Interval(5,10),
                new Interval(8,10),
            };
            var costs = new[] { 4, 2, 6, 2};

            var expected = new[]
            {
                new Interval(1,4),
                new Interval(5,10),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetMinCostIntervalSet(nums, intervals, costs);
            
            Assert.Equal(expected, observed);
        }
    }
}