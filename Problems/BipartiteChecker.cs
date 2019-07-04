﻿using System.Collections.Generic;

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

        public bool IsBipartite(int[][] graph)
        {
            //trying to bi-color the graph
            var nodeColors = new Dictionary<int, char>();
            var minUncoloredNode = 0;
            while (nodeColors.Count < graph.GetLength(0))
            {
                while (minUncoloredNode < graph.GetLength(0) && nodeColors.ContainsKey(minUncoloredNode))
                    minUncoloredNode++;//get to the next graph component

                if (!IsComponentBipartite(graph, minUncoloredNode, nodeColors)) return false;
            }

            return true;

        }

        private bool IsComponentBipartite(int[][] graph, int startNode, Dictionary<int, char> nodeColors)
        {
            nodeColors[startNode] = 'w';
            var stack = new Stack<int>();

            stack.Push(startNode);
            while(stack.Count > 0)
            {
                var i = stack.Pop();
                for (var j = 0; j < graph[i].Length; j++)
                {
                    var v = graph[i][j];
                    
                    if (nodeColors.TryGetValue(v, out var color))
                    {
                        if (color == nodeColors[i]) return false;
                    }
                    else
                    {
                        stack.Push(v);
                        nodeColors[v] = nodeColors[i] == 'b' ? 'w' : 'b';
                    }
                }

            }

            return true;
        }
    }
}