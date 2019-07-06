using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public class GraphComponents<T> where T:IEquatable<T>
    {
        private readonly Graph<T> _graph;
        private readonly IDictionary<GraphNode<T>, T> _nodeToScc;
        private readonly List<GraphNode<T>> _dfsOrder;
        public GraphComponents(Graph<T> graph)
        {
            _graph     = graph;
            _nodeToScc = new Dictionary<GraphNode<T>, T>(graph.Nodes.Count);
            _dfsOrder  = new List<GraphNode<T>>(graph.Nodes.Count);
        }

        public IDictionary<GraphNode<T>, T> GetConnectedComponents()
        {
            if (_graph.IsDirected) KosarajuScc();
            else DfsConnectedComponents();
            return _nodeToScc;
        }

        private void DfsConnectedComponents()
        {
            _graph.ClearNodeColors();
            foreach (var node in _graph.Nodes)
            {
                if(node.Color == Color.Colored) continue;
                ComponentVisit(node, node.Label);
            }
        }

        private void ComponentVisit(GraphNode<T> node, T sccLabel, Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> neighbors=null)
        {
            _nodeToScc[node] = sccLabel;
            node.Color = Color.Colored;

            if (neighbors == null) neighbors = _graph.Neighbors;

            if (!neighbors.ContainsKey(node)) return;
            foreach (var neighbor in neighbors[node])
            {
                if(neighbor.Color != Color.Colored) ComponentVisit(neighbor, sccLabel, neighbors);
            }
        }
        // implements Kosaraju's algorithm (https://en.wikipedia.org/wiki/Kosaraju%27s_algorithm)
        private void KosarajuScc()
        {
            var reverseOrder = GetDepthFirstOrder();
            reverseOrder.Reverse();
            _graph.ClearNodeColors();

            var inNeighbors = _graph.GetInNeighbors();
            foreach (var node in reverseOrder)
            {
                if(node.Color == Color.Colored) continue;
                ComponentVisit(node, node.Label, inNeighbors);
            }
        }

        
        public List<GraphNode<T>> GetDepthFirstOrder()
        {
            _graph.ClearNodeColors();
            _dfsOrder.Clear();

            foreach (var node in _graph.Nodes)
            {
                if (node.Color == Color.Colored) continue;
                DfsVisit(node);
            }

            return _dfsOrder;
        }

        private void DfsVisit(GraphNode<T> node)
        {
            if (node.Color == Color.Colored) return;

            node.Color = Color.Colored;
            _dfsOrder.Add(node);

            if (!_graph.Neighbors.ContainsKey(node)) return;
            foreach (var neighbor in _graph.Neighbors[node])
            {
                DfsVisit(neighbor);
            }

        }
    }
}