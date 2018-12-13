using System.Linq;
using Algorithms;

namespace Problems
{
    public class FindMissingNumber
    {
        //https://leetcode.com/problems/missing-number/description/
        private int[] _nums;
        public int MissingNumber(int[] nums)
        {
            _nums = nums;
            var max = nums.Max();
            if ( max == nums.Length - 1) return nums.Length; 
            return MissingNumber(0, _nums.Length -1);
        }

        private int MissingNumber(int i, int j)
        {
            if (i == j)
            {
                return i == _nums[i] ? i + 1 : i;
            }

            var pivotIndex = (i + j) / 2;
            var pivot = _nums[pivotIndex];

            pivotIndex = ArrayUtils.Partition(_nums, i, j, pivotIndex);

            return pivotIndex == pivot ? MissingNumber(pivotIndex + 1, j) : MissingNumber(i, pivotIndex);

        }
    }
}