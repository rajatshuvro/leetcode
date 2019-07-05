using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public static class GraphComponents<T> where T : IEquatable<T>
    {
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