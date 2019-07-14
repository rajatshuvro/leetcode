using System;
using System.Collections.Generic;
using System.Linq;

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

        public GraphNode(T label,  int weight=0, Color color=Color.Uncolored)
        {
            Label     = label;
            Weight    = weight;
            Color     = color;
            InDegree  = 0;
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

        public int CompareTo(GraphNode<T> other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    public enum Color : byte
    {
        Uncolored,
        Colored,
        Black,
        White,
        Red,
        Green,
        Blue
    }

    public class Edge<T> : IEquatable<Edge<T>>, IComparable<Edge<T>> where T : IEquatable<T>, IComparable<T>
    {
        public readonly GraphNode<T> Source;
        public readonly GraphNode<T> Destination;
        public int Weight;
        public Color Color;
        public readonly bool IsDirected;

        public Edge(GraphNode<T> source, GraphNode<T> destination, bool isDirected=false, int weight = 0, Color color= Color.Uncolored)
        {
            Source      = source;
            Destination = destination;
            Weight      = weight;
            IsDirected  = isDirected;
            Color       = color;
        }

        public int CompareTo(Edge<T> other)
        {
            if (!Source.Label.Equals(other.Source.Label)) return Source.Label.CompareTo(other.Source.Label);
            return Destination.Label.CompareTo(other.Destination.Label);
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

    public class Graph<T> where T:IEquatable<T>, IComparable<T>
    {
        public bool IsDirected;
        public HashSet<GraphNode<T>> Nodes;
        public List<Edge<T>> Edges;
        public Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> Neighbors;

        public int NumNodes => Nodes.Count;
        public int NumEdges => Edges.Count;

        public Graph(IEnumerable<GraphNode<T>> nodes, IEnumerable<Edge<T>> edges)
        {
            Initialize(nodes, edges);
        }

        
        public Graph(IList<Edge<T>> edges)
        {
            var nodes = new List<GraphNode<T>>();
            foreach (var edge in edges)
            {
                nodes.Add(edge.Source);
                nodes.Add(edge.Destination);
            }
            
            Initialize(nodes, edges);
        }

        private void Initialize(IEnumerable<GraphNode<T>> nodes, IEnumerable<Edge<T>> edges)
        {
            Nodes = nodes.ToHashSet();
            Edges = new List<Edge<T>>();
            Neighbors = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>();

            foreach (var edge in edges)
            {
                IsDirected = edge.IsDirected;
                //if(IsDirected)
                //    Edges.Add(edge);
                //else
                //{
                //    // make sure the source is the smaller node
                //    if(edge.Source.CompareTo(edge.Destination) > 0)
                //        Edges.Add(new Edge<T>(edge.Destination, edge.Source, edge.IsDirected, edge.Weight, edge.Color));
                //    else  Edges.Add(edge);
                //}
                Edges.Add(edge);
                edge.Source.OutDegree++;
                edge.Destination.InDegree++;

                AddNeighbor(edge.Source, edge.Destination);
                if (!IsDirected) AddNeighbor(edge.Destination, edge.Source);
            }

            Edges.Sort();
        }

        public IEnumerable<Edge<T>> GetEdges(GraphNode<T> source, GraphNode<T> destination)
        {
            var searchEdge = new Edge<T>(source, destination);
            var index = Edges.BinarySearch(searchEdge);
            if (index < 0) yield break;
            //the index does not necessarily point to the first occurence of the item searched
            while (index > 0 && Edges[index - 1].Equals(searchEdge)) index--;

            while (index < Edges.Count && Edges[index].Equals(searchEdge))
            {
                yield return Edges[index];
                index++;
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
        // needed for strongly connected components algorithm
        public Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> GetInNeighbors()
        {
            var inNeighbors = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>(Nodes.Count);

            foreach (var edge in Edges)
            {
                if (inNeighbors.TryGetValue(edge.Destination, out var neighbors))
                {
                    neighbors.Add(edge.Source);
                }
                else inNeighbors[edge.Destination] = new HashSet<GraphNode<T>> { edge.Source };
            }

            return inNeighbors;
        }

        public void ClearNodeColors()
        {
            foreach (var node in Nodes)
            {
                node.Color = Color.Uncolored;
            }
        }
        public void ClearEdgeColors()
        {
            foreach (var edge in Edges)
            {
                edge.Color = Color.Uncolored;
            }
        }
        
        
    }
}