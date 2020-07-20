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
            var min = 1;
            var max = 250_000_000;
            var count = 3_000_000;
            var largeIntervalSize = 20 * 16 * 1024;
            var smallIntervalSize = 20 * 2 * 1024;
            
            var nums = IntervalCoverUtilities.GetUniformRandomNums(count, min, max);
            
            var largeIntervals = IntervalCoverUtilities.GetIntervals(min, max, largeIntervalSize);
            var smallIntervals = IntervalCoverUtilities.GetIntervals(min, max, smallIntervalSize);

            Console.WriteLine($"Using {largeIntervals.Count} large and {smallIntervals.Count} small intervals.");
            Console.WriteLine($"Testing grouped numbers. count {nums.Length}");
            Console.WriteLine("Using both large and small intervals ");
            IntervalCoverUtilities.BenchmarkIntervalCover(nums, largeIntervals, smallIntervals );
            Console.WriteLine("Using large intervals ");
            IntervalCoverUtilities.BenchmarkIntervalCover(nums, largeIntervals);
            Console.WriteLine("Using small intervals ");
            IntervalCoverUtilities.BenchmarkIntervalCover(nums, smallIntervals);

            var groupSize =  10_000;
            var gapSize = 500_000;
            var groupedNums = IntervalCoverUtilities.GetGroupedNums(count, groupSize, gapSize, min, max);
            Console.WriteLine($"Testing grouped numbers. count {groupedNums.Length}");

            Console.WriteLine("Using both large and small intervals ");
            IntervalCoverUtilities.BenchmarkIntervalCover(groupedNums, largeIntervals, smallIntervals );
            Console.WriteLine("Using large intervals ");
            IntervalCoverUtilities.BenchmarkIntervalCover(groupedNums, largeIntervals);
            Console.WriteLine("Using small intervals ");
            IntervalCoverUtilities.BenchmarkIntervalCover(groupedNums, smallIntervals);
        }
    }
}