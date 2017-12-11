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

            var result = Test(new int[] { }, 0, 0, false);

            result &= Test(new[] { 4, 5 }, 0, 0, true);

            result &= Test(new[] { 2, 1 }, 1, 1, true);

            result &= Test(new[] { 4, 4, 5 }, 1, 1, true);

            result &= Test(new[] { -1, -1 }, 1, 0, true);

            result &= Test(new[] { -1, -1 }, 1, -1, false);

            result &= Test(new[] { -3, 3 }, 2, 4, false);

            result &= Test(new[] { 0 }, 0, 0, false);

            result &= Test(new[] { 7, 1, 3 }, 2, 3, true);

            result &= Test(new[] { -2147483648, -2147483647 }, 3, 3, true);

            result &= Test(new[] { -1, 2147483647 }, 1, 2147483647, false);

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

            var buckets = new Dictionary<int, int>();

            for (int i = -k - 1, j = 0; j < nums.Length; i++, j++)
            {
                if (i >= 0)
                {
                    buckets.Remove(GetBucket(nums[i], t));
                }

                var x = nums[j];
                var bucket = GetBucket(x, t);
                if (buckets.ContainsKey(bucket)) return true;
                if (buckets.ContainsKey(bucket - 1) && IsNearby(x, buckets[bucket - 1], t)) return true;
                if (buckets.ContainsKey(bucket + 1) && IsNearby(x, buckets[bucket + 1], t)) return true;

                buckets.Add(bucket, x);

            }

            return false;
        }

        private static bool IsNearby(int x, int y, int epsilon)
        {
            return Math.Abs((long) x - (long) y) <= epsilon;
        }

        private static int GetBucket(int x, int t)
        {
            if (t == 0) return x;
            if (x < 0) return x / t - 1;
            return x / t + 1;

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
