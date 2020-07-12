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
     * and a set of intervals I={(s_i, e_i, c_i)}  where s_i = start of interval i, e_i = end of interval i, c_i = cost of interval i , i <= ushort.MaxValue
     * find a subset J of I that contains all values in A but minimizes Sum(c_i) where i \in J
     */
    
    public class IntervalCover
    {
        private IntervalTree _intervalTree;
        private List<int> _nums;
        private Dictionary<int, (IList<Interval> cover, int cost)> _subSolutions;
        private Dictionary<Interval, int> _intervalCosts;
        public IList<Interval> GetOptimalCover(IList<int> nums, List<Interval> intervals, IList<int> costs)
        {
            _nums = nums.ToList();
            _intervalCosts = new Dictionary<Interval, int>();
            for (int i = 0; i < intervals.Count; i++)
            {
                _intervalCosts[intervals[i]] = costs[i];
            }
            
            intervals.Sort();
            _intervalTree = IntervalTree.Build(intervals);
            _subSolutions = new Dictionary<int, (IList<Interval> cover, int cost)>();
            
            return GetOptimalCover(0).cover;
        }
        
        private (IList<Interval> cover, int cost) GetOptimalCover(int i)
        {
            if (i >= _nums.Count) return (null,0);

            if (_subSolutions.ContainsKey(i)) return _subSolutions[i];
            
            var x = _nums[i];
            var overlappers = _intervalTree.GetOverlappingIntervals(x,x).ToList();
            if (overlappers == null)
            {
                //given that each number falls in at least one interval, this should never happen
                throw new InvalidDataException($"{x} is not included in any interval!! Interval cover is empty");
            }

            var minCost = int.MaxValue;
            var minCover = new List<Interval>();
            foreach (var interval in overlappers)
            {
                //find the first num not covered by interval
                var index = _nums.BinarySearch(interval.End + 1);
                if (index < 0) index = ~index;
                var ( remainingCover, remainingCost) = GetOptimalCover(index);
                var cost = _intervalCosts[interval] + remainingCost;
                
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