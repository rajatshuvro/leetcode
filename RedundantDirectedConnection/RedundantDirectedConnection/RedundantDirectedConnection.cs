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
            var dirGraph = new DirectedGraphBuilder(edges);
            
            return dirGraph.FindRedundantEdge();
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
        private readonly Dictionary<int, Neighbors> _vertices;
        private int _root;
        private readonly List<Tuple<int, int>> _candidates;
        public DirectedGraphBuilder(int[,] edges)
        {
            _vertices = new Dictionary<int, Neighbors>();
            _candidates = new List<Tuple<int, int>>();

            for (var i = 0; i < edges.GetLength(0); i++)
            {
                AddEdge(edges[i, 0], edges[i, 1]);
            }

            //locate the root (if any)
            foreach (var keyValuePair in _vertices)
            {
                var vertex = keyValuePair.Value;
                if (vertex.Parent != -1) continue;
                _root = keyValuePair.Key;
                break;
            }
        }

        
        public void AddEdge(int a, int b)
        {
            if (!_vertices.ContainsKey(a)) 
                _vertices[a]= new Neighbors(a);
            if (!_vertices.ContainsKey(b))
                _vertices[b] = new Neighbors(b);

            _vertices[a].AddChild(b);
            if (_vertices[b].AddParent(a)) return ;

            _candidates.Add(Tuple.Create(a,b));
            _candidates.Add(Tuple.Create(_vertices[b].Parent, b));
        }

        private class Neighbors
        {
            public int Parent;
            private List<int> _children;


            public Neighbors(int label)
            {
                Parent = -1;
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

        public int[] FindRedundantEdge()
        {
            // check for cycles
            // if found add latest edge to candidate list
            // remove edges one by one and check if tree is valid

        }
    }
}
