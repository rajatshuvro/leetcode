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
            var unionFinder = new UnionFinder<int>();
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

        class UnionFinder<T> where T : IEquatable<T>, IComparable<T>
        {
            private readonly Dictionary<T, T> _founder;
            private readonly Dictionary<T, List<T>> _clans;

            public UnionFinder()
            {
                _founder = new Dictionary<T, T>();
                _clans = new Dictionary<T, List<T>>();
            }
            // returns true if a and b both belong to the same clan
            public bool Unite(T a, T b)
            {
                // both items are present, we need to merge two clans if different
                if (_founder.ContainsKey(a) && _founder.ContainsKey(b))
                {
                    if (_founder[a].Equals(_founder[b]))
                        return true;

                    var founderB = _founder[b];
                    foreach (var member in _clans[founderB])
                    {
                        _founder[member] = _founder[a];
                    }
                    _clans[_founder[a]].AddRange(_clans[founderB]);
                    _clans.Remove(founderB);
                    return false;
                }
                // at least one item is present
                if (_founder.ContainsKey(a))
                {
                    _founder[b] = _founder[a];
                    _clans[_founder[a]].Add(b);
                    return false;
                }
                if (_founder.ContainsKey(b))
                {
                    _founder[a] = _founder[b];
                    _clans[_founder[b]].Add(a);
                    // we are assigning two parents to a node, that is an error
                    return true;
                }
                // no items present
                _founder[a] = a;
                _founder[b] = a;
                _clans.Add(a, new List<T> { a, b });
                return false;
            }
        }

    }
}
