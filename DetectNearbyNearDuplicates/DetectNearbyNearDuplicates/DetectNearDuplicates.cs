using System;
using System.Collections.Generic;

namespace DetectNearbyNearDuplicates
{
    class DetectNearDuplicates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Detecting if the array contains near duplicates nearby!");

            var result = Test(new int[] {}, 0, 0, false);

            result &= Test(new[] { 4, 5 }, 0, 0, true);
            
            result &= Test(new[] {4, 4, 5}, 1, 1, true);

            if (result)
                Console.WriteLine("Passed all!!");

            Console.ReadKey();
        }

        private static bool Test(int[] nums, int k, int t, bool expectedResult)
        {
            if (ContainsNearbyAlmostDuplicate(nums, k, t) == expectedResult)
            {
                Console.Write("PASSED");
                Console.WriteLine($" [{string.Join(',',nums)}] k={k}, t={t} test case");
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

        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || nums.Length == 0) return false;
            if (k == 0 && t == 0) return true;

            if (k < 1) return false;

            var buckets = new HashSet<int>();

            for (int i= -k-1, j=0; j < nums.Length; i++, j++)
            {
                if (i >= 0)
                {
                    var bucketNo = GetBucketNo(nums[i], t);
                    buckets.Remove(bucketNo);
                }

                var newBucketNo = GetBucketNo(nums[j], t);
                if (buckets.Contains(newBucketNo)) return true;
                buckets.Add(newBucketNo);
            }

            return false;
        }

        private static int GetBucketNo(int x, int bucketSize)
        {
            return 2 * x / bucketSize;
        }
    }
}
