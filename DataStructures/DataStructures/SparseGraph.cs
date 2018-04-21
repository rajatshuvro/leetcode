using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructures
{
    public class Node : IEquatable<Node>, IComparable<Node>
    {
        public readonly string Label;
        public char Color;
        public int Weight;
        public readonly HashSet<Edge> OutEdges;

        public Node(string label, char c = 'b', int weight = int.MaxValue)
        {
            Label     = label;
            Color     = c;
            Weight    = weight;
            OutEdges  = new HashSet<Edge>();
        }

        public bool TryAddOutEdge(Edge edge)
        {
            if (OutEdges.TryGetValue(edge, out var oldEdge))
                return edge.Weight == oldEdge.Weight;

            OutEdges.Add(edge);
            return true;
        }

        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Label, other.Label);
        }

        public int CompareTo(Node other)
        {
            return Weight.CompareTo(other.Weight);
        }

        public override int GetHashCode()
        {
            return (Label != null ? Label.GetHashCode() : 0);
        }

        public Edge GetEdgeTo(Node dest)
        {
            return OutEdges.TryGetValue(new Edge(this, dest), out Edge edge) ? edge : null;
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

            return edge.Source.TryAddOutEdge(edge);

        }

        public bool TryAdd(Node node)
        {
            if (_nodes.TryGetValue(node, out Node graphNode))
                return node.Weight == graphNode.Weight && node.Color == graphNode.Color;
            _nodes.Add(node);
            return true;
        }

        private Node GetNode(string label)
        {
            return _nodes.TryGetValue(new Node(label), out Node node) ? node : null;
        }

        private Edge GetEdge(string source, string dest)
        {
            Node sourceNode = GetNode(source);
            Node destNode = GetNode(dest);

            return sourceNode.GetEdgeTo(destNode);
        }

        public IDictionary<string, int> GetShortestPathTree(string source)
        {
            Node srcNode = GetNode(source);
            if (srcNode == null) return null;

            srcNode.Weight = 0;
            var nodeHeap= new MinHeap<Node>();

            nodeHeap.Add(srcNode);

            while (nodeHeap.Count != 0)
            {
                Node node = nodeHeap.GetMin();
                foreach (Edge outEdge in node.OutEdges)
                {
                    if (outEdge.Destination.Weight <= node.Weight + outEdge.Weight) continue;

                    outEdge.Destination.Weight = node.Weight + outEdge.Weight;
                    if (!nodeHeap.Contains(outEdge.Destination))
                        nodeHeap.Add(outEdge.Destination);
                }
                
            }

            var distances= new Dictionary<string, int>();
            foreach (Node node in _nodes)
            {
                distances[node.Label] = node.Weight;
            }

            return distances;
        }
    }
}