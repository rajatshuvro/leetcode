using System.Collections.Generic;

namespace Problems
{
    public class ContiguousSubarray
    {
        //https://leetcode.com/problems/contiguous-array/description/
        //Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.
        public int FindMaxLength(int[] nums)
        {
            var firstIndexOfSum = new Dictionary<int, int>();
            firstIndexOfSum[0] = -1;

            var sum = 0;
            var maxLength = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0) sum--;
                else sum++;

                if (firstIndexOfSum.TryGetValue(sum, out var index))
                {
                    if( maxLength < i - index) maxLength = i-index ;
                }
                else firstIndexOfSum[sum] = i;
            }

            return maxLength;
        }
    }
}