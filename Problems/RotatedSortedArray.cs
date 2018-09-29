using System;

namespace Problems
{
    public class RotatedSortedArray
    {
        private int[] _nums;
        private int _target;
        public bool Search(int[] nums, int target)
        {
            _nums = nums;
            _target = target;
            if (_nums == null || _nums.Length == 0) return false;
            if (BinarySearch(0, nums.Length-1) >= 0) return true;
            return false;
        }
        //Given any rotated array, if we take any partitioning index i,
        // either the lower half or the upper half is sorted. and the other half is rotated
        // so, at each call we find the mid point and check which half is sorted.
        // If the target is within the range of the sorted part, just apply binary search
        // otherwish recurse on the other half.
        private int BinarySearch(int low, int high)
        {
            if (_nums[low] == _target) return low;
            if (_nums[high] == _target) return high;
            //due to rotation the low and high points may be equal. Skipping them 
            while (_nums[low] == _nums[high] && low < high) low++;
            if (high == low) return -1;

            if (_nums[low] < _nums[high])//this part of the array is sorted
                return Array.BinarySearch(_nums, low, high - low + 1, _target);

            var mid = (high + low) / 2;
            
            // lower half sorted
            if (_nums[low] <= _nums[mid])
            {
                if (_nums[low] <= _target && _target <= _nums[mid])//and target is in range
                    return Array.BinarySearch(_nums, low, mid - low + 1, _target);
                return BinarySearch(mid+1, high); //check in the rotated upper half
            }

            if (_nums[mid + 1] <= _target && _target <= _nums[high])
                return Array.BinarySearch(_nums, mid, high - mid + 1, _target);
            return BinarySearch(low, mid);
        }
    }
}