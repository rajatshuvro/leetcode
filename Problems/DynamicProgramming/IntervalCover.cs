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
    
    public class IntervalCover
    {
        private IntervalArray<int> _intervalArray;
        private List<int> _nums;
        private Dictionary<int, (IList<Interval<int>> cover, int cost)> _subSolutions;
        public IList<Interval<int>> GetOptimalCover(IList<int> nums, Interval<int>[] intervals)
        {
            _nums = nums.ToList();
            
            Array.Sort(intervals);
            _intervalArray = new IntervalArray<int>(intervals);
            _subSolutions = new Dictionary<int, (IList<Interval<int>> cover, int cost)>();
            
            return GetOptimalCover(0).cover;
        }
        
        private (IList<Interval<int>> cover, int cost) GetOptimalCover(int i)
        {
            if (i >= _nums.Count) return (null,0);

            if (_subSolutions.ContainsKey(i)) return _subSolutions[i];
            
            var x = _nums[i];
            var overlappers = _intervalArray.GetAllOverlappingIntervals(x,x);
            if (overlappers == null || overlappers.Length == 0)
            {
                //given that each number falls in at least one interval, this should never happen
                throw new InvalidDataException($"{x} is not included in any interval!! Interval cover is empty");
            }

            var minCost = int.MaxValue;
            var minCover = new List<Interval<int>>();
            foreach (var interval in overlappers)
            {
                //find the first num not covered by interval
                var index = _nums.BinarySearch(interval.End + 1);
                if (index < 0) index = ~index;
                var ( remainingCover, remainingCost) = GetOptimalCover(index);
                var cost = interval.Value + remainingCost;
                
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