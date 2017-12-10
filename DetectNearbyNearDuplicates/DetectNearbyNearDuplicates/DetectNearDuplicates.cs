using System;
using System.Collections.Generic;
using System.Linq;

namespace DetectNearbyNearDuplicates
{
    class DetectNearDuplicates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Detecting if the array contains near duplicates nearby!");

            var result = Test(new int[] {}, 0, 0, false);

            result &= Test(new[] { 4, 5 }, 0, 0, true);

            result &= Test(new[] { 2, 1 }, 1, 1, true);

            result &= Test(new[] {4, 4, 5}, 1, 1, true);

            result &= Test(new[] { -1, -1 }, 1, 0, true);

            result &= Test(new[] { -1, -1 }, 1, -1, false);

            result &= Test(new[] { -3, 3 }, 2, 4, false);

            result &= Test(new[] { 0 }, 0, 0, false);

            result &= Test(new[] { 7,1,3 }, 2, 3, true);

            result &= Test(new[] { -2147483648, -2147483647}, 3, 3, true);

            result &= Test(new[] {-1, 2147483647}, 1, 2147483647, false);

            if (result)
                Console.WriteLine("Passed all!!");

            Console.ReadKey();
        }

        
        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || nums.Length <= 1) return false;
            if (t < 0) return false;
            if (k == 0 && t == 0) return true;

            if (k < 1) return false;

            var sortedList = new List<int>();

            for (int i= -k-1, j=0; j < nums.Length; i++, j++)
            {
                if (i >= 0)
                {
                    sortedList.Remove(nums[i]);
                }

                //find if any of the neighbors are within distance of t
                var index = sortedList.BinarySearch(nums[j]);
                if (index >= 0) return true;
                else
                {
                    //The zero-based index of item in the sorted List<T>, if item is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.
                    var largerIndex = ~index;

                    if (largerIndex > 0)
                    {
                        //left neighbor exists
                        var leftNeighbor = sortedList[largerIndex - 1];

                        if (Math.Abs((long)nums[j] - (long)leftNeighbor) <= (long)t) return true;
                    }

                    if (largerIndex < sortedList.Count)
                    {
                        //right neighbor exist
                        var rightNeighbor = sortedList[largerIndex];
                        if (Math.Abs((long)nums[j] - (long)rightNeighbor) <= (long)t) return true;
                    }

                    sortedList.Insert(largerIndex, nums[j]);
                }

            }

            return false;
        }

        private static bool Test(int[] nums, int k, int t, bool expectedResult)
        {
            if (ContainsNearbyAlmostDuplicate(nums, k, t) == expectedResult)
            {
                Console.Write("PASSED");
                Console.WriteLine($" [{string.Join(',', nums)}] k={k}, t={t} test case");
            }
            else
            {
                Console.Write("FAILED");
                Console.WriteLine($" [{string.Join(',', nums)}] k={k}, t={t} test case");
                Console.ReadKey();
                return false;
            }

            return true;
        }



    }
}
