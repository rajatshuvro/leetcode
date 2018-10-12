using System;
using System.Globalization;

namespace Problems
{
    //https://leetcode.com/problems/valid-triangle-number/description/
    public class ValidTriangleCounter
    {
        private int[] _nums;
        // this is a variant of the 3 sum problem where you are counting the number of trios that sum up in a certain manner
        public int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);

            _nums = nums;
            var numValidTrios = 0;
            for (int i = 2; i < nums.Length; i++)
            {
                numValidTrios += TriangleNumber(i);
            }

            return numValidTrios;
        }
        //find all valid trios where _num[i] is the largest
        private int TriangleNumber(int i)
        {
            var count = 0;
            var side3 = _nums[i];

            for (int k = i - 1, j=0; k > j; k--)
            {
                var side2 = _nums[k];
                //minimum required length of side1 so that the 3 sides make a triangle
                var minSide1 = side3 - side2 + 1;

                j = Array.BinarySearch(_nums, j, k-j, minSide1);
                if (j < 0) j = ~j;
                count += k - j;

            }
            return count;
        }
    }
}