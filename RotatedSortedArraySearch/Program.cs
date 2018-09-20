using System;

namespace RotatedSortedArraySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Searching in a rotated sorted array!");

            var result = UnitTest1();
            result &= UnitTest2();
            result &= UnitTest3();
            result &= UnitTest4();
            result &= UnitTest5();

            if (result)
                Console.WriteLine("Passed all unit tests");

            Console.Read();
        }

        private static bool UnitTest5()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] {0, 0, 1, 1, 2, 0 };

            if (!rotatedArray.Search(nums, 2))
            {
                Console.WriteLine("Failed has next in UT 5. Failed to find 2");
                return false;
            }
            return true;
        }

        private static bool UnitTest4()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 1,2,1 };

            if (rotatedArray.Search(nums, 0))
            {
                Console.WriteLine("Failed has next in UT 4. Found 0");
                return false;
            }
            return true;
        }

        private static bool UnitTest3()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 0, 0, 0,0,0 };
            if (!rotatedArray.Search(nums, 0))
            {
                Console.WriteLine("Failed has next in UT 3. couldn't find 0");
                return false;
            }
            if (rotatedArray.Search(nums, 1))
            {
                Console.WriteLine("Failed has next in UT 3. Found 1");
                return false;
            }
            return true;
        }

        private static bool UnitTest1()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] { 0, 0, 1, 2, 2, 5, 6 };
            if (!rotatedArray.Search(nums, 0))
            {
                Console.WriteLine("Failed has next in UT 1");
                return false;
            }
            if (rotatedArray.Search(nums, 3))
            {
                Console.WriteLine("Failed has next in UT 1");
                return false;
            }
            return true;
        }

        private static bool UnitTest2()
        {
            var rotatedArray = new RotatedSortedArray();
            var nums = new[] {2, 5, 6, 0, 0, 1, 2};
            if (!rotatedArray.Search(nums, 0))
            {
                Console.WriteLine("Failed has next in UT 2. failed to find 0");
                return false;
            }
            if (rotatedArray.Search(nums, 3))
            {
                Console.WriteLine("Failed has next in UT 2. found 3!!");
                return false;
            }
            if (rotatedArray.Search(nums, 4))
            {
                Console.WriteLine("Failed has next in UT 2. found 4!!");
                return false;
            }
            if (!rotatedArray.Search(nums, 6))
            {
                Console.WriteLine("Failed has next in UT 2. failed to find 6");
                return false;
            }
            if (!rotatedArray.Search(nums, 1))
            {
                Console.WriteLine("Failed has next in UT 2. failed to find 1");
                return false;
            }
            return true;
        }
    }
}
