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
        public IList<Interval> GetOptimalCover(IList<int> nums, IList<int> starts , IList<int> ends, IList<int> costs)
        {
            _nums = nums.ToList();
            var intervals = new List<Interval<int>>(starts.Count);
            for (int i = 0; i < starts.Count; i++)
            {
                intervals.Add(new Interval<int>(starts[i], ends[i], costs[i]));
            }
            _intervalArray = new IntervalArray<int>(intervals);
            
            return GetOptimalCover(0);
        }

        private IList<Interval> GetOptimalCover(int i)
        {
            if (i >= _nums.Count) return null;
            
            var x = _nums[i];
            var overlappers = _intervalArray.GetOverlappingIntervals(x);
            if (overlappers==null) return null;

            var minCost = int.MaxValue;
            foreach (var interval in overlappers)
            {
                //find the first num not covered by interval
                var index = _nums.BinarySearch(interval.End + 1);
                if (index < 0) index = ~index;
                var remainingCover = GetOptimalCover(index);
                var cost = interval.Value + GetCoverCost(remainingCover);
            }
        }

        private int GetCoverCost(IList<Interval> remainingCover)
        {
            throw new System.NotImplementedException();
        }
    }
}