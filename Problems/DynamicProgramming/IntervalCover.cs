using System.Collections.Generic;
using System.Linq;
using Algorithms;
using DataStructures;

namespace Problems.DynamicProgramming
{
    /*
     * Problem inspired by SA optimization in Nirvana
     * Given an ordered set of natural numbers A={a_i} where 1<= a_i <= uint.MaxValue, i <= int.MaxValue
     * and a set of intervals I={(s_i, e_i, c_i)}  where s_i = start of interval i, e_i = end of interval i, c_i = cost of interval i , i <= ushort.MaxValue
     * find a subset J of I that contains all values in A but minimizes Sum(c_i) where i \in J
     */
    
    public class IntervalCover
    {
        private IntervalArray<int> _intervalArray;
        private List<int> _nums;
        private Dictionary<int, (IList<Interval<int>> cover, int cost)> _subSolutions;
        public IList<Interval<int>> GetOptimalCover(IList<int> nums, List<Interval<int>> intervals)
        {
            _nums = nums.ToList();
            _intervalArray = new IntervalArray<int>(intervals);
            _subSolutions = new Dictionary<int, (IList<Interval<int>> cover, int cost)>();
            
            return GetOptimalCover(0).cover;
        }
        
        private (IList<Interval<int>> cover, int cost) GetOptimalCover(int i)
        {
            if (_subSolutions.ContainsKey(i)) return _subSolutions[i];
            
            if (i >= _nums.Count) return (null,0);
            
            var x = _nums[i];
            var overlappers = _intervalArray.GetOverlappingIntervals(x);
            if (overlappers==null) return (null, 0);

            var minCost = int.MaxValue;
            var minCover = new List<Interval<int>>();
            foreach (var interval in overlappers)
            {
                //find the first num not covered by interval
                var index = _nums.BinarySearch(interval.End + 1);
                if (index < 0) index = ~index;
                var ( remainingCover, remainingCost) = GetOptimalCover(index);
                var cost = interval.Value + remainingCost;
                if (cost < minCost)
                {
                    minCover.Clear();
                    minCost = cost;
                    minCover.Add(interval);
                    if (remainingCover !=null) minCover.AddRange(remainingCover);
                }
            }
            _subSolutions.Add(i, (minCover, minCost));
            return (minCover, minCost);
        }
    }
}