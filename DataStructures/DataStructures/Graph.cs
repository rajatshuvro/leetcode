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
            Source      = source;
            Destination = destination;
            Weight      = weight;
            IsDirected  = isDirected;
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

        public Graph(IEnumerable<Edge<T>> edges)
        {
            Edges     = new HashSet<Edge<T>>();
            Nodes     = new HashSet<GraphNode<T>>();
            Neighbors = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>();

            foreach (var edge in edges)
            {
                IsDirected = edge.IsDirected;
                Nodes.Add(edge.Source);
                Nodes.Add(edge.Destination);
                Edges.Add(edge);

                AddNeighbor(edge.Source, edge.Destination);

                if (! IsDirected) AddNeighbor(edge.Destination, edge.Source);
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
        
    }
}