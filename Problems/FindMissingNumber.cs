using System;

namespace Problems
{
    public class FindMissingNumber
    {
        //https://leetcode.com/problems/missing-number/description/
        private int[] _nums;
        public int MissingNumber(int[] nums)
        {
            _nums = nums;
            return MissingNumber(0, _nums.Length -1);
        }

        private int MissingNumber(int i, int j)
        {
            var mid = (i + j) / 2;
            
        }
    }
}