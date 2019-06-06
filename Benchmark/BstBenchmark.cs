using System;
using System.Diagnostics;
using DataStructures;

namespace Benchmark
{
    public class BstBenchmark
    {
        public static void RunBenchmark()
        {
            Process myProcess = Process.GetCurrentProcess();
            var count = 1024 * 1024;
            var items = new int[count];// one million items
            var random = new Random(13);

            for (var i = 0; i < items.Length; i++)
                items[i] = random.Next(0,1000000);

            var bst = new BinarySearchTree<int>();
            //benchmarking insertions
            var tick = DateTime.Now;
            foreach (var item in items)
            {
                bst.Add(item);
            }
            var tock = DateTime.Now;

            Console.WriteLine($"Time to insert {count} ints: {(tock-tick).TotalMilliseconds} milliseconds");

            //var peakPagedMem = myProcess.PeakPagedMemorySize64;
            //var peakVirtualMem = myProcess.PeakVirtualMemorySize64;
            var peakWorkingSet = myProcess.PeakWorkingSet64;

            Console.WriteLine($"  Peak physical memory usage : {peakWorkingSet}");
            //Console.WriteLine($"  Peak paged memory usage    : {peakPagedMem}");
            //Console.WriteLine($"  Peak virtual memory usage  : {peakVirtualMem}");
        }
    }
}