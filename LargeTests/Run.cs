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
            var max = 2_000_000_000;
            var count = 3_000_000;
            var largeIntervalSize = 20 * 16 * 1024;
            var smallIntervalSize = 20 * 8 * 1024;
            
            var nums = IntervalCoverUtilities.GetUniformRandomNums(count, min, max);
            
            var largeIntervals = IntervalCoverUtilities.GetIntervals(min, max, largeIntervalSize);
            var smallIntervals = IntervalCoverUtilities.GetIntervals(min, max, smallIntervalSize);

            Console.WriteLine($"Using {largeIntervals.Count} large and {smallIntervals.Count} small intervals.");

            IntervalCoverUtilities.BenchmarkIntervalCover(nums, largeIntervals, smallIntervals );
            IntervalCoverUtilities.BenchmarkIntervalCover(nums, largeIntervals);
            IntervalCoverUtilities.BenchmarkIntervalCover(nums, smallIntervals);

            Console.WriteLine("Testing grouped uniform distributions");
            var groupSize =  20_000;
            var gapSize = 1_000_000;
            var groupedNums = IntervalCoverUtilities.GetGroupedNums(count, groupSize, gapSize, min, max);
            
            IntervalCoverUtilities.BenchmarkIntervalCover(groupedNums, largeIntervals, smallIntervals );
            IntervalCoverUtilities.BenchmarkIntervalCover(groupedNums, largeIntervals);
            IntervalCoverUtilities.BenchmarkIntervalCover(groupedNums, smallIntervals);
        }
    }
}