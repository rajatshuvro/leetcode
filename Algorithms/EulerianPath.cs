using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public class EulerianPath<T> where T:IEquatable<T>, IComparable<T>
    {
        private Graph<T> _graph;
        private IEnumerable<T> _eularianPath;

        public EulerianPath(Graph<T> graph)
        {
            _graph = graph;
        }

        public bool IsEularian()
        {
            return IsEulerian(_graph);
        }

        public IEnumerable<T> GetEularianPath()
        {
            return _graph.IsDirected ? GetDirectedPath() : GetUndirectedPath();
        }

        private IEnumerable<T> GetUndirectedPath()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<T> GetDirectedPath()
        {
            GraphNode<T> sourceNode = null;
            GraphNode<T> sinkNode = null;
            var nodes = new List<GraphNode<T>>();
            foreach (var node in _graph.Nodes)
            {
                if (node.InDegree == 0 && node.OutDegree == 0) continue;
                nodes.Add(node);
                if (node.InDegree == node.OutDegree) continue;
                if (node.InDegree - node.OutDegree == 1) sinkNode = node;
                if (node.OutDegree - node.InDegree == 1) sourceNode = node;
                
            }

            // sanity checks
            if (sourceNode == null && nodes.Count == 0) return null;
            // if source exists, sink has to exist. Or both have to be null.
            // In that case we get an eularian circuit
            if (sourceNode != null ^ sinkNode != null) return null;

            _graph.ClearEdgeColors();
            var stack = new Stack<GraphNode<T>>();
            var path = new List<T>(_graph.Nodes.Count);
            // if source is null, we have an eularian circuit. We can start anywhere
            stack.Push(sourceNode ?? nodes[0]);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                path.Add(node.Label);
                var minNeighbor = GetMinNeighbor(node);//we want to create one path every time. So selecting the min possible neighbor

                if (minNeighbor == null) continue;

                stack.Push(minNeighbor);
                //color the edge
                _graph.Edges.TryGetValue(new Edge<T>(node, minNeighbor), out var edge);
                edge.Color = Color.Colored;
            }
            // for eularian circuits, we have to increment nodes count
            var expectedPathLength = sourceNode == null ? nodes.Count + 1 : nodes.Count;
            return path.Count!= expectedPathLength ? null: path;
        }

        private GraphNode<T> GetMinNeighbor(GraphNode<T> node)
        {
            if (!_graph.Neighbors.ContainsKey(node)) return null;
            GraphNode<T> minNeighbor = null;
            foreach (var neighbor in _graph.Neighbors[node])
            {
                _graph.Edges.TryGetValue(new Edge<T>(node, neighbor), out var edge);
                if(edge.Color == Color.Colored) continue;
                if (minNeighbor == null)
                {
                    minNeighbor = neighbor;
                    continue;
                }
                minNeighbor = minNeighbor.Label.CompareTo(neighbor.Label) < 0 ? minNeighbor : neighbor;
            }

            return minNeighbor;
        }

        public static bool IsEulerian(Graph<T> graph)
        {
            return !graph.IsDirected ? IsUndirectedEulerian(graph) : IsDirectedEulerian(graph);
        }

        private static bool IsDirectedEulerian(Graph<T> graph)
        {
            var sourceNodeCount = 0;
            var sinkNodeCount = 0;
            var nodes = new List<GraphNode<T>>();

            foreach (var node in graph.Nodes)
            {
                if (node.InDegree ==0 && node.OutDegree ==0) continue;
                nodes.Add(node);
                if (node.InDegree == node.OutDegree) continue;
                if (node.InDegree - node.OutDegree == 1 ) sinkNodeCount++;
                if (node.OutDegree - node.InDegree == 1 ) sourceNodeCount++;
            }
            //all nodes with degree>0 have to be in the same component
            return sinkNodeCount == 1 && sourceNodeCount == 1 && GraphProperties<T>.InSameConnectedComponent(graph, nodes);
        }

        private static bool IsUndirectedEulerian(Graph<T> graph)
        {
            var oddDegreeNodeCount = 0;
            var nodeList = new List<GraphNode<T>>();
            foreach (var node in graph.Nodes)
            {
                if(node.Degree==0) continue;
                nodeList.Add(node);
                if (node.Degree % 2 != 0) oddDegreeNodeCount++;
            }

            return !(oddDegreeNodeCount == 2 || oddDegreeNodeCount == 0) && GraphProperties<T>.InSameConnectedComponent(graph, nodeList);
        }
    }
}