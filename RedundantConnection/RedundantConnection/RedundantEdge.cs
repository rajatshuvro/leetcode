using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedundantConnection
{
    class RedundantEdge
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Identifying redundent edge in undirected graph!");

            var result = UnitTest(new[,] { { 1, 2 }, { 1, 3 }, { 2, 3 } }, new[] { 2, 3 });
            result &= UnitTest(new[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 1, 4 }, { 1, 5 } }, new[] { 1, 4 });
            result &= UnitTest(new[,] { { 3, 4 }, { 1, 2 }, { 2, 4 }, { 3, 5 }, { 2, 5 } }, new[] { 2, 5 });
            if (result)
                Console.WriteLine("Passed all tests");

            Console.ReadKey();
        }

        private static bool UnitTest(int[,] edges, int[] expectedEdge)
        {
            var observedEdge = FindRedundantConnection(edges);

            if (expectedEdge.SequenceEqual(observedEdge))
            {
                Console.WriteLine($"Passed case: {PrintEdges(edges)}");
                return true;
            }
            Console.WriteLine($"Failed for: {PrintEdges(edges)}.\nExpected [{expectedEdge[0]},{expectedEdge[1]}], observed [{observedEdge[0]},{observedEdge[1]}]");
            return false;
        }

        

        
        //using union find to detect cycles
        
    }
}
