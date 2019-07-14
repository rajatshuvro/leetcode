using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public class GraphComponents<T> where T:IEquatable<T>, IComparable<T>
    {
        private readonly IDictionary<GraphNode<T>, T> _nodeToScc;
        private readonly List<GraphNode<T>> _dfsOrder;
        public GraphComponents()
        {
            _nodeToScc     = new Dictionary<GraphNode<T>, T>();
            _dfsOrder      = new List<GraphNode<T>>();
        }

        public IDictionary<GraphNode<T>, T> DfsConnectedComponents(UndirectedGraph<T> graph)
        {
            _nodeToScc.Clear();
            
            graph.ClearNodeColors();
            foreach (var node in graph.Nodes)
            {
                if(node.Color == Color.Colored) continue;
                ComponentVisit(node, node.Label, graph.Neighbors);
            }

            return _nodeToScc;
        }

        private void ComponentVisit(GraphNode<T> node, T sccLabel, Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> neighbors)
        {
            _nodeToScc[node] = sccLabel;
            node.Color = Color.Colored;

            if (!neighbors.ContainsKey(node)) return;
            foreach (var neighbor in neighbors[node])
            {
                if(neighbor.Color != Color.Colored) ComponentVisit(neighbor, sccLabel, neighbors);
            }
        }
        // implements Kosaraju's algorithm (https://en.wikipedia.org/wiki/Kosaraju%27s_algorithm)
        public IDictionary<GraphNode<T>, T> KosarajuScc(DirectedGraph<T> graph)
        {
            _nodeToScc.Clear();
            
            var reverseOrder = GetDepthFirstOrder(graph);
            reverseOrder.Reverse();
            graph.ClearNodeColors();

            var inNeighbors = graph.GetInNeighbors();
            foreach (var node in reverseOrder)
            {
                if(node.Color == Color.Colored) continue;
                ComponentVisit(node, node.Label, inNeighbors);
            }

            return _nodeToScc;
        }

        
        public List<GraphNode<T>> GetDepthFirstOrder(DirectedGraph<T> graph)
        {
            graph.ClearNodeColors();
            _dfsOrder.Clear();

            foreach (var node in graph.Nodes)
            {
                if (node.Color == Color.Colored) continue;
                DfsVisit(graph, node);
            }

            return _dfsOrder;
        }

        private void DfsVisit(DirectedGraph<T> graph, GraphNode<T> node)
        {
            if (node.Color == Color.Colored) return;

            node.Color = Color.Colored;
            _dfsOrder.Add(node);

            if (!graph.Neighbors.ContainsKey(node)) return;
            foreach (var neighbor in graph.Neighbors[node])
            {
                DfsVisit(graph, neighbor);
            }

        }
    }
}