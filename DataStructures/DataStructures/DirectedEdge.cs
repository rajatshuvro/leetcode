using System;

namespace DataStructures
{
    public class DirectedEdge<T> : IComparable<DirectedEdge<T>> where T : IEquatable<T>, IComparable<T>
    {
        public readonly GraphNode<T> Source;
        public readonly GraphNode<T> Destination;
        public int Weight;
        public Color Color;

        public DirectedEdge(GraphNode<T> source, GraphNode<T> destination, int weight = 0, Color color = Color.Uncolored)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
            Color = color;
        }

        public int CompareTo(DirectedEdge<T> other)
        {
            if (!Source.Label.Equals(other.Source.Label)) return Source.Label.CompareTo(other.Source.Label);
            return Destination.Label.CompareTo(other.Destination.Label);
        }

    }
}