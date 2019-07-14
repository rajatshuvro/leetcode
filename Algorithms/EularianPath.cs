using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Algorithms
{
    public class EularianPath<T> where T:IEquatable<T>, IComparable<T>
    {
        private readonly Graph<T> _graph;

        public EularianPath(Graph<T> graph)
        {
            _graph = graph;
        }

        public bool IsEularian()
        {
            return IsEulerian(_graph);
        }

        public IList<T> GetEularianPath(T startPoint)
        {
            return _graph.IsDirected ? GetDirectedPath(startPoint) : GetUndirectedPath(startPoint);
        }

        private IList<T> GetUndirectedPath(T startPoint)
        {
            throw new NotImplementedException();
        }

        private IList<T> GetDirectedPath(T startPoint)
        {
            // we assume the graph is eularian
            var (source, sink) = GetSourceAndSink();

            // if source exists, sink has to exist. Or both have to be null.
            // In that case we get an eularian circuit
            if (source != null ^ sink != null) return null;
            var eularianPath = new LinkedList<GraphNode<T>>();
            _graph.ClearEdgeColors();
            // if source is null, we have an eularian circuit.
            // If a start point is suggested, we use that, otherwise, we can start anywhere
            if (! _graph.Nodes.TryGetValue(new GraphNode<T>(startPoint), out var startNode))
                startNode = _graph.Nodes.First();
            startNode = source ?? startNode;

            while (startNode != null) 
            {
                var partialPath = GetPartialPath(startNode);
                MergePaths(eularianPath, partialPath, startNode);
                startNode = GetNodeWithUnusedEdges(eularianPath);
            } 
            
            return _graph.Edges.Any(x => x.Color == Color.Uncolored) ? null : eularianPath.Select(x=>x.Label).ToList();
        }

        private (GraphNode<T> source, GraphNode<T> sink) GetSourceAndSink()
        {
            GraphNode<T> source = null;
            GraphNode<T> sink = null;
            foreach (var node in _graph.Nodes)
            {
                if (node.InDegree == 0 && node.OutDegree == 0) continue;
                if (node.InDegree == node.OutDegree) continue;
                if (node.InDegree - node.OutDegree == 1) sink = node;
                if (node.OutDegree - node.InDegree == 1) source = node;
            }

            return (source, sink);
        }

        private bool MergePaths(LinkedList<GraphNode<T>> eularianPath, List<GraphNode<T>> partialPath, GraphNode<T> startNode)
        {
            if (startNode == null) return true;
            if (eularianPath.Count == 0)
            {
                foreach (var node in partialPath)
                {
                    eularianPath.AddLast(node);
                }

                return true;
            }

            var mergeNode = eularianPath.FindLast(startNode);
            if (mergeNode == null) return false; // unable to merge
            for (var i=1; i < partialPath.Count && mergeNode != null; i++)
            {
                var node = partialPath[i];
                eularianPath.AddAfter(mergeNode, new LinkedListNode<GraphNode<T>>(node));
                mergeNode = mergeNode.Next;
            }

            return true;
        }

        private List<GraphNode<T>> GetPartialPath(GraphNode<T> startNode)
        {
            var stack = new Stack<GraphNode<T>>();
            var path = new List<GraphNode<T>>(_graph.Nodes.Count);
            stack.Push(startNode);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                path.Add(node);
                //we want to create the same path every time. So selecting the min possible outgoing edge
                var minEdge = GetMinOutEdge(node); 

                if (minEdge == null) continue;

                stack.Push(minEdge.Destination);
                minEdge.Color = Color.Colored;
            }

            return path;
        }

        private GraphNode<T> GetNodeWithUnusedEdges(IEnumerable<GraphNode<T>> path)
        {
            foreach (var node in path)
            {
                if (!_graph.Neighbors.ContainsKey(node)) continue;
                foreach (var neighbor in _graph.Neighbors[node])
                {
                    foreach (var edge in _graph.GetEdges(node, neighbor))
                    {
                        if (edge.Color == Color.Uncolored) return node;
                    }
                }
            }

            return null;
        }


        private Edge<T> GetMinOutEdge(GraphNode<T> node)
        {
            if (!_graph.Neighbors.ContainsKey(node)) return null;
            GraphNode<T> minNeighbor = null;
            Edge<T> minEdge = null;
            foreach (var neighbor in _graph.Neighbors[node])
            {
                foreach (var edge in _graph.GetEdges(node, neighbor))
                {
                    if (edge.Color == Color.Colored) continue;
                    if (minEdge == null)
                    {
                        minEdge = edge;
                        minNeighbor = neighbor;
                        continue;
                    }
                    minEdge = minNeighbor.Label.CompareTo(neighbor.Label) < 0 ? minEdge : edge;
                    minNeighbor = minEdge.Destination;
                }
                
            }

            return minEdge;
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