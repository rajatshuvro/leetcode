using System;
using System.Collections.Generic;

namespace Statistics
{
    public static class StatUtilities
    {
        public static double GetMean(int[] nums)
        {
            var sum = 0;
            foreach (var t in nums)
            {
                sum += t;
            }

            return 1.0*sum / nums.Length;
        }

        public static double GetStd(int[] nums)
        {
            var mean = GetMean(nums);
            double sum = 0;
            foreach (var x in nums)
            {
                sum += (x - mean) * (x - mean);
            }

            var variance = sum / nums.Length;
            return Math.Sqrt(variance);
        }

        public static int GetMode(int[] nums)
        {
            var freq = new Dictionary<int, int>();
            foreach (var x in nums)
            {
                if (freq.ContainsKey(x)) freq[x]++;
                else freq[x] = 1;
            }

            var mode = nums[0];
            var maxFreq = freq[mode];

            foreach (var x in nums)
            {
                if (maxFreq < freq[x])
                {
                    mode = x;
                    maxFreq = freq[x];
                }

                if (maxFreq == freq[x] && x < mode) mode = x;
            }

            return mode;
        }

        public static double GetWeightedMean(int[] nums, int[] weights) {
            var weightedSum=0;
            var totalWeight=0;
            for(var i=0; i < nums.Length; i++){
                weightedSum+= nums[i]*weights[i];
                totalWeight+=weights[i];
            }

            return (1.0*weightedSum)/totalWeight;

        }

        public static double GetMedian(int[] nums, int i=0, int j=-1)
        {
            if (j == -1) j = nums.Length-1;
            var length = j - i + 1;
            Array.Sort(nums, i, length);
            var mid = (i+j)/ 2;
            if (length % 2 == 1) return nums[mid];
            return 1.0 * (nums[mid] + nums[mid + 1]) / 2;
        }

        public static (double q1, double q2, double q3) GetQuartiles(int[] nums)
        {
            var q2 = GetMedian(nums);
            var mid = (nums.Length-1) / 2;
            var odd = nums.Length % 2 == 1;
            var q1 = odd ? GetMedian(nums, 0, mid -1): GetMedian(nums, 0, mid);
            var q3 = GetMedian(nums, mid + 1, nums.Length - 1);
            return (q1, q2, q3);
        }

        public static double GetInterQuartileRange(int[] nums, int[] freq)
        {
            var expandedNums = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var x = nums[i];
                for (int j = 0; j < freq[i]; j++)
                {
                    expandedNums.Add(x);
                }
            }

            var (q1, q2, q3) = GetQuartiles(expandedNums.ToArray());
            return q3 - q1;
        }
    }
}