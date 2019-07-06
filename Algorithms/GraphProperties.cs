using System;
using System.Collections.Generic;
using System.Linq;
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
                if (node.Color != Color.Uncolored) continue;

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

            if (startNode.Color == Color.Black ) return false;
            if (startNode.Color == Color.White) return true;

            startNode.Color = Color.White;
            if (!graph.Neighbors.ContainsKey(startNode))
            {
                startNode.Color = Color.Black;
                return false;
            }

            foreach (var neighbor in graph.Neighbors[startNode])
            {
                if (DfsReachesAncestor(graph, neighbor)) return true;
            }

            startNode.Color = Color.Black;
            return false;
        }

        public static bool IsBipartite(Graph<T> graph)
        {
            foreach (var node in graph.Nodes)
            {
                //if a node is colored, it has been assigned to a component and checked
                if (node.Color != Color.Uncolored) continue;

                if (!IsComponentBipartite(graph, node)) return false;
            }
            graph.ClearNodeColors();
            return true;
        }

        private static bool IsComponentBipartite(Graph<T> graph, GraphNode<T> startNode)
        {
            var nodeStack = new Stack<GraphNode<T>>();
            startNode.Color = Color.Black;
            nodeStack.Push(startNode);
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                foreach (var neighbor in graph.Neighbors[node])
                {
                    if (neighbor.Color == Color.Uncolored)
                    {
                        neighbor.Color = node.Color == Color.Black ? Color.White : Color.Black;
                        nodeStack.Push(neighbor);
                        continue;
                    }
                    if (neighbor.Color == node.Color) return false;

                }
            }

            return true;
        }

        public static bool AreNodesStronglyConnected(Graph<T> graph, List<GraphNode<T>> nodeList) 
        {
            throw new NotImplementedException();
        }

        public static bool AreNodesConnected(Graph<T> graph, List<GraphNode<T>> nodeList)
        {
            graph.ClearNodeColors();
            // starting form an arbitrary node in nodeList, we should be able to color all nodes 
            // by following the neighbors
            var startNode = nodeList[0];
            startNode.Color = Color.Colored;

            var stack = new Stack<GraphNode<T>>();
            stack.Push(startNode);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                foreach (var neighbor in graph.Neighbors[node])
                {
                    if(neighbor.Color == Color.Colored) continue;
                    neighbor.Color = Color.Colored;
                    stack.Push(neighbor);
                }
            }
            
            return nodeList.TrueForAll(x=>x.Color==Color.Colored);
        }
    }
}