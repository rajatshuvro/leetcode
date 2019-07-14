using System.Collections.Generic;
using Algorithms;
using DataStructures;

namespace Problems
{
    public class FindEventualSafeStates
    {
        //https://leetcode.com/problems/find-eventual-safe-states/
        /*
         In a directed graph, we start at some node and every turn, walk along a directed edge of the graph.  If we reach a node that is terminal (that is, it has no outgoing directed edges), we stop.

Now, say our starting node is eventually safe if and only if we must eventually walk to a terminal node.  More specifically, there exists a natural number K so that for any choice of where to walk, we must have stopped at a terminal node in less than K steps.

Which nodes are eventually safe?  Return them as an array in sorted order.

The directed graph has N nodes with labels 0, 1, ..., N-1, where N is the length of graph.  The graph is given in the following form: graph[i] is a list of labels j such that (i, j) is a directed edge of the graph.
         */

        public IList<int> EventualSafeNodes(int[][] adjacencyMatrix)
        {
            // all nodes in a strongly connected component is unsafe
            // because they can get in a loop
            var nodes = new HashSet<GraphNode<int>>();
            for(var i =0; i < adjacencyMatrix.GetLength(0); i++)
            {
                nodes.Add(new GraphNode<int>(i));
            }

            var edges = new List<DirectedEdge<int>>();
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix[i].Length; j++)
                {
                    var node_i = new GraphNode<int>(i);
                    node_i = nodes.TryGetValue(node_i, out var node) ? node : node_i;
                    nodes.Add(node_i);

                    var node_j = new GraphNode<int>(adjacencyMatrix[i][j]);
                    node_j = nodes.TryGetValue(node_j, out node) ? node : node_j;
                    nodes.Add(node_j);

                    edges.Add(new DirectedEdge<int>(node_i, node_j));
                }
            }
            var graph = new DirectedGraph<int>(nodes, edges);
            var components = new GraphComponents<int>();
            var scc = components.GetStronglyConnectedComponents(graph);

            var safeList = new List<int>();
            foreach (var component in scc)
            {
                if(component.Count == 1) safeList.Add(component[0]);
            }
            safeList.Sort();
            return safeList;
        }
    }
}