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
        public static  List<Interval<int>> GetIntervals(int min, int max, int largeIntervalSize)
        {
            var intervals = new List<Interval<int>>();
            var rand = new Random();
            long begin = min;
            
            while (begin < max)
            {
                var end = begin + rand.Next((int)(largeIntervalSize * 0.8), (int)(largeIntervalSize * 1.2));
                if (end > max) end = max;
                var cost = (int)Math.Log((end-begin) / 1024, 1.2);//using a sub-inear cost function see: plot log(1.2,x) from x=1000 to 8000 (https://www.wolframalpha.com/)
                intervals.Add(new Interval<int>((int)begin, (int)end, cost));
                begin = end + 1;
            }

            return intervals;
        }

        public static int[] GetUniformRandomNums(int count, int min, int max)
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
        public static int[] GetGroupedNums(int count, int groupSize, int gapSize, int min, int max)
        {
            var nums = new List<int>(count);
            var rand = new Random();

            var groupMin = min;
            var groupMax = groupMin + groupSize;
            
            for (int i = 0; i < count && groupMax <= max; i++)
            {
                if (i % groupSize == 0)
                {
                    groupMin = groupMax + gapSize;
                    groupMax = groupMin + groupSize;

                    if (groupMax > max) break;
                }
                nums.Add(rand.Next(groupMin, groupMax));

            }
            nums.Sort();
            return nums.ToArray();
        }
        public static bool IsValidCover(int[] nums, IList<Interval<int>> cover)
        {
            var intervals = new List<Interval<int>>(cover);
            intervals.Sort();

            var iArray = new IntervalArray<int>(intervals.ToArray());

            int i = 0;
            while (i < nums.Length)
            {
                var x = nums[i];
                var overlappers = iArray.GetAllOverlappingIntervals(x, x).ToList();
                if (overlappers.Count == 0) return false;
                var rangeEnd = GetRangeEnd(overlappers);
                // get the first number that is past the range of overlappers
                var j = Array.BinarySearch(nums, rangeEnd + 1);
                if (j < 0) j = ~j;
                i = j;
            }
            return true;
        }

        private static int GetRangeEnd(IEnumerable<Interval<int>> overlappers)
        {
            var end = 0;
            foreach (var interval in overlappers)
            {
                if (end < interval.End) end = interval.End;
            }

            return end;
        }
        
        public static void BenchmarkIntervalCover(int[] nums, List<Interval<int>> intervalSetOne, List<Interval<int>> intervalSetTwo=null)
        {
            var intervals = new List<Interval<int>>(intervalSetOne);
            if(intervalSetTwo != null) intervals.AddRange(intervalSetTwo);
            
            var intervalCover = new IntervalCover();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var cover = intervalCover.GetOptimalCover(nums, intervals.ToArray());
            stopWatch.Stop();
            
            if (IsValidCover(nums, cover.set)) 
                Console.WriteLine($"Optimal cover time:{stopWatch.ElapsedMilliseconds} msec. Optimal cost: {cover.cost}");
            else Console.WriteLine("Cover is invalid!!");
        }

        
    }
}