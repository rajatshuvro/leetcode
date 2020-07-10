using System.Collections.Generic;
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
            var intervals = new List<Interval<int>>()
            {
                new Interval<int>(1,4,4),
                new Interval<int>(3,6,2),
                new Interval<int>(5,10,6),
                new Interval<int>(8,10,2),
            };
            
            var expected = new[]
            {
                new Interval<int>(1,4, 4),
                new Interval<int>(5,10,  6),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed);
        }
    }
}