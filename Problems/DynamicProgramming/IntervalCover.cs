using System.Collections.Generic;
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
        public IList<Interval> GetMinCostIntervalSet(IList<int> nums, IList<Interval> intervals, IList<int> costs)
        {
            return null;
        }
    }
}