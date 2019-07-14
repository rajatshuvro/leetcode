using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public static class GraphProperties<T> where T : IEquatable<T>, IComparable<T>
    {
        public static bool IsDirectedAcyclic(DirectedGraph<T> directedGraph)
        {
            foreach (var node in directedGraph.Nodes)
            {
                //if a node is colored, it has been assigned to a component and checked
                if (node.Color != Color.Uncolored) continue;

                if (DfsReachesAncestor(directedGraph, node)) return false;
            }
            return true;
        }

        private static bool DfsReachesAncestor(DirectedGraph<T> directedGraph, GraphNode<T> startNode)
        {
            // if node is uncolored, color it white and visit its neighbors.
            // if node is also white, we have found a cycle
            // if node is black, it has been visited already, return
            // if all neighbors are black, we can mark the node black.

            if (startNode.Color == Color.Black ) return false;
            if (startNode.Color == Color.White) return true;

            startNode.Color = Color.White;
            if (!directedGraph.Neighbors.ContainsKey(startNode))
            {
                startNode.Color = Color.Black;
                return false;
            }

            foreach (var neighbor in directedGraph.Neighbors[startNode])
            {
                if (DfsReachesAncestor(directedGraph, neighbor)) return true;
            }

            startNode.Color = Color.Black;
            return false;
        }

        public static bool IsBipartite(DirectedGraph<T> directedGraph)
        {
            foreach (var node in directedGraph.Nodes)
            {
                //if a node is colored, it has been assigned to a component and checked
                if (node.Color != Color.Uncolored) continue;

                if (!IsComponentBipartite(directedGraph, node)) return false;
            }
            directedGraph.ClearNodeColors();
            return true;
        }

        private static bool IsComponentBipartite(DirectedGraph<T> directedGraph, GraphNode<T> startNode)
        {
            var nodeStack = new Stack<GraphNode<T>>();
            startNode.Color = Color.Black;
            nodeStack.Push(startNode);
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                foreach (var neighbor in directedGraph.Neighbors[node])
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

        public static bool InSameConnectedComponent(DirectedGraph<T> directedGraph, List<GraphNode<T>> nodeList) 
        {
            var componentAlgorithm = new GraphComponents<T>();
            var componentLabels = componentAlgorithm.KosarajuScc(directedGraph);

            var label = componentLabels[nodeList[0]];
            for (int i = 1; i < nodeList.Count; i++)
            {
                if (! label.Equals(componentLabels[nodeList[i]])) return false;
            }

            return true;
        }
        
    }
}