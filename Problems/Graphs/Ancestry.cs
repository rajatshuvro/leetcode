using System.Collections.Generic;
using DataStructures;

namespace Problems.Graphs
{
    public class Ancestry
    {
        // given a directed graph that contains an edge between parents and children, determine if two nodes are related.
        // you can assume there is a function that returns parents of a node 

        private readonly DirectedGraph<uint> _ancestry;
        private readonly Dictionary<uint, GraphNode<uint>> _nodes;
        public Ancestry(IEnumerable<(uint, uint, uint)> trios)
        {
            // trio = child, mother, father
            // 0 indicates unknown. Valid values are 1-uint.max;
            _nodes = new Dictionary<uint, GraphNode<uint>>();
            var edges = new Dictionary<(uint, uint), DirectedEdge<uint>>();
            foreach (var (child, mother, father) in trios)
            {
                _nodes.TryAdd(child, new GraphNode<uint>(child));

                if (mother != 0)
                {
                    _nodes.TryAdd(mother, new GraphNode<uint>(mother));
                    edges.TryAdd((child, mother), new DirectedEdge<uint>(_nodes[child], _nodes[mother]));
                }

                if (father != 0)
                {
                    _nodes.TryAdd(father, new GraphNode<uint>(father));
                    edges.TryAdd((child, father), new DirectedEdge<uint>(_nodes[child], _nodes[father]));
                }

            }

            _ancestry = new DirectedGraph<uint>(_nodes.Values, edges.Values);
        }

        public bool HasCommonAncestry(uint person1, uint person2)
        {
            var node1 = _nodes[person1];
            var node2 = _nodes[person2];

            // all of p1's ancestors will be colored white
            var whiteNodes = new HashSet<uint>(){person1};
            // all of p2's ancestors will be colored black;
            var blackNodes = new HashSet<uint>(){person2};

            //if any ancestor of p1 is found to be black or if any of p2's ancestors are found white, we return true;
            var frontier1 = new Queue<GraphNode<uint>>(_ancestry.GetNeighbors(node1));
            var frontier2 = new Queue<GraphNode<uint>>(_ancestry.GetNeighbors(node2));

            while (frontier1.Count > 0 || frontier2.Count > 0)
            {
                var count = frontier1.Count;
                for (var i = 0; i < count; i++)
                {
                    var ancestor = frontier1.Dequeue();
                    if (blackNodes.Contains(ancestor.Label)) return true;
                    whiteNodes.Add(ancestor.Label);

                    foreach (var parent in _ancestry.GetNeighbors(ancestor))
                    {
                        frontier1.Enqueue(parent);
                    }
                }

                count = frontier2.Count;
                for (var i = 0; i < count; i++)
                {
                    var ancestor = frontier2.Dequeue();
                    if (whiteNodes.Contains(ancestor.Label)) return true;
                    blackNodes.Add(ancestor.Label);

                    foreach (var parent in _ancestry.GetNeighbors(ancestor))
                    {
                        frontier2.Enqueue(parent);
                    }
                }

            }
            return false;
        }
    }
}