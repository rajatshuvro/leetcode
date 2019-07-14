using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Algorithms
{
    public class EularianPath<T> where T:IEquatable<T>, IComparable<T>
    {
        private readonly DirectedGraph<T> _directedGraph;

        public EularianPath(DirectedGraph<T> directedGraph)
        {
            _directedGraph = directedGraph;
        }

        public IList<T> GetEularianPath(T startPoint)
        {
            return GetDirectedPath(startPoint);
        }

        public IList<T> GetDirectedPath(T startPoint)
        {
            // we assume the graph is eularian
            var (source, sink) = GetSourceAndSink();

            // if source exists, sink has to exist. Or both have to be null.
            // In that case we get an eularian circuit
            if (source != null ^ sink != null) return null;
            var eularianPath = new LinkedList<GraphNode<T>>();
            _directedGraph.ClearEdgeColors();
            // if source is null, we have an eularian circuit.
            // If a start point is suggested, we use that, otherwise, we can start anywhere
            if (! _directedGraph.Nodes.TryGetValue(new GraphNode<T>(startPoint), out var startNode))
                startNode = _directedGraph.Nodes.First();
            startNode = source ?? startNode;

            while (startNode != null) 
            {
                var partialPath = GetPartialPath(startNode);
                MergePaths(eularianPath, partialPath, startNode);
                startNode = GetNodeWithUnusedEdges(eularianPath);
            } 
            
            return _directedGraph.Edges.Any(x => x.Color == Color.Uncolored) ? null : eularianPath.Select(x=>x.Label).ToList();
        }

        private (GraphNode<T> source, GraphNode<T> sink) GetSourceAndSink()
        {
            GraphNode<T> source = null;
            GraphNode<T> sink = null;
            foreach (var node in _directedGraph.Nodes)
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
            var path = new List<GraphNode<T>>(_directedGraph.Nodes.Count);
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
                if (!_directedGraph.Neighbors.ContainsKey(node)) continue;
                foreach (var neighbor in _directedGraph.Neighbors[node])
                {
                    foreach (var edge in _directedGraph.GetEdges(node, neighbor))
                    {
                        if (edge.Color == Color.Uncolored) return node;
                    }
                }
            }

            return null;
        }


        private DirectedEdge<T> GetMinOutEdge(GraphNode<T> node)
        {
            if (!_directedGraph.Neighbors.ContainsKey(node)) return null;
            GraphNode<T> minNeighbor = null;
            DirectedEdge<T> minEdge = null;
            foreach (var neighbor in _directedGraph.Neighbors[node])
            {
                foreach (var edge in _directedGraph.GetEdges(node, neighbor))
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

        public static bool IsDirectedEulerian(DirectedGraph<T> directedGraph)
        {
            var sourceNodeCount = 0;
            var sinkNodeCount = 0;
            var nodes = new List<GraphNode<T>>();

            foreach (var node in directedGraph.Nodes)
            {
                if (node.InDegree ==0 && node.OutDegree ==0) continue;
                nodes.Add(node);
                if (node.InDegree == node.OutDegree) continue;
                if (node.InDegree - node.OutDegree == 1 ) sinkNodeCount++;
                if (node.OutDegree - node.InDegree == 1 ) sourceNodeCount++;
            }
            //all nodes with degree>0 have to be in the same component
            return sinkNodeCount == 1 && sourceNodeCount == 1 && GraphProperties<T>.InSameConnectedComponent(directedGraph, nodes);
        }

        public static bool IsUndirectedEulerian(DirectedGraph<T> directedGraph)
        {
            var oddDegreeNodeCount = 0;
            var nodeList = new List<GraphNode<T>>();
            foreach (var node in directedGraph.Nodes)
            {
                if(node.Degree==0) continue;
                nodeList.Add(node);
                if (node.Degree % 2 != 0) oddDegreeNodeCount++;
            }

            return !(oddDegreeNodeCount == 2 || oddDegreeNodeCount == 0) && GraphProperties<T>.InSameConnectedComponent(directedGraph, nodeList);
        }
    }
}