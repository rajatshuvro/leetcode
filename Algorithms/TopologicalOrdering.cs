using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public class TopologicalOrdering<T> where T:IEquatable<T>
    {
        private Graph<T> _graph;
        private List<T> _ordering;

        public TopologicalOrdering(Graph<T> graph)
        {
            _graph = graph;
            _ordering = new List<T>(_graph.Nodes.Count);
        }

        public List<T> GetTopologicalOrdering()
        {
            _ordering.Clear();
            foreach (var node in _graph.Nodes)
            {
                if (node.Color == Color.Uncolored) Visit(node);
            }

            if (_ordering.Count != _graph.Nodes.Count) _ordering.Clear();

            return _ordering;
        }

        private void Visit(GraphNode<T> node)
        {
            if (node.Color == Color.Black) return;
            if (node.Color == Color.White) return;// cycle detected

            if (!_graph.Neighbors.ContainsKey(node))
            {
                //node has no successor
                node.Color = Color.Black;
                _ordering.Add(node.Label);
                return;
            }

            node.Color = Color.White;
            foreach (var neighbor in _graph.Neighbors[node])
            {
                Visit(neighbor);
                if(neighbor.Color != Color.Black) return;
            }

            node.Color = Color.Black;
            _ordering.Add(node.Label);
        }
    }
}