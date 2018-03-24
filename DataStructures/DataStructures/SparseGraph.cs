using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructures
{
    public class Node:IEquatable<Node>
    {
        public readonly string Label;
        public char Color;
        public int Weight;
        private readonly Dictionary<Node, int> _weightedNeighbors;
        public IEnumerable<Node> Neighbors => _weightedNeighbors.Keys;

        public Node(string label, char c = 'b', int weight = int.MaxValue)
        {
            Label     = label;
            Color     = c;
            Weight    = weight;
            _weightedNeighbors = new Dictionary<Node, int>();
        }

        public bool TryAddNeighbor(Node neighbor, int weight)
        {
            if (_weightedNeighbors.TryGetValue(neighbor, out var oldWeight))
                return neighbor.Weight == oldWeight;

            _weightedNeighbors.Add(neighbor,weight);
            return true;
        }

        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Label, other.Label);
        }

        public override int GetHashCode()
        {
            return (Label != null ? Label.GetHashCode() : 0);
        }
    }

    public class Edge:IEquatable<Edge>
    {
        public readonly Node Source;
        public readonly Node Destination;
        public int Weight;

        public Edge(Node source, Node dest, int weight=int.MaxValue)
        {
            Source      = source;
            Destination = dest;
            Weight      = weight;
        }

        public bool Equals(Edge other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Source, other.Source) && Equals(Destination, other.Destination);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Source != null ? Source.GetHashCode() : 0) * 397) ^ (Destination != null ? Destination.GetHashCode() : 0);
            }
        }
    }

    public class SparseGraph
    {
        private readonly HashSet<Node> _nodes;
        
        public SparseGraph()
        {
            _nodes = new HashSet<Node>();
        }

        public SparseGraph(IEnumerable<Edge> edges)
        {
            _nodes = new HashSet<Node>();
            foreach (Edge edge in edges)
            {
                if (!TryAdd(edge))
                    throw new InvalidDataException($"Edge could not be added to graph. {edge.Source}--{edge.Weight}-->{edge.Destination}");
            }
        }

        public bool TryAdd(Edge edge)
        {
            if (!TryAdd(edge.Source) || !TryAdd(edge.Destination)) return false;

            return edge.Source.TryAddNeighbor(edge.Destination, edge.Weight);

        }

        public bool TryAdd(Node node)
        {
            if (_nodes.TryGetValue(node, out Node graphNode))
                return node.Weight == graphNode.Weight && node.Color == graphNode.Color;
            _nodes.Add(node);
            return true;
        }

        public IDictionary<string, int> GetShortestPathTree(string source)
        {

        }
    }
}