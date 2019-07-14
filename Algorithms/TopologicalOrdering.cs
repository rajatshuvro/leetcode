using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public class TopologicalOrdering<T> where T:IEquatable<T>,IComparable<T>
    {
        private DirectedGraph<T> _directedGraph;
        private List<T> _ordering;

        public TopologicalOrdering(DirectedGraph<T> directedGraph)
        {
            _directedGraph = directedGraph;
            _ordering = new List<T>(_directedGraph.Nodes.Count);
        }

        public List<T> GetTopologicalOrdering()
        {
            _ordering.Clear();
            foreach (var node in _directedGraph.Nodes)
            {
                if (node.Color == Color.Uncolored) Visit(node);
            }

            if (_ordering.Count != _directedGraph.Nodes.Count) _ordering.Clear();

            return _ordering;
        }

        private void Visit(GraphNode<T> node)
        {
            if (node.Color == Color.Black) return;
            if (node.Color == Color.White) return;// cycle detected

            if (!_directedGraph.Neighbors.ContainsKey(node))
            {
                //node has no successor
                node.Color = Color.Black;
                _ordering.Add(node.Label);
                return;
            }

            node.Color = Color.White;
            foreach (var neighbor in _directedGraph.Neighbors[node])
            {
                Visit(neighbor);
                if(neighbor.Color != Color.Black) return;
            }

            node.Color = Color.Black;
            _ordering.Add(node.Label);
        }
    }
}