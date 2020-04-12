using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems.ArrayProblems
{
    public class InsertingInterval
    {
        //https://leetcode.com/problems/insert-interval/
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var intervalList = new List<Interval>();
            foreach (var interval in intervals)
            {
                intervalList.Add(new Interval(interval[0], interval[1]));
            }
            intervalList.Sort();
            var insertedInterval = new Interval(newInterval[0], newInterval[1]);
            
            var (start,end) = GetOverlappingRange(intervalList, insertedInterval);
            
            var overlappingInterval = new Interval(
                Math.Min(intervalList[start].start, insertedInterval.start), 
                Math.Max(intervalList[end].end, insertedInterval.end));
            
            //remove items indexed from start ... end and inserted the overlapping interval
            intervalList.RemoveRange(start, end - start+1);
            intervalList.Insert(start, overlappingInterval);

            var retIntervals = new int[intervalList.Count][];
            for (int i = 0; i < intervalList.Count; i++)
            {
                var interval = intervalList[i];
                retIntervals[i] = new[] {interval.start, interval.end};
            }

            return retIntervals;
        }

        private (int start, int end) GetOverlappingRange(List<Interval> intervalList, Interval insertedInterval)
        {
            var index = intervalList.BinarySearch(insertedInterval);
            if (index < 0) index = ~index;

            //look to the left for overlap
            var start = index - 1;
            while (start >=0 && insertedInterval.Overlaps(intervalList[start]))
            {
                start--;
            }
            //look to the right
            var end = index;
            while (end < intervalList.Count && insertedInterval.Overlaps(intervalList[end]))
            {
                end++;
            }

            return (start + 1, end - 1);
        }
    }
}