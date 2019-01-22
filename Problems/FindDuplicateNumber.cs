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
            var cycleLength = GetCycleLength();

            return GetCycleStart(cycleLength);
        }

        private int GetCycleStart(int cycleLength)
        {
            var headIndex = 0;
            var tailIndex = 0;

            while (cycleLength > 0)
            {
                tailIndex = _nums[tailIndex];
                cycleLength--;
            }

            while (_nums[headIndex] != _nums[tailIndex])
            {
                headIndex = _nums[headIndex];
                tailIndex = _nums[tailIndex];
            }

            return _nums[headIndex];
        }

        private int GetCycleLength()
        {
            var singleStepperIndex = 0;
            var singleStepCount = 0;
            var doubleStepperIndex = 0;
            doubleStepperIndex = _nums[doubleStepperIndex];
            var doubleStepCount = 1;

            do
            {
                if (doubleStepCount % 2 == 0)
                {
                    singleStepperIndex = _nums[singleStepperIndex];
                    singleStepCount++;
                }

                doubleStepperIndex = _nums[doubleStepperIndex];
                doubleStepCount++;

            } while (_nums[singleStepperIndex] != _nums[doubleStepperIndex]);

            return doubleStepCount - singleStepCount;
        }
    }
}