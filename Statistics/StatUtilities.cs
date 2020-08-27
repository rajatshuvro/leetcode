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

        public static double GetMedian(int[] nums)
        {
            Array.Sort(nums);
            if (nums.Length % 2 == 1) return nums[nums.Length / 2 + 1];
            return 1.0 * (nums[nums.Length / 2] + nums[nums.Length / 2 + 1]) / 2;
        }
        
        
    }
}