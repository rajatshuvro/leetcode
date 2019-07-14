using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class UndirectedGraph<T> where T : IEquatable<T>, IComparable<T>
    {
        public readonly HashSet<GraphNode<T>> Nodes;
        public readonly HashSet<UndirectedEdge<T>> Edges;
        public readonly Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> Neighbors;

        public int NumNodes => Nodes.Count;
        public int NumEdges => Edges.Count;

        public UndirectedGraph(IEnumerable<GraphNode<T>> nodes, IEnumerable<UndirectedEdge<T>> edges)
        {
            Nodes = nodes.ToHashSet();
            Edges = new HashSet<UndirectedEdge<T>>();
            Neighbors = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>(Nodes.Count);

            foreach (var edge in edges)
            {
                Edges.Add(edge);
                edge.Source.OutDegree++;
                edge.Destination.InDegree++;

                AddNeighbor(edge.Source, edge.Destination);
                AddNeighbor(edge.Destination, edge.Source);
            }

        }

        private void AddNeighbor(GraphNode<T> source, GraphNode<T> destination)
        {
            if (Neighbors.TryGetValue(source, out var neighbors))
            {
                neighbors.Add(destination);
            }
            else Neighbors[source] = new HashSet<GraphNode<T>> { destination };

        }

        public UndirectedEdge<T> GetEdge(GraphNode<T> source, GraphNode<T> destination)
        {
            return Edges.TryGetValue(new UndirectedEdge<T>(source, destination), out var edge) ? edge : null;
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