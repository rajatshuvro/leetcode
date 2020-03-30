using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class TopKElements
    {
        //https://leetcode.com/problems/top-k-frequent-elements/
        public IList<int> TopKFrequent(int[] nums, int k) {
            var counts = new Dictionary<int, int>(nums.Length);
            
            for(var i=0; i < nums.Length; i++)
                if (counts.ContainsKey(nums[i]))
                    counts[nums[i]]++;
                else counts[nums[i]] = 1;

            var sortedByCounts = counts.OrderByDescending(x => x.Value);

            var kFrequent = new List<int>(k);
            foreach (var (num, count) in sortedByCounts)
            {
                kFrequent.Add(num);
                if (kFrequent.Count >= k) break;
            }

            return kFrequent;
        }
    }
}