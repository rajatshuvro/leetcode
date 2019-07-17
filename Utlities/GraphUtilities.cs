using System;
using System.Collections.Generic;
using DataStructures;

namespace Utilities
{
    public static class GraphUtilities
    {
        public static DirectedGraph<int> GetDiGraphFromAdjacencyMatrix(int[][] adjacencyList)
        {
            var nodes = new List<GraphNode<int>>();
            for (var i = 0; i < adjacencyList.GetLength(0); i++)
            {
                nodes.Add(new GraphNode<int>(i));
            }

            var edges = new List<DirectedEdge<int>>();
            for (int i = 0; i < adjacencyList.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyList[i].Length; j++)
                {
                    var source = nodes[i];
                    var destination = nodes[adjacencyList[i][j]];
                    edges.Add(new DirectedEdge<int>(source, destination));
                }
            }
            return new DirectedGraph<int>(nodes, edges);
        }

        public static UndirectedGraph<int> GetUnDiGraphFromAdjacencyMatrix(int[][] adjacencyList)
        {
            var nodes = new List<GraphNode<int>>();
            for (var i = 0; i < adjacencyList.GetLength(0); i++)
            {
                nodes.Add(new GraphNode<int>(i));
            }

            var edges = new List<UndirectedEdge<int>>();
            for (int i = 0; i < adjacencyList.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyList[i].Length; j++)
                {
                    var source = nodes[i];
                    var destination = nodes[adjacencyList[i][j]];
                    edges.Add(new UndirectedEdge<int>(source, destination));
                }
            }
            return new UndirectedGraph<int>(nodes, edges);
        }

        public static DirectedGraph<int> GetDiGraphFromWeightedEdges(int[][] edges, int nodeCount)
        {
            var nodes = new List<GraphNode<int>>();
            for (var i = 0; i < nodeCount; i++)
            {
                nodes.Add(new GraphNode<int>(i));
            }

            var directedEdges = new List<DirectedEdge<int>>();
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                var source = nodes[edges[i][0]-1];
                var destination = nodes[edges[i][1]-1];
                var weight = edges[i][2];
                directedEdges.Add(new DirectedEdge<int>(source, destination, weight));
            }
            return new DirectedGraph<int>(nodes, directedEdges);
        }
    }
}