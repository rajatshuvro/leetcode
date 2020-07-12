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
        public void Case_0()
        {
            var nums = new[] { 1,2,3,4,5,6,7,8,9,10};
            var intervals = new List<Interval>()
            {
                new Interval(1,4),
                new Interval(3,6),
                new Interval(5,10),
                new Interval(8,10),
            };
            var costs = new[] {4, 2, 6, 2};
            var expected = new[]
            {
                new Interval(1,4),
                new Interval(5,10),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals, costs);
            
            Assert.Equal(expected, observed);
        }
        
        [Fact]
        public void Case_1()
        {
            var nums = Enumerable.Range(1,300).ToList();
            var intervals = new List<Interval>()
            {
                new Interval(1,100),
                new Interval(201,300),
                new Interval(101,200),
                new Interval(10,30),
                new Interval(81,120),
                new Interval(150,250),
                new Interval(181,220),
            };
            var costs = new[] { 100, 100, 100, 20, 40, 100, 40};
            var expected = new[]
            {
                new Interval(1,100),
                new Interval(101,200),
                new Interval(201,300),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals, costs);
            
            Assert.Equal(expected, observed);
            
        }
        
        [Fact]
        public void Case_2()
        {
            var nums = Enumerable.Range(15,10).ToList();
            var intervals = new List<Interval>()
            {
                new Interval(1,100),
                new Interval(201,300),
                new Interval(101,200),
                new Interval(10,30),
                new Interval(81,120),
                new Interval(150,250),
                new Interval(181,220),
            };
            var costs = new[] { 100, 100, 100, 20, 40, 100, 40};
            var expected = new[]
            {
                new Interval(10,30),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals, costs);
            
            Assert.Equal(expected, observed);
            
        }
        
        [Fact]
        public void Case_3()
        {
            var nums = Enumerable.Range(85,100).ToList();
            var intervals = new List<Interval>()
            {
                new Interval(1,100),
                new Interval(201,300),
                new Interval(101,200),
                new Interval(10,30),
                new Interval(81,120),
                new Interval(150,250),
                new Interval(181,220),
            };
            var costs = new[] { 100, 100, 100, 20, 40, 100, 40};
            var expected = new[]
            {
                new Interval(81,120),
                new Interval(101,200),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals, costs);
            
            Assert.Equal(expected, observed);
            
        }
        
        [Fact]
        public void Case_4()
        {
            var nums = Enumerable.Range(85, 20).ToList();
            nums.AddRange(Enumerable.Range(155, 90));
            
            var intervals = new List<Interval>()
            {
                new Interval(1,100),
                new Interval(201,300),
                new Interval(101,200),
                new Interval(10,30),
                new Interval(81,120),
                new Interval(150,250),
                new Interval(181,220),
            };
            var costs = new[] { 100, 100, 100, 20, 40, 100, 40};
            var expected = new[]
            {
                new Interval(81,120),
                new Interval(150,250),
            };
            var intervalCover = new IntervalCover();
            var observed = intervalCover.GetOptimalCover(nums, intervals, costs);
            
            Assert.Equal(expected, observed);
            
        }
    }
}