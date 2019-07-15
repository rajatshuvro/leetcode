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
    }
}