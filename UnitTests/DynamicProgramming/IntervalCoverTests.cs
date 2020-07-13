using System;
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

        [Theory]
        [InlineData(1, int.MaxValue, 3_000_000, 8*1024*1024, 1024*1024)]
        public void RuntimeTests_uniform_distribution(int min, int max, int count, int largeIntervalSize, int smallIntervalSize)
        {
            var nums = GetRandomNums(count, min, max);
            var largeIntervals = GetIntervals(min, max, largeIntervalSize);
            var smallIntervals = GetIntervals(min, max, smallIntervalSize);
            
            var intervals = new List<Interval>(largeIntervals);
            intervals.AddRange(smallIntervals);
            intervals.Sort();
            var costs = GetIntervalCosts(intervals);
            
            var intervalCover = new IntervalCover();
            var cover = intervalCover.GetOptimalCover(nums, intervals, costs);
            
            Assert.True(IsValidCover(nums, cover));

        }

        private bool IsValidCover(IList<int> nums, IList<Interval> cover)
        {
            var intervals = new List<Interval>(cover);
            intervals.Sort();

            var iTree = IntervalTree.Build(intervals);

            foreach (var x in nums)
            {
                if (!iTree.OverlapsAny(x, x)) return false;
            }

            return true;
        }

        private IList<int> GetIntervalCosts(List<Interval> intervals)
        {
            var costs = new int[intervals.Count];
            for (int i = 0; i < intervals.Count; i++)
            {
                var size = intervals[i].End - intervals[i].Begin;
                costs[i] = (int)Math.Log(size / 1024, 1.2);//using a sub-inear cost function see: plot log(1.2,x) from x=1000 to 8000 (https://www.wolframalpha.com/)
            }

            return costs;
        }

        private List<Interval> GetIntervals(int min, int max, int largeIntervalSize)
        {
            var intervals = new List<Interval>();
            var rand = new Random();
            var begin = min;
            
            while (begin < max)
            {
                var end = begin + rand.Next((int)(largeIntervalSize * 0.8), (int)(largeIntervalSize * 1.2));
                if (end > max) end = max;
                intervals.Add(new Interval(begin, end));
                begin = end + 1;
            }

            return intervals;
        }

        private IList<int> GetRandomNums(int count, int min, int max)
        {
            var nums = new int[count];
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                nums[i] = rand.Next(min, max);
            }
            Array.Sort(nums);
            return nums;
        }
    }
}