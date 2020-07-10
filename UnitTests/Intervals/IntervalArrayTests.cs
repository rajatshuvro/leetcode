using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace UnitTests.Intervals
{
    public class IntervalArrayTests
    {
        private List<Interval<int>> _intervals_1= new List<Interval<int>>()
        {
            new Interval<int>(1,5,3),
            new Interval<int>(3,5,1),
            new Interval<int>(2,7,6),
            new Interval<int>(5,12,4),
            new Interval<int>(6,11,7),
            new Interval<int>(2,9,6),
            new Interval<int>(15,19,2),
        };
        
        private List<Interval<int>> _intervals_2= new List<Interval<int>>()
        {
            new Interval<int>(0,3,3),
            new Interval<int>(5,8,1),
            new Interval<int>(6,10,6),
            new Interval<int>(8,9,4),
            new Interval<int>(15,23,7),
            new Interval<int>(16,21,6),
            new Interval<int>(17,19,2),
            new Interval<int>(19,20,5),
            new Interval<int>(25,30,4),
            new Interval<int>(26,26,1),
        };

        [Theory]
        [InlineData(6,7,1, true)]
        [InlineData(13,14,1, false)]
        [InlineData(-1,0,1, false)]
        public void OverlapAny_case0(int start, int end, int value, bool overlaps)
        {
            var iArray = new IntervalArray<int>(_intervals_1);

            Assert.Equal(overlaps, iArray.OverlapsAny(start, end));
        }

        [Fact]
        public void GetAllOverlapping_0()
        {
            var iArray = new IntervalArray<int>(_intervals_1);
            
            Assert.Equal(4, iArray.GetOverlappingIntervals(2,3).Count);
            Assert.Single(iArray.GetOverlappingIntervals(12,13));
            
        }
        [Fact]
        public void GetAllOverlapping_1()
        {
            var iArray = new IntervalArray<int>(_intervals_2);
            
            Assert.Equal(3, iArray.GetOverlappingIntervals(8,8).Count);
            Assert.Single(iArray.GetOverlappingIntervals(27,32));
            Assert.Null(iArray.GetOverlappingIntervals(11,14));
            Assert.Null(iArray.GetOverlappingIntervals(31,34));
            Assert.Equal(3, iArray.GetOverlappingIntervals(20,23).Count);
            
        }
    }
}