using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedundantDirectedConnection
{
    class RedundantDirectedConnection
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Identifying redundent edge in directed graph!");

            var result = UnitTest(new[,] { { 1, 2 }, { 1, 3 }, { 2, 3 } }, new[] { 2, 3 });
            result &= UnitTest(new[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 1 }, { 1, 5 } }, new[] { 4, 1 });
            result &= UnitTest(new[,] { { 3, 4 }, { 1, 2 }, { 2, 3 }, { 3, 5 }, { 5, 2 } }, new[] { 5, 2 });
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

        private static List<int> FindRedundantConnection(int[,] edges)
        {
            throw new NotImplementedException();
        }

        private static string PrintEdges(int[,] edges)
        {
            var sb = new StringBuilder();
            sb.Append('[');
            for (var i = 0; i < edges.GetLength(0); i++)
                sb.Append($"[{edges[i, 0]}->{edges[i, 1]}]");
            sb.Append(']');

            return sb.ToString();
        }

    }
}
