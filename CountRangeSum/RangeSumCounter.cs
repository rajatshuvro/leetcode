using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CountRangeSum
{
    class RangeSumCounter
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Counting number of range sums!");

            UnitTestSpanning1();

            
        }

        private static void UnitTestSpanning1()
        {
            var rsc = new RangeSumCounter();

            var rangeCount = rsc.GetSpanningRangeSum(new[] { -2, 1, 3 , 2 }, 2, 5, 0, 2, 4);

            Console.WriteLine($"Number of spanning ranges:{rangeCount}");
        }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            return CountRangeSum(nums, lower, upper, 0, nums.Length);
        }

        
        private int CountRangeSum(int[] nums, int lower, int upper, int i, int j)
        {
            var n = j - i;
            if (n == 0) return 0;
            if (n == 1)
            {
                return lower <= nums[i] && nums[i] <= upper ? 1 : 0;
            }

            var spanningSumCount = GetSpanningRangeSum(nums, lower, upper, 0, n / 2, n);

            return CountRangeSum(nums, lower, upper, 0, n / 2) + spanningSumCount +
                   CountRangeSum(nums, lower, upper, n / 2, n);

        }

        // count ranges that span element j
        public int GetSpanningRangeSum(int[] nums, int lower, int upper, int i, int j, int k)
        {
            var leftRanges = new List<int>();
            if (i < j)
            {
                var rangeSum = 0;
                for (var x = j - 1; x >= i; x--)
                {
                    rangeSum += nums[x];
                    leftRanges.Add(rangeSum);
                }
            }

            leftRanges.Sort();

            var rangeCount = 0;
            if (j < nums.Length)
            {
                var rangeSum = 0;
                for (var x = j +1; x < k; x++)
                {
                    rangeSum += nums[x];

                    var lowerRemainder = lower - rangeSum;
                    var upperRemainder = upper - rangeSum;

                    var lowerIndex = leftRanges.BinarySearch(lowerRemainder);
                    if (lowerIndex < 0) lowerIndex = ~lowerIndex;
                    if (lowerIndex != leftRanges.Count)
                    {
                        for (var y = lowerIndex; y < leftRanges.Count; y++)
                        {
                            if (lowerRemainder <= leftRanges[y] && leftRanges[y] <= upperRemainder) rangeCount++;
                            else break;
                        }
                    }
                }
            }

            return rangeCount;
        }

    }
}
