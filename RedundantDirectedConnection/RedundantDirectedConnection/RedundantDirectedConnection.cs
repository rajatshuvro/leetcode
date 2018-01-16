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

    internal class DirectedGraphBuilder
    {
        private readonly Dictionary<int, GraphNode> _vertices;
        private readonly List<Tuple<int, int>> _candidates;
        public DirectedGraphBuilder()
        {
            _vertices = new Dictionary<int, GraphNode>();
            _candidates = new List<Tuple<int, int>>();
        }

        public void AddEdges(int[,] edges)
        {
            for (var i = 0; i < edges.GetLength(0); i++)
            {
                AddEdge(edges[i, 0], edges[i, 1]);
            }
        }

        public void AddEdge(int a, int b)
        {
            if (!_vertices.ContainsKey(a)) 
                _vertices[a]= new GraphNode(a);
            if (!_vertices.ContainsKey(b))
                _vertices[b] = new GraphNode(b);

            _vertices[a].AddChild(b);
            if (_vertices[b].AddParent(a)) return ;

            _candidates.Add(Tuple.Create(a,b));
            _candidates.Add(Tuple.Create(_vertices[b].Parent, b));
        }

        private class GraphNode
        {
            public readonly int Label;
            public int Parent;
            private List<int> _children;


            public GraphNode(int label)
            {
                Label = label;
            }

            public void AddChild(int child)
            {
                if (_children==null) _children= new List<int>();

                _children.Add(child);
            }

            public bool AddParent(int parent)
            {
                // parent stays unchanged if this node already had a parent
                if (Parent != 0) return false;
                Parent = parent;
                return true;

            }
            
        }
    }
}
