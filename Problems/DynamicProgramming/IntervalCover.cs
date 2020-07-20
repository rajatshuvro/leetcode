using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;
using DataStructures;

namespace Problems.DynamicProgramming
{
    /*
     * Problem inspired by SA optimization in Nirvana
     * Given an ordered set of natural numbers A={a_i} where 1<= a_i <= uint.MaxValue, i <= int.MaxValue
     * and a set of intervals I={(s_i, e_i)}  where s_i = start of interval i, e_i = end of interval i,  i <= ushort.MaxValue
     * A set of costs (one for each interval) C = {c_i} where c_i = cost of interval i 
     * find a subset J of I that contains all values in A but minimizes Sum(c_i) where i \in J
     */
    
    public class IntervalCover<T>
    {
        private IntervalArray<T> _intervalArray;
        private List<int> _nums;
        private Dictionary<int, (IList<Interval<T>> cover, int cost)> _subSolutions;
        private int _end;
        public (IList<Interval<T>> set, int cost) GetOptimalCover(IList<int> nums, Interval<T>[] intervals)
        {
            _nums = nums.ToList();
            
            Array.Sort(intervals);
            _intervalArray = new IntervalArray<T>(intervals);
            _end = GetIntervalArrayEnd( _intervalArray);
            _subSolutions = new Dictionary<int, (IList<Interval<T>> cover, int cost)>();
            
            return GetOptimalCover(0);
            //return GetReverseCover();
        }

        private int GetIntervalArrayEnd(IntervalArray<T> intervalArray)
        {
            var lastInterval = intervalArray.Array[intervalArray.Array.Length - 1];
            var overlappers = intervalArray.GetAllOverlappingIntervals(lastInterval.End, lastInterval.End);
            return overlappers.Select(x => x.End).Max();
        }

        //Attempt to get optimal cover starting from the end of the array
        private (IList<Interval<T>> set, int cost) GetReverseCover()
        {
            for (int i = _nums.Count-1; i >= 0; i--)
            {
                var cover = GetOptimalCover(i);
            }

            return _subSolutions.ContainsKey(0)?_subSolutions[0]: (null, 0);
        }

        private (IList<Interval<T>> set, int cost) GetOptimalCover(int i)
        {
            if (i >= _nums.Count) return (null,0);

            if (_subSolutions.ContainsKey(i)) return _subSolutions[i];
            
            var x = _nums[i];
            if (x > _end) return (null, 0);
            
            var overlappers = _intervalArray.GetAllOverlappingIntervals(x,x);
            if (overlappers == null || overlappers.Length == 0)
            {
                //if a number is not present in any intervals, skip it
                return GetOptimalCover(i + 1);
            }

            var minCost = int.MaxValue;
            var minCover = new List<Interval<T>>();
            foreach (var interval in overlappers)
            {
                //find the first num not covered by interval
                var index = _nums.BinarySearch(interval.End + 1);
                if (index < 0) index = ~index;
                var ( remainingCover, remainingCost) = GetOptimalCover(index);
                var cost = interval.Cost + remainingCost;
                
                if (cost >= minCost) continue;
                
                minCover.Clear();
                minCost = cost;
                minCover.Add(interval);
                if (remainingCover !=null) minCover.AddRange(remainingCover);
            }
            _subSolutions.Add(i, (minCover, minCost));
            return (minCover, minCost);
        }
    }
}