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
            result &= UnitTest(new [,] {{2, 1},{3, 1},{4, 2},{1, 4}}, new[] {2, 1});
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
            Console.WriteLine($"Failed for: {PrintEdges(edges)}.\nExpected [{expectedEdge[0]}->{expectedEdge[1]}], observed [{observedEdge[0]}->{observedEdge[1]}]");
            return false;
        }

        public static int[] FindRedundantConnection(int[,] edges)
        {
            var dirGraph = new DirectedGraphBuilder<int>();
            int a = -1, b = -1;
            for (var i = 0; i < edges.GetLength(0); i++)
            {
                if (!unionFinder.Unite(edges[i, 0], edges[i, 1])) continue;
                a = edges[i, 0];
                b = edges[i, 1];
            }
            return new[] { a, b };
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

    internal class DirectedGraphBuilder<T> where T:IEquatable<T>
    {
        private Dictionary<T, GraphNode<T>> _vertices;
        public DirectedGraphBuilder()
        {
            _vertices = new Dictionary<T, GraphNode<T>>();
        }

        public bool AddEdge(T a, T b)
        {
            if (_vertices.ContainsKey(b) && _vertices[b].Parent != null) return false;
            if (!_vertices.ContainsKey(a)) 
                _vertices[a]= new GraphNode<T>(b);
            _vertices[a].AddChild(b);
            return true;
        }

        private class GraphNode<T> where T:IEquatable<T>
        {
            public readonly T Parent;
            private List<T> _children;

            public GraphNode(T parent)
            {
                Parent = parent;
            }

            public void AddChild(T child)
            {
                if (_children==null) _children= new List<T>();

                _children.Add(child);
            }

            public bool IsParentOf(T child)
            {
                return _children != null && _children.Contains(child);
            }
        }
    }
}
