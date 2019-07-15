using System;
using System.Collections.Generic;
using Algorithms;
using DataStructures;
using Utilities;

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
        private DirectedGraph<int> _graph;
        public IList<int> EventualSafeNodes(int[][] adjacencyMatrix)
        {
            // all nodes in a strongly connected component is unsafe
            // because they can get in a loop
            _graph = GraphUtilities.GetDiGraphFromAdjacencyMatrix(adjacencyMatrix);
            // for each node, we try to see if it can reach a cycle
            // a cycle is reached when during a DFS, a back edge is discovered
            foreach (var node in _graph.Nodes)
            {
                if (node.Color == Color.Uncolored)
                {
                    UncolorWhiteNodes();
                    Visit(node);
                }
            }
            var safeList = new List<int>();
            foreach (var node in _graph.Nodes)
            {
                if(node.Color != Color.Black) safeList.Add(node.Label);
            }
            safeList.Sort();
            return safeList;
        }

        private void UncolorWhiteNodes()
        {
            foreach (var node in _graph.Nodes)
            {
                if (node.Color == Color.White) node.Color = Color.Uncolored;
            }
        }

        private void Visit(GraphNode<int> node)
        {
            if (node.Color == Color.Black) return;
            if (node.Color == Color.White)
            {
                // back edge found
                node.Color = Color.Black;
                return;
            }
            if (node.Color == Color.Uncolored) node.Color = Color.White;

            if (!_graph.Neighbors.ContainsKey(node))
            {
                // no out going edges , so certainly safe
                node.Color = Color.Green;
                return;
            }
            foreach (var neighbor in _graph.Neighbors[node])
            {
                Visit(neighbor);
                if (neighbor.Color == Color.Black) node.Color = Color.Black;
            }

            if (node.Color != Color.Black) node.Color = Color.Green;// this node is in the clear.
        }
    }
}