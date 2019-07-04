using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataStructures
{
    public class GraphNode<T> : IEquatable<GraphNode<T>>, IComparable<GraphNode<T>> where T : IEquatable<T>
    {
        public readonly T Label;
        public int Weight;
        public NodeColor Color;

        public GraphNode(T label,  int weight=0, NodeColor color=NodeColor.uncolored)
        {
            Label  = label;
            Weight = weight;
            Color  = color;
        }

        public bool Equals(GraphNode<T> other)
        {
            return Label.Equals(other.Label);
        }

        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }

        public int CompareTo(GraphNode<T> other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    public enum NodeColor : byte
    {
        uncolored,
        colored,
        black,
        white,
        red,
        greed,
        
    }

    public class Edge<T> : IEquatable<Edge<T>> where T : IEquatable<T>
    {
        public readonly GraphNode<T> Source;
        public readonly GraphNode<T> Destination;
        public int Weight;
        public readonly bool IsDirected;

        public Edge(GraphNode<T> source, GraphNode<T> destination, bool isDirected=false, int weight = 0)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
            IsDirected = isDirected;
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode() ^ Destination.GetHashCode();
        }


        public bool Equals(Edge<T> other)
        {
            return IsDirected? Source.Equals(other.Source) && Destination.Equals(other.Destination) :
                Source.Equals(other.Source) && Destination.Equals(other.Destination)|| Source.Equals(other.Destination) && Destination.Equals(other.Source);
        }
    }

    public class Graph<T> where T:IEquatable<T>
    {
        public readonly bool IsDirected;
        public readonly HashSet<GraphNode<T>> Nodes;
        public readonly HashSet<Edge<T>> Edges;
        public readonly Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> Neighbors;

        public int NumNodes => Nodes.Count;
        public int NumEdges => Edges.Count;

        public Graph(bool isDirected, IEnumerable<Edge<T>> edges)
        {
            IsDirected = isDirected;
            Edges     = new HashSet<Edge<T>>();
            Nodes     = new HashSet<GraphNode<T>>();
            Neighbors = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>();

            foreach (var edge in edges)
            {
                Nodes.Add(edge.Source);
                Nodes.Add(edge.Destination);
                Edges.Add(edge);

                AddNeighbor(edge.Source, edge.Destination);

                if (! isDirected) AddNeighbor(edge.Destination, edge.Source);
            }
            
        }

        private void AddNeighbor(GraphNode<T> source, GraphNode<T> destination)
        {
            if (Neighbors.TryGetValue(source, out var neighbors))
            {
                neighbors.Add(destination);
            }
            else Neighbors[source] = new HashSet<GraphNode<T>>{ destination };

        }

        public Dictionary<T, int> GetShortestDistancesFrom(T sourceLabel)
        {
            if (RunDijkstraFrom(sourceLabel)==null) return null;

            var distances = new Dictionary<T, int>(Nodes.Count);
            foreach (var node in Nodes)
            {
                distances[node.Label] = node.Weight;
            }

            return distances;
        }

        public  IReadOnlyList<T> GetShortestPath(T sourceLabel, T destLabel)
        {
            if (sourceLabel.Equals(destLabel)) return new List<T>(){sourceLabel};

            var predecessors = RunDijkstraFrom(sourceLabel);
            if ( predecessors == null) return null;

            var path = new List<T>(){destLabel};
            if (!Nodes.TryGetValue(new GraphNode<T>(destLabel), out var currentNode)) return null;

            while (!currentNode.Label.Equals(sourceLabel))
            {
                currentNode = predecessors[currentNode];
                path.Add(currentNode.Label);
            }
            path.Reverse();

            return path;
        }

        public Graph<T> GetShortestPathTree(T sourceLabel)
        {
            var predecessors = RunDijkstraFrom(sourceLabel);
            if (predecessors == null) return null;

            var treeEdges = predecessors.Select(kvp => new Edge<T>(kvp.Key, kvp.Value)).ToList();

            return new Graph<T>(false, treeEdges);
        }

        public IReadOnlyDictionary<GraphNode<T>, GraphNode<T>> RunDijkstraFrom(T src)
        {
            if (!Nodes.TryGetValue(new GraphNode<T>(src), out var source)) return null;

            var predecessors = new Dictionary<GraphNode<T>, GraphNode<T>>();//keeps track of the shortest path predecessor
            //using Dijkstra's algorithm
            var priorityQ = new MinHeap<GraphNode<T>>(new GraphNode<T>(default(T)));
            foreach (var node in Nodes)
            {
                node.Weight = source.Equals(node) ? 0 : int.MaxValue;
                priorityQ.Add(node);
                predecessors[source] = null;
            }
            while (priorityQ.Count != 0)
            {
                var minNode = priorityQ.GetMin();
                minNode.Color = NodeColor.colored;//indicating that these nodes are done

                foreach (var neighbor in Neighbors[minNode])
                {
                    Nodes.TryGetValue(neighbor, out var neighborNode);

                    if (neighborNode.Color == NodeColor.colored) continue;

                    if (!Edges.TryGetValue(new Edge<T>(minNode, neighbor), out var edge))
                        throw new InvalidDataException($"failed to find edge to neighbor {minNode.Label}->{neighbor.Label}");
                    int edgeWeight = edge.Weight;

                    if (neighborNode.Weight > minNode.Weight + edgeWeight)
                    {
                        neighborNode.Weight = minNode.Weight + edgeWeight;
                        predecessors[neighborNode] = minNode;
                    }
                }

                priorityQ.ExtractMin();
            }
            return predecessors;
        }

        public void ClearNodeColors()
        {
            foreach (var node in Nodes)
            {
                node.Color = NodeColor.uncolored;
            }
        }
        public void ClearNodeWeights()
        {
            foreach (var node in Nodes)
            {
                node.Weight = 0;
            }
        }

        public bool IsBipartite()
        {
            foreach (var node in Nodes)
            {
                //if a node is colored, it has been assigned to a component and checked
                if(node.Color != NodeColor.uncolored) continue;
                
                if (!IsComponentBipartite(node)) return false;
            }
            ClearNodeColors();
            return true;
        }

        private bool IsComponentBipartite(GraphNode<T> startNode)
        {
            var nodeStack = new Stack<GraphNode<T>>();
            startNode.Color = NodeColor.black;
            nodeStack.Push(startNode);
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                foreach (var neighbor in Neighbors[node])
                {
                    if (neighbor.Color == NodeColor.uncolored)
                    {
                        neighbor.Color = node.Color == NodeColor.black ? NodeColor.white : NodeColor.black;
                        nodeStack.Push(neighbor);
                        continue;
                    }
                    if (neighbor.Color == node.Color) return false;

                }
            }
            
            return true;
        }
    }
}