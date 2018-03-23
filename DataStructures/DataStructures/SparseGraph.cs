using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Node:IEquatable<Node>
    {
        public readonly string Label;
        public char Color;
        public int Weight;

        public Node(string label, char c = 'b', int weight = int.MaxValue)
        {
            Label = label;
            Color = c;
            Weight = weight;
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
        private HashSet<Node> _nodes;
        private HashSet<Edge> _edges;

        public SparseGraph()
        {
            _nodes = new HashSet<Node>();
            _edges = new HashSet<Edge>();
        }

        public SparseGraph(HashSet<Node> nodes, HashSet<Edge> edges)
        {
            _nodes = nodes;
            _edges = edges;
        }

        public bool TryAdd(Edge edge)
        {
            if (_edges.TryGetValue(edge, out Edge graphEdge))
                return edge.Weight == graphEdge.Weight;

            return TryAdd(edge.Source) && TryAdd(edge.Destination);
        }

        public bool TryAdd(Node node)
        {
            if (_nodes.TryGetValue(node, out Node graphNode))
                return node.Weight == graphNode.Weight && node.Color == graphNode.Color;
            _nodes.Add(node);
            return true;
        }
    }
}