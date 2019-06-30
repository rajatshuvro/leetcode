using Algorithms;

namespace Problems
{
    public class FindMissingNumber
    {
        //https://leetcode.com/problems/missing-number/description/

        //public int MissingNumber(int[] nums)
        //{
        //    Array.Sort(nums);
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (i != nums[i]) return i;
        //    }

        //    return nums.Length;
        //}
        private int[] _nums;
        public int MissingNumber(int[] nums)
        {
            _nums = nums;
            return MissingNumber(0, _nums.Length - 1);
        }

        private int MissingNumber(int i, int j)
        {
            if (i >= j)
            {
                return j == _nums[j] ? j + 1 : j;
            }

            var pivotIndex = (i + j) / 2;
            var pivot = _nums[pivotIndex];

            var pivotRank = ArrayUtils.Partition(_nums, i, j, pivotIndex);

            return pivotRank == pivot ? MissingNumber(pivotRank + 1, j) : MissingNumber(i, pivotRank);

        }
    }
}