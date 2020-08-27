using System;

namespace Statistics
{
    public static class StatUtilities
    {
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
    }
}