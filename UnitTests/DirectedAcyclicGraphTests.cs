using System.Collections.Generic;
using Algorithms;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class DirectedAcyclicGraphTests
    {
        [Fact]
        public void TestCase_0()
        {
            var edges = new List<DirectedEdge<int>>();

            var graph = new DirectedGraph<int>(edges);

            Assert.True(GraphProperties<int>.IsDirectedAcyclic(graph));
        }
        [Fact]
        public void TestCase_1()
        {
            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(new GraphNode<int>(1), new GraphNode<int>(2))
            };

            var graph = new DirectedGraph<int>(edges);

            Assert.True(GraphProperties<int>.IsDirectedAcyclic(graph));
        }

        [Fact]
        public void TestCase_2()
        {
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);

            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(node1, node2),
                new DirectedEdge<int>(node2, node1)
            };

            var graph = new DirectedGraph<int>(edges);

            Assert.False(GraphProperties<int>.IsDirectedAcyclic(graph));
        }

        [Fact]
        public void TestCase_3()
        {
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var node4 = new GraphNode<int>(4);

            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(node1, node2),
                new DirectedEdge<int>(node2, node3),
                new DirectedEdge<int>(node3, node4)
            };

            var graph = new DirectedGraph<int>(edges);

            Assert.True(GraphProperties<int>.IsDirectedAcyclic(graph));
        }

        [Fact]
        public void TestCase_4()
        {
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var node4 = new GraphNode<int>(4);

            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(node1, node2),
                new DirectedEdge<int>(node2, node3),
                new DirectedEdge<int>(node3, node4),
                new DirectedEdge<int>(node4, node2)
            };

            var graph = new DirectedGraph<int>(edges);

            Assert.False(GraphProperties<int>.IsDirectedAcyclic(graph));
        }

        [Fact]
        public void TestCase_5()
        {
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            
            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(node1, node2),
                new DirectedEdge<int>(node3, node2),
                
            };

            var graph = new DirectedGraph<int>(edges);

            Assert.True(GraphProperties<int>.IsDirectedAcyclic(graph));
        }

        [Fact]
        public void TestCase_6()
        {
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(node1, node2),
                new DirectedEdge<int>(node1, node3),
                new DirectedEdge<int>(node2, node3),
            };

            var graph = new DirectedGraph<int>(edges);

            Assert.True(GraphProperties<int>.IsDirectedAcyclic(graph));
        }
    }
}