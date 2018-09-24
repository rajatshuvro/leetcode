using System;
using System.Linq;

namespace SlidingWindowMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding the sliding window medians!");

            var result = UnitTest1();
            result &= UnitTest2();
            result &= UnitTest3();
            //result &= UnitTest4();
            //result &= UnitTest5();

            if (result)
                Console.WriteLine("Passed all unit tests");

            Console.Read();
        }

        private static bool UnitTest3()
        {
            var sol = new SlidingMedianFinder();
            var medianVector = sol.MedianSlidingWindow(new[] { 7, 8, 8, 3, 8, 1, 5, 3, 5, 4 }, 3);
            var expectedVector = new[] { 8.0, 8.0, 8.0, 3.0, 5.0, 3.0, 5.0, 4.0 };

            if (medianVector.Length != expectedVector.Length)
            {
                Console.WriteLine("failed unit test 3");
                return false;
            }

            for (int i = 0; i < expectedVector.Length; i++)
            {
                if (medianVector[i] == expectedVector[i]) continue;
                Console.WriteLine("failed unit test 3");
                return false;
            }

            return true;
        }

        private static bool UnitTest2()
        {
            var sol = new SlidingMedianFinder();
            var medianVector = sol.MedianSlidingWindow(new[] { 2147483647, 1, 2, 3, 4, 5, 6, 7, 2147483647 }, 2);
            var expectedVector = new [] { 2147483648.0/2, 1.5, 2.5, 3.5, 4.5, 5.5, 6.5, 2147483654.0/2 };

            if (medianVector.Length != expectedVector.Length)
            {
                Console.WriteLine("failed unit test 2");
                return false;
            }

            for (int i = 0; i < expectedVector.Length; i++)
            {
                if (medianVector[i] == expectedVector[i]) continue;
                Console.WriteLine("failed unit test 2");
                return false;
            }

            return true;
        }

        private static bool UnitTest1()
        {
            var sol = new SlidingMedianFinder();
            var medianVector = sol.MedianSlidingWindow(new[] {1, 3, -1, -3, 5, 3, 6, 7}, 3);
            var expectedVector = new[] {1, -1, -1, 3, 5, 6};

            if (medianVector.Length != expectedVector.Length)
            {
                Console.WriteLine("failed unit test 1");
                return false;
            }

            for (int i = 0; i < expectedVector.Length; i++)
            {
                if (medianVector[i] == expectedVector[i]) continue;
                Console.WriteLine("failed unit test 1");
                return false;
            }

            return true;
        }
    }
}
