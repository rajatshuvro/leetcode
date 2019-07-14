using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class DirectedGraph<T> where T:IEquatable<T>, IComparable<T>
    {
        public HashSet<GraphNode<T>> Nodes;
        public List<DirectedEdge<T>> Edges;
        public Dictionary<GraphNode<T>, HashSet<GraphNode<T>>> Neighbors;

        public int NumNodes => Nodes.Count;
        public int NumEdges => Edges.Count;

        public DirectedGraph(IEnumerable<GraphNode<T>> nodes, IEnumerable<DirectedEdge<T>> edges)
        {
            Initialize(nodes, edges);
        }

        
        public DirectedGraph(IList<DirectedEdge<T>> edges)
        {
            var nodes = new List<GraphNode<T>>();
            foreach (var edge in edges)
            {
                nodes.Add(edge.Source);
                nodes.Add(edge.Destination);
            }
            
            Initialize(nodes, edges);
        }

        private void Initialize(IEnumerable<GraphNode<T>> nodes, IEnumerable<DirectedEdge<T>> edges)
        {
            Nodes = nodes.ToHashSet();
            Edges = new List<DirectedEdge<T>>();
            Neighbors = new Dictionary<GraphNode<T>, HashSet<GraphNode<T>>>();

            foreach (var edge in edges)
            {
                Edges.Add(edge);
                edge.Source.OutDegree++;
                edge.Destination.InDegree++;

                AddNeighbor(edge.Source, edge.Destination);
            }

            Edges.Sort();
        }

        public IEnumerable<DirectedEdge<T>> GetEdges(GraphNode<T> source, GraphNode<T> destination)
        {
            var searchEdge = new DirectedEdge<T>(source, destination);
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