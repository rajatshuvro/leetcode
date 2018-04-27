using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataStructures
{
    public class Node<T> : IEquatable<Node<T>>, IComparable<Node<T>> where T : IEquatable<T>
    {
        public readonly T Label;
        public int Weight;
        public char Color;

        public Node(T label,  int weight=0, char color='b')
        {
            Label  = label;
            Weight = weight;
            Color  = color;
        }

        public bool Equals(Node<T> other)
        {
            return Label.Equals(other.Label);
        }

        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }

        public int CompareTo(Node<T> other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    public class Edge<T> : IEquatable<Edge<T>> where T : IEquatable<T>
    {
        public readonly Node<T> Source;
        public readonly Node<T> Destination;
        public int Weight;
        public readonly bool IsDirected;

        public Edge(Node<T> source, Node<T> destination, bool isDirected=false, int weight = 0)
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
        private readonly HashSet<Node<T>> _nodes;
        private readonly HashSet<Edge<T>> _edges;
        private readonly Dictionary<Node<T>, HashSet<Node<T>>> _neighbors;

        public int NumNodes => _nodes.Count;
        public int NumEdges => _edges.Count;

        public Graph(bool isDirected, IEnumerable<Edge<T>> edges)
        {
            IsDirected = isDirected;
            _edges     = new HashSet<Edge<T>>();
            _nodes     = new HashSet<Node<T>>();
            _neighbors = new Dictionary<Node<T>, HashSet<Node<T>>>();

            foreach (var edge in edges)
            {
                _nodes.Add(edge.Source);
                _nodes.Add(edge.Destination);
                _edges.Add(edge);

                AddNeighbor(edge.Source, edge.Destination);

                if (! isDirected) AddNeighbor(edge.Destination, edge.Source);
            }
            
        }

        private void AddNeighbor(Node<T> source, Node<T> destination)
        {
            if (_neighbors.TryGetValue(source, out var neighbors))
            {
                neighbors.Add(destination);
            }
            else _neighbors[source] = new HashSet<Node<T>>{ destination };

        }

        public Dictionary<T, int> GetShortestDistancesFrom(T sourceLabel)
        {
            if (RunDijkstraFrom(sourceLabel)==null) return null;

            var distances = new Dictionary<T, int>(_nodes.Count);
            foreach (var node in _nodes)
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
            if (!_nodes.TryGetValue(new Node<T>(destLabel), out var currentNode)) return null;

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

        public IReadOnlyDictionary<Node<T>, Node<T>> RunDijkstraFrom(T src)
        {
            if (!_nodes.TryGetValue(new Node<T>(src), out var source)) return null;

            var predecessors = new Dictionary<Node<T>, Node<T>>();//keeps track of the shortest path predecessor
            //using Dijkstra's algorithm
            var priorityQ = new MinHeap<Node<T>>();
            foreach (var node in _nodes)
            {
                node.Weight = source.Equals(node) ? 0 : int.MaxValue;
                priorityQ.Add(node);
                predecessors[source] = null;
            }
            while (priorityQ.Count != 0)
            {
                var minNode = priorityQ.GetMin();
                minNode.Color = 'w';//indicating that these nodes are done

                foreach (var neighbor in _neighbors[minNode])
                {
                    _nodes.TryGetValue(neighbor, out var neighborNode);

                    if (neighborNode.Color == 'w') continue;

                    if (!_edges.TryGetValue(new Edge<T>(minNode, neighbor), out var edge))
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

        public bool IsBipartite()
        {
            throw new NotImplementedException();
        }
    }
}