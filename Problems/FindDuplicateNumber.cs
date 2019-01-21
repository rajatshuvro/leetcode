using System;

namespace Problems
{
    public class FindDuplicateNumber
    {
        //https://leetcode.com/problems/find-the-duplicate-number/description/
        // Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.
        private int[] _nums;
        public int FindDuplicate(int[] nums)
        {
            _nums = nums;
            return FindDuplicate(0, nums.Length-1);
        }

        private int FindDuplicate(int i, int j)
        {
            return -1;
        }
    }
}