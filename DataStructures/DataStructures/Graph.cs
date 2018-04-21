using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Node<T> : IEquatable<Node<T>> where T : IEquatable<T>
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
    }

    public class Edge<T> : IEquatable<Edge<T>> where T : IEquatable<T>
    {
        public readonly Node<T> Source;
        public readonly Node<T> Destination;
        public int Weight;

        public Edge(Node<T> source, Node<T> destination, int weight = 0)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public bool Equals(Edge<T> other)
        {
            return Source.Equals(other.Source) && Destination.Equals(other.Destination);
        }
    }

    public class Graph<T> where T:IEquatable<T>
    {
        public readonly bool IsDirected;
        private Dictionary<Node<T>, List<Edge<T>>> _neighbors;

        public Graph(bool isDirected, IEnumerable<Edge<T>> edges)
        {
            IsDirected = isDirected;

        }

    }
}