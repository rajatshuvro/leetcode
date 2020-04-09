using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;

namespace Problems.TwoPointers
{
    public class MinCoverOfLists
    {
        //https://leetcode.com/problems/smallest-range-covering-elements-from-k-lists/
        public int[] SmallestRange(IList<IList<int>> lists)
        {
            var jointList = new List<int>();
            foreach (var numList in lists)
            {
                jointList.AddRange(numList);
            }
            jointList.Sort();
            var range = new int[2];
            range[0] = jointList[0];
            range[1] = jointList[jointList.Count - 1];

            var indices = new int[lists.Count];
            var nums = new int[lists.Count];
            
            foreach (var x in jointList)
            {
                var outOfRange = false;
                for(var i=0; i < lists.Count; i++)
                {
                    indices[i] = FindClosestNumIndex(lists[i], x, indices[i]);
                    if (indices[i] == lists[i].Count)
                    {
                        outOfRange = true;
                        break;
                    }
                }
                //if any of the indices are negative we cannot find a range that covers all
                if(outOfRange) continue;
                //compute the min and max from the list of numbers indicated by indices
                for (int i = 0; i < lists.Count; i++)
                {
                    nums[i] = lists[i][indices[i]];
                }

                var min = nums.Min();
                var max = nums.Max();
                if (max - min < range[1] - range[0])
                {
                    range[1] = max;
                    range[0] = min;
                }
            }
            return range;
        }

        private static int FindClosestNumIndex(IList<int> nums, int x, int i)
        {
            if (i == nums.Count) return i;
            while (i < nums.Count && x > nums[i])
            {
                i++;
            }

            return i;
        }
    }
}