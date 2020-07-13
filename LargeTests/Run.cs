using System;

namespace LargeTests
{
    public class Run
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello large instance tester!");

            var key = args[0];

            switch (key)
            {
                case "interval-cover":
                    TestIntervalCover();
                    break;
                default:
                    Console.WriteLine("Unrecognized problem name.");
                    break;
            }
        }

        private static void TestIntervalCover()
        {
            Console.WriteLine("Testing interval cover");
            IntervalCoverUtilities.Uniform_distribution(1, 2_000_000_000, 3_000_000, 20*16*1024, 20*1024);
        }
    }
}