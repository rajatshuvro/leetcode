using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public static class GraphProperties<T> where T : IEquatable<T>
    {
        public static bool IsDirectedAcyclic(Graph<T> graph)
        {
            if (graph.Edges.Count > 0 && !graph.IsDirected) return false;

            foreach (var node in graph.Nodes)
            {
                //if a node is colored, it has been assigned to a component and checked
                if (node.Color != NodeColor.uncolored) continue;

                if (DfsReachesAncestor(graph, node)) return false;
            }
            return true;
        }

        private static bool DfsReachesAncestor(Graph<T> graph, GraphNode<T> startNode)
        {
            // if node is uncolored, color it white and visit its neighbors.
            // if node is also white, we have found a cycle
            // if node is black, it has been visited already, return
            // if all neighbors are black, we can mark the node black.

            if (startNode.Color == NodeColor.black ) return false;
            if (startNode.Color == NodeColor.white) return true;

            startNode.Color = NodeColor.white;
            if (!graph.Neighbors.ContainsKey(startNode))
            {
                startNode.Color = NodeColor.black;
                return false;
            }

            foreach (var neighbor in graph.Neighbors[startNode])
            {
                if (DfsReachesAncestor(graph, neighbor)) return true;
            }

            startNode.Color = NodeColor.black;
            return false;
        }

        public static bool IsBipartite(Graph<T> graph)
        {
            foreach (var node in graph.Nodes)
            {
                //if a node is colored, it has been assigned to a component and checked
                if (node.Color != NodeColor.uncolored) continue;

                if (!IsComponentBipartite(graph, node)) return false;
            }
            graph.ClearNodeColors();
            return true;
        }

        private static bool IsComponentBipartite(Graph<T> graph, GraphNode<T> startNode)
        {
            var nodeStack = new Stack<GraphNode<T>>();
            startNode.Color = NodeColor.black;
            nodeStack.Push(startNode);
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                foreach (var neighbor in graph.Neighbors[node])
                {
                    if (neighbor.Color == NodeColor.uncolored)
                    {
                        neighbor.Color = node.Color == NodeColor.black ? NodeColor.white : NodeColor.black;
                        nodeStack.Push(neighbor);
                        continue;
                    }
                    if (neighbor.Color == node.Color) return false;

                }
            }

            return true;
        }
    }
}