using System;

namespace DataStructures
{
    public class GraphNode<T> : IEquatable<GraphNode<T>>, IComparable<GraphNode<T>> where T : IEquatable<T>
    {
        public readonly T Label;
        public int Weight;
        public Color Color;
        public int InDegree;
        public int OutDegree;
        public int Degree => InDegree + OutDegree;

        public GraphNode(T label, int weight = 0, Color color = Color.Uncolored)
        {
            Label = label;
            Weight = weight;
            Color = color;
            InDegree = 0;
            OutDegree = 0;
        }

        public bool Equals(GraphNode<T> other)
        {
            return Label.Equals(other.Label);
        }

        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }
        // in dijkstra's algorithms nodes need to be compared by weight
        public int CompareTo(GraphNode<T> other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

}