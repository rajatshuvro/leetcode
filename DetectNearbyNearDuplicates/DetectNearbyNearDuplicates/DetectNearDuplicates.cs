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

        public class Interval:IComparable<long>, IComparable<Interval> 
        {
            private readonly long _start;
            private readonly long _end;
            public readonly long Center;

            public Interval(long center, long radius)
            {
                Center = center;
                _start = center - radius;
                _end = center + radius;
            }

            public bool Contains(long x)
            {
                return _start <= x && x <= _end;
            }

            public int CompareTo(long other)
            {
                if (Contains(other)) return 0;

                return Center < other? -1: 1;
            }

            public int CompareTo(Interval other)
            {
                if (Overlaps(other)) return 0;
            }

            private bool Overlaps(Interval other)
            {
                throw new NotImplementedException();
            }
        }
        

        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || nums.Length <= 1) return false;
            if (t < 0) return false;
            if (k == 0 && t == 0) return true;

            if (k < 1) return false;

            var intervals = new Dictionary<int, Interval>();

            for (int i= -k-1, j=0; j < nums.Length; i++, j++)
            {
                if (i >= 0)
                {
                    intervals.Remove(nums[i]);
                }

                if (intervals.Values.Any(interval => interval.Contains(nums[j])))
                {
                    return true;
                }
                intervals.Add(nums[j], new Interval(nums[j], t));
                    
            }

            return false;
        }

        
    }
}
