using System;

namespace DataStructures
{
    public class UndirectedEdge<T> : IEquatable<UndirectedEdge<T>> where T : IEquatable<T>, IComparable<T>
    {
        public readonly GraphNode<T> Source;
        public readonly GraphNode<T> Destination;
        public int Weight;
        public Color Color;

        public UndirectedEdge(GraphNode<T> source, GraphNode<T> destination, int weight = 0, Color color = Color.Uncolored)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
            Color = color;
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode() ^ Destination.GetHashCode();
        }

        public bool Equals(UndirectedEdge<T> other)
        {
            return Source.Equals(other.Source) && Destination.Equals(other.Destination)
                   || Source.Equals(other.Destination) && Destination.Equals(other.Source);
        }
    }
}