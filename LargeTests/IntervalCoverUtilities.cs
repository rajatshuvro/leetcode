using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataStructures;
using Problems.DynamicProgramming;

namespace LargeTests
{
    public static class IntervalCoverUtilities
    {
        public static IList<int> GetIntervalCosts(List<Interval> intervals)
        {
            var costs = new int[intervals.Count];
            for (int i = 0; i < intervals.Count; i++)
            {
                var size = intervals[i].End - intervals[i].Begin;
                costs[i] = (int)Math.Log(size / 1024, 1.2);//using a sub-inear cost function see: plot log(1.2,x) from x=1000 to 8000 (https://www.wolframalpha.com/)
            }

            return costs;
        }

        public static  List<Interval> GetIntervals(int min, int max, int largeIntervalSize)
        {
            var intervals = new List<Interval>();
            var rand = new Random();
            long begin = min;
            
            while (begin < max)
            {
                var end = begin + rand.Next((int)(largeIntervalSize * 0.8), (int)(largeIntervalSize * 1.2));
                if (end > max) end = max;
                intervals.Add(new Interval((int)begin, (int)end));
                begin = end + 1;
            }

            return intervals;
        }

        public static int[] GetRandomNums(int count, int min, int max)
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
        
        public static bool IsValidCover(int[] nums, IList<Interval> cover)
        {
            var intervals = new List<Interval>(cover);
            intervals.Sort();

            var iTree = IntervalTree.Build(intervals);

            int i = 0;
            while (i < nums.Length)
            {
                var x = nums[i];
                var overlappers = iTree.GetOverlappingIntervals(x, x).ToList();
                if (overlappers.Count == 0) return false;
                var rangeEnd = GetRangeEnd(overlappers);
                // get the first number that is past the range of overlappers
                var j = Array.BinarySearch(nums, rangeEnd + 1);
                if (j < 0) j = ~j;
                i = j;
            }
            return true;
        }

        private static int GetRangeEnd(IEnumerable<Interval> overlappers)
        {
            var end = 0;
            foreach (var interval in overlappers)
            {
                if (end < interval.End) end = interval.End;
            }

            return end;
        }
        
        public static void Uniform_distribution(int min, int max, int count, int largeIntervalSize, int smallIntervalSize)
        {
            var nums = GetRandomNums(count, min, max);
            var largeIntervals = GetIntervals(min, max, largeIntervalSize);
            var smallIntervals = GetIntervals(min, max, smallIntervalSize);
            
            var intervals = new List<Interval>(largeIntervals);
            intervals.AddRange(smallIntervals);
            intervals.Sort();
            var costs = GetIntervalCosts(intervals);
            
            var intervalCover = new IntervalCover();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var cover = intervalCover.GetOptimalCover(nums, intervals, costs);
            stopWatch.Stop();
            
            if (IsValidCover(nums, cover)) 
                Console.WriteLine($"Optimal cover time:{stopWatch.ElapsedMilliseconds} msec");
            else Console.WriteLine("Cover is invalid!!");
        }


    }
}