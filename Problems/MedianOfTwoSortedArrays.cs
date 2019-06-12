using System;

namespace Problems
{
    public static class MedianOfTwoSortedArrays
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var n = nums1.Length;
            var m = nums2.Length;

            if (n == 0) return FindMedianSortedArray(nums2);
            if (m == 0) return FindMedianSortedArray(nums1);

            //the median is more likely to be in the larger array
            // so we start the search at the end of larger array
            var medianRank = (n + m) / 2;
            var largerArray = n >= m ? nums1 : nums2;
            var high = largerArray.Length -1;
            var low = high / 2;
            var candidate = largerArray[high];
            var candidateRank = GetSortedArrayRank(candidate, nums1) + GetSortedArrayRank(candidate, nums2);
            while (low < high && candidateRank < medianRank)
            {
                var mid = (low + high) / 2;
                candidate = largerArray[mid];
                candidateRank = GetSortedArrayRank(candidate, nums1) + GetSortedArrayRank(candidate, nums2);
                if (candidateRank < medianRank) low = mid;
                else high = mid;
            }

            return 0;
        }

        public static int GetSortedArrayRank(int x, int[] nums)
        {
            var index = Array.BinarySearch(nums, x);
            if (index >= 0) return index + 1;

            //value not found
            index = ~index;
            if (index < nums.Length) return index;
            return nums.Length + 1;

        }

        public static double FindMedianSortedArray(int[] nums)
        {
            var n = nums.Length;
            if (n % 2 == 1) return nums[n / 2];
            return (double)(nums[n / 2  - 1] + nums[n / 2]) / 2;
        }
    }
}