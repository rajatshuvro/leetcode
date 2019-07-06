using System.Collections.Generic;
using System.Linq;
using Algorithms;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class GraphConnectednessTests
    {
        [Fact]
        public void UndirectedGraphConnectedness()
        {
            var nodeList = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
                new GraphNode<int>(2)
            };
            
            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodeList[1], nodeList[2])
            };

            var graph = new Graph<int>(nodeList, edges);

            Assert.True(GraphProperties<int>.AreNodesConnected(graph, new List<GraphNode<int>>(){nodeList[1], nodeList[2]}));
        }
    }
}