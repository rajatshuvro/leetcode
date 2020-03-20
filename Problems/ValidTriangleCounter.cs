using System;

namespace Problems
{
    //https://leetcode.com/problems/valid-triangle-number/description/
    // lesson learned: I thought the binary search will be faster (commented out code), but that was not so.
    public class ValidTriangleCounter
    {
        //private int[] _nums;
        // this is a variant of the 3 sum problem where you are counting the number of trios that sum up in a certain manner
        public int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);
            int count = 0, n = nums.Length;
            for (int i = n - 1; i >= 2; i--)
            {
                int l = 0, r = i - 1;
                while (l < r)
                {
                    if (nums[l] + nums[r] > nums[i])
                    {
                        count += r - l;
                        r--;
                    }
                    else l++;
                }
            }
            return count;
            //_nums = nums;
            //var numValidTrios = 0;
            //for (int i = 2; i < nums.Length; i++)
            //{
            //    numValidTrios += TriangleNumber(i);
            //}

            //return numValidTrios;
        }
        //find all valid trios where _num[i] is the largest
        // private int TriangleNumber(int i)
        // {
        //     var count = 0;
        //     var side3 = _nums[i];
        //
        //     for (int k = i - 1; k > 0; k--)
        //     {
        //         var side2 = _nums[k];
        //         //minimum required length of side1 so that the 3 sides make a triangle
        //         var minSide1 = side3 - side2 + 1;
        //
        //         var j = Array.BinarySearch(_nums, 0, k, minSide1);
        //         if (j < 0) j = ~j;
        //         if (j >= k) break;
        //
        //         //binary search doesn't guarantee returning smallest index of the search item.
        //         while (j>0 && _nums[j] == _nums[j - 1])
        //         {
        //             j--;
        //         }
        //
        //         count += k - j;
        //
        //     }
        //     return count;
        // }
    }
}