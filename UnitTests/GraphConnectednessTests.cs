using System.Collections.Generic;
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

            Assert.True(GraphProperties<int>.InSameConnectedComponent(graph, new List<GraphNode<int>>(){nodeList[1], nodeList[2]}));
        }

        [Fact]
        public void DirectedGraphConnectedness()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
                new GraphNode<int>(2)
            };

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[1], nodes[2], true)
            };

            var graph = new Graph<int>(nodes, edges);

            Assert.False(GraphProperties<int>.InSameConnectedComponent(graph, new List<GraphNode<int>>() { nodes[0], nodes[1], nodes[2] }));
        }

        [Fact]
        public void DirectedGraphConnectedness_1()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
                new GraphNode<int>(2)
            };

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1], true),
                new Edge<int>(nodes[1], nodes[2], true),
                new Edge<int>(nodes[2], nodes[1], true)
            };

            var graph = new Graph<int>(nodes, edges);

            Assert.True(GraphProperties<int>.InSameConnectedComponent(graph, new List<GraphNode<int>>() { nodes[0], nodes[1], nodes[2] }));
        }
    }
}