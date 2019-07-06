﻿using System.Collections.Generic;
using Algorithms;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class TopologicalOrderingTests
    {
        [Fact]
        public void OneEdgeTest()
        {
            var edges = new List<Edge<int>>()
            {
                new Edge<int>(new GraphNode<int>(1), new GraphNode<int>(2), true)
            };

            var graph = new Graph<int>(edges);
            var topOrder = new TopologicalOrdering<int>(graph);

            Assert.Equal(new []{2,1}, topOrder.GetTopologicalOrdering());
        }

        [Fact]
        public void NoOrderTest()
        {
            var node0 = new GraphNode<int>(0);
            var node1 = new GraphNode<int>(1);
            
            var edges = new List<Edge<int>>()
            {
                new Edge<int>(node1, node0, true),
                new Edge<int>(node0, node1, true),
            };

            var graph = new Graph<int>(edges);
            var topOrder = new TopologicalOrdering<int>(graph);

            Assert.Equal(new int[] { }, topOrder.GetTopologicalOrdering());
        }

        [Fact]
        public void FourEdgeTest()
        {
            var node0 = new GraphNode<int>(0);
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(node1, node0, true),
                new Edge<int>(node2, node0, true),
                new Edge<int>(node3, node1, true),
                new Edge<int>(node3, node2, true),
            };

            var graph = new Graph<int>(edges);
            var topOrder = new TopologicalOrdering<int>(graph);

            Assert.Equal(new[] { 0,1,2,3 }, topOrder.GetTopologicalOrdering());
        }
    }
}