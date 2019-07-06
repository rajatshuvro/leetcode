using System;
using System.Collections.Generic;
using DataStructures;

namespace Algorithms
{
    public class EulerPath<T> where T:IEquatable<T>
    {
        public static bool IsEulerian(Graph<T> graph)
        {
            return !graph.IsDirected ? IsUndirectedGraphEulerian(graph) : IsDirectedGraphEulerian(graph);
        }

        private static bool IsDirectedGraphEulerian(Graph<T> graph)
        {
            var sourceNodeCount = 0;
            var sinkNodeCount = 0;
            var nodeList = new List<GraphNode<T>>();

            foreach (var node in graph.Nodes)
            {
                if (node.InDegree ==0 && node.OutDegree ==0) continue;
                nodeList.Add(node);
                if (node.InDegree == node.OutDegree) continue;
                if (node.InDegree - node.OutDegree == 1 ) sinkNodeCount++;
                if (node.OutDegree - node.InDegree == 1 ) sourceNodeCount++;
            }
            //all nodes with degree>0 have to be in the same component
            return sinkNodeCount == 1 && sourceNodeCount == 1 && GraphProperties<T>.AreNodesStronglyConnected(graph, nodeList);
        }

        private static bool IsUndirectedGraphEulerian(Graph<T> graph)
        {
            var oddDegreeNodeCount = 0;
            var nodeList = new List<GraphNode<T>>();
            foreach (var node in graph.Nodes)
            {
                if(node.Degree==0) continue;
                nodeList.Add(node);
                if (node.Degree % 2 != 0) oddDegreeNodeCount++;
            }

            if (!GraphProperties<T>.AreNodesConnected(graph, nodeList)) return false;

            return oddDegreeNodeCount == 2 || oddDegreeNodeCount == 0;
        }
    }
}