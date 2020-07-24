using System;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    static class RunBenchmark
    {
        static void Main(string[] args)
        {
            Console.WriteLine("On your bench-mark! 1..2..3..Go");
            //ArrayBstBenchmark.RunBenchmark();
            //BstBenchmark.RunBenchmark();
            
            var summary = BenchmarkRunner.Run<ElasticArrayVsList>();
        }
    }
}
