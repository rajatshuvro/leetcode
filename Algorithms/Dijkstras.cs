using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataStructures;

namespace Algorithms
{
    public static class Dijkstras<T> where T : IEquatable<T>,IComparable<T>
    {
        public static IReadOnlyDictionary<GraphNode<T>, GraphNode<T>> RunDijkstraFrom(UndirectedGraph<T> undirectedGraph, T src)
        {
            if (!undirectedGraph.Nodes.TryGetValue(new GraphNode<T>(src), out var source)) return null;

            var predecessors = new Dictionary<GraphNode<T>, GraphNode<T>>();//keeps track of the shortest path predecessor
            //using Dijkstra's algorithm
            var priorityQ = new MinHeap<GraphNode<T>>(new GraphNode<T>(default(T)));
            foreach (var node in undirectedGraph.Nodes)
            {
                node.Weight = source.Equals(node) ? 0 : int.MaxValue;
                priorityQ.Add(node);
                predecessors[source] = null;
            }
            while (priorityQ.Count != 0)
            {
                var minNode = priorityQ.GetMin();
                minNode.Color = Color.Colored;//indicating that these nodes are done

                foreach (var neighbor in undirectedGraph.Neighbors[minNode])
                {
                    undirectedGraph.Nodes.TryGetValue(neighbor, out var neighborNode);

                    if (neighborNode.Color == Color.Colored) continue;

                    var edge = undirectedGraph.GetEdge(minNode, neighbor);
                    //if (!graph.Edges.TryGetValue(new Edge<T>(minNode, neighbor), out var edge))
                    //    throw new InvalidDataException($"failed to find edge to neighbor {minNode.Label}->{neighbor.Label}");

                    if (neighborNode.Weight > minNode.Weight + edge.Weight)
                    {
                        neighborNode.Weight = minNode.Weight + edge.Weight;
                        predecessors[neighborNode] = minNode;
                    }
                    
                }

                priorityQ.ExtractMin();
            }
            return predecessors;
        }

        public static Dictionary<T, int> GetShortestDistancesFrom(UndirectedGraph<T> undirectedGraph, T sourceLabel)
        {
            if (RunDijkstraFrom(undirectedGraph, sourceLabel) == null) return null;

            var distances = new Dictionary<T, int>(undirectedGraph.Nodes.Count);
            foreach (var node in undirectedGraph.Nodes)
            {
                distances[node.Label] = node.Weight;
            }

            return distances;
        }

        public static IReadOnlyList<T> GetShortestPath(UndirectedGraph<T> undirectedGraph, T sourceLabel, T destLabel)
        {
            if (sourceLabel.Equals(destLabel)) return new List<T>() { sourceLabel };

            var predecessors = RunDijkstraFrom(undirectedGraph, sourceLabel);
            if (predecessors == null) return null;

            var path = new List<T>() { destLabel };
            if (!undirectedGraph.Nodes.TryGetValue(new GraphNode<T>(destLabel), out var currentNode)) return null;

            while (!currentNode.Label.Equals(sourceLabel))
            {
                currentNode = predecessors[currentNode];
                path.Add(currentNode.Label);
            }
            path.Reverse();

            return path;
        }

        public static DirectedGraph<T> GetShortestPathTree(UndirectedGraph<T> undirectedGraph, T sourceLabel)
        {
            var predecessors = RunDijkstraFrom(undirectedGraph, sourceLabel);
            if (predecessors == null) return null;

            var treeEdges = predecessors.Select(kvp => new DirectedEdge<T>(kvp.Key, kvp.Value)).ToList();

            return new DirectedGraph<T>(treeEdges);
        }

    }
}