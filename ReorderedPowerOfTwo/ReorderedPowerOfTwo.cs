using System;

namespace ReorderedPowerOfTwo
{
    class ReorderedPowerOfTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reordered power of two!");

            var result = UnitTest1();
            result &= UnitTest2();

            if (result)
                Console.WriteLine("Passed all unit tests");

            Console.Read();
        }

        private static bool UnitTest2()
        {
            var s = new Solution();
            if (s.ReorderedPowerOf2(46)) return true;

            Console.WriteLine("Failed unit test 2");
            return false;
        }

        private static bool UnitTest1()
        {
            var s = new Solution();
            if (s.ReorderedPowerOf2(16)) return true;

            Console.WriteLine("Failed unit test 1");
            return false;
        }

        private static bool UnitTest3()
        {
            var s = new Solution();
            if (!s.ReorderedPowerOf2(24)) return true;

            Console.WriteLine("Failed unit test 3");
            return false;
        }
    }
}
