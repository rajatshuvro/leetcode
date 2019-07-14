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
            
            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(nodeList[1], nodeList[2])
            };

            var graph = new DirectedGraph<int>(nodeList, edges);

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

            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(nodes[1], nodes[2])
            };

            var graph = new DirectedGraph<int>(nodes, edges);

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

            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(nodes[0], nodes[1]),
                new DirectedEdge<int>(nodes[1], nodes[2]),
                new DirectedEdge<int>(nodes[2], nodes[1])
            };

            var graph = new DirectedGraph<int>(nodes, edges);

            Assert.True(GraphProperties<int>.InSameConnectedComponent(graph, new List<GraphNode<int>>() { nodes[0], nodes[1], nodes[2] }));
        }
    }
}