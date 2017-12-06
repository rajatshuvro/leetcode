using System;
using System.Collections.Generic;

namespace DetectNearbyNearDuplicates
{
    class DetectNearDuplicates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Detecting if the array contains near duplicates nearby!");

            if (!ContainsNearbyAlmostDuplicate(new int[] { }, 0, 0))
            {
                Console.Write("PASSED");
                Console.WriteLine(" null test case");
            }
            else
            {
                Console.Write("FAILED");
                Console.WriteLine(" null test case");
                Console.ReadKey();
                return;
            }

            if (ContainsNearbyAlmostDuplicate(new [] { 4,5}, 0, 0))
            {
                Console.Write("PASSED");
                Console.WriteLine(" k=0, t=0 test case");
            }
            else
            {
                Console.Write("FAILED");
                Console.WriteLine(" k=0, t=0 test case");
                Console.ReadKey();
                return;
            }


            if (ContainsNearbyAlmostDuplicate(new[] { 4, 4, 5 }, 1, 1))
            {
                Console.Write("PASSED");
                Console.WriteLine(" k=1, t=1 test case");
            }
            else
            {
                Console.Write("FAILED");
                Console.WriteLine(" [4,4,5], k=1, t=1 test case");
                Console.ReadKey();
                return;
            }

            

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

        private static int GetHalfBucketId(int x, int bucketSize)
        {
            if (bucketSize % 2 == 0)
            {
                //buckets are even sized. Boundaries are 0, t, 2t, ...
                var m = bucketSize / 2;
                return x / m;
            }
            else
            {
                //uneven bucket sizes
                // boundaries are 0, m 2m+1, 3m+1, 4m+4, 5m+2 where bucketSize = 2m+1
                var m = (bucketSize - 1 )/ 2;
                var bucketId = x / m + 2;//upper bound on bucketId
                while (!IsValueInBucket(x, m, bucketId))
                {
                    bucketId--;
                }
                return bucketId;
            }
        }

        private static bool IsValueInBucket(int x, int m, int i)
        {
            return (i - 1) * m + (i - 1.0 / 2) <= x && x < i * m + i*1.0/2;
        }
    }
}
