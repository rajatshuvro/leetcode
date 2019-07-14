using System.Collections.Generic;
using System.Linq;
using Algorithms;
using DataStructures;

namespace Problems
{
    public class BipartiteChecker
    {
        //https://leetcode.com/problems/is-graph-bipartite/
        /*
         * Given an undirected graph, return true if and only if it is bipartite.

        Recall that a graph is bipartite if we can split it's set of nodes into two independent subsets A and B such that every edge in the graph has one node in A and another node in B.

        The graph is given in the following form: graph[i] is a list of indexes j for which the edge between nodes i and j exists.  Each node is an integer between 0 and graph.length - 1.  There are no self edges or parallel edges: graph[i] does not contain i, and it doesn't contain any element twice.
         */

        public bool IsBipartite(int[][] adjacencyMatrix)
        {
            var edges = new HashSet<Edge<int>>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix[i].Length; j++)
                {
                    edges.Add(new Edge<int>(new GraphNode<int>(i), new GraphNode<int>(adjacencyMatrix[i][j])));
                }
            }
            var graph = new Graph<int>(edges.ToList());

            return GraphProperties<int>.IsBipartite(graph);
            

        }

        
    }
}