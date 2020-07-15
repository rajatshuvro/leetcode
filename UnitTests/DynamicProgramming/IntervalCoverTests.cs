using System.Collections.Generic;
using System.Linq;
using DataStructures;
using Problems.DynamicProgramming;
using Xunit;

namespace UnitTests.DynamicProgramming
{
    public class IntervalCoverTests
    {
        [Fact]
        public void TwoIntervals()
        {
            var nums = new[] { 9,10};
            var intervals = new Interval<int>[]
            {
                new Interval<int>(1,10, 10),
                new Interval<int>(9,16,7)
            };
            var expected = new[]
            {
                new Interval<int>(9,16, 7),
            };
            
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed.set);
        }
        
        [Fact]
        public void UseSmallIntervals()
        {
            var nums = new[] {5,7, 19,20};
            var intervals = new[]
            {
                new Interval<int>(1,8, 8),
                new Interval<int>(5,20, 15),
                new Interval<int>(16,21, 5)
            };
            
            var expected = new[]
            {
                new Interval<int>(1,8, 8),
                new Interval<int>(16,21, 5)
            };
            
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed.set);
        }
        
        [Fact]
        public void StackedIntervals()
        {
            var intervals = new[]
            {
                new Interval<int>(1,2, 3),
                new Interval<int>(1,3, 3),
                new Interval<int>(1,6, 6),
                new Interval<int>(1,7, 6),
                new Interval<int>(1,10, 10)
            };
            var intervalCover = new IntervalCover();
            
            var observed = intervalCover.GetOptimalCover(new []{2}, intervals);
            Assert.Equal(new[] {intervals[0]}, observed.set);
            
            observed = intervalCover.GetOptimalCover(new []{2,5}, intervals);
            Assert.Equal(new[] {intervals[2]}, observed.set);

            observed = intervalCover.GetOptimalCover(new []{2,7}, intervals);
            Assert.Equal(new[] {intervals[3]}, observed.set);

            observed = intervalCover.GetOptimalCover(new []{2,5,9}, intervals);
            Assert.Equal(new[] {intervals[4]}, observed.set);
        }
        
        [Fact]
        public void StackedSmallAndLarge()
        {
            var intervals = new[]
            {
                new Interval<int>(1,2, 2),
                new Interval<int>(4,5, 2),
                new Interval<int>(1,6, 6),
                new Interval<int>(6,7, 2),
                new Interval<int>(9,10, 2),
                new Interval<int>(1,10, 10)
            };
            var intervalCover = new IntervalCover();
            
            var expected = new[]
            {
                new Interval<int>(1,2, 2),
                new Interval<int>(4,5, 2),
                new Interval<int>(9,10, 2),
            };

            var observed = intervalCover.GetOptimalCover(new []{2,5,9}, intervals);
            Assert.Equal(expected, observed.set);
            
        }

        [Fact]
        public void Case_0()
        {
            var nums = new[] { 1,2,3,4,5,6,7,8,9,10};
            var intervals = new Interval<int>[]
            {
                new Interval<int>(1,4,6),
                new Interval<int>(3,6,2),
                new Interval<int>(5,10,6),
                new Interval<int>(8,10,2),
            };
            var costs = new[] {4, 2, 6, 2};
            var expected = new[]
            {
                new Interval<int>(1,4,6),
                new Interval<int>(5,10,6),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed.set);
        }
        
        [Fact]
        public void Case_1()
        {
            var nums = Enumerable.Range(1,300).ToList();
            var intervals = new Interval<int>[]
            {
                new Interval<int>(1,100,100),
                new Interval<int>(201,300,100),
                new Interval<int>(101,200, 100),
                new Interval<int>(10,30,20),
                new Interval<int>(81,120, 40),
                new Interval<int>(150,250, 100),
                new Interval<int>(181,220, 40),
            };
            
            var expected = new[]
            {
                new Interval<int>(1,100,100),
                new Interval<int>(101,200, 100),
                new Interval<int>(201,300, 100),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed.set);
            
        }
        
        [Fact]
        public void Case_2()
        {
            var nums = Enumerable.Range(15,10).ToList();
            var intervals = new Interval<int>[]
            {
                new Interval<int>(1,100,100),
                new Interval<int>(201,300,100),
                new Interval<int>(101,200, 100),
                new Interval<int>(10,30,20),
                new Interval<int>(81,120, 40),
                new Interval<int>(150,250, 100),
                new Interval<int>(181,220, 40),
            };
            var expected = new[]
            {
                new Interval<int>(10,30, 20),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed.set);
            
        }
        
        [Fact]
        public void Case_3()
        {
            var nums = Enumerable.Range(85,100).ToList();
            var intervals = new Interval<int>[]
            {
                new Interval<int>(1,100,100),
                new Interval<int>(201,300,100),
                new Interval<int>(101,200, 100),
                new Interval<int>(10,30,20),
                new Interval<int>(81,120, 40),
                new Interval<int>(150,250, 100),
                new Interval<int>(181,220, 40),
            };
            
            var expected = new[]
            {
                new Interval<int>(81,120,40),
                new Interval<int>(101,200,100),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed.set);
            
        }
        
        [Fact]
        public void Case_4()
        {
            var nums = Enumerable.Range(85, 20).ToList();
            nums.AddRange(Enumerable.Range(155, 90));
            
            var intervals = new Interval<int>[]
            {
                new Interval<int>(1,100,100),
                new Interval<int>(201,300,100),
                new Interval<int>(101,200, 100),
                new Interval<int>(10,30,20),
                new Interval<int>(81,120, 40),
                new Interval<int>(150,250, 100),
                new Interval<int>(181,220, 40),
            };
            
            var expected = new[]
            {
                new Interval<int>(81,120, 40),
                new Interval<int>(150,250, 100),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals);
            
            Assert.Equal(expected, observed.set);
            
        }

    }
}