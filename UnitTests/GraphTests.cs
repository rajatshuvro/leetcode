using System;
using System.Collections.Generic;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class GraphTests
    {
        private static Graph<int> GetGraph()
        {
            var edges = new List<Edge<int>>()
            {
                new Edge<int>(new Node<int>(1), new Node<int>(2),false,  7),
                new Edge<int>(new Node<int>(1), new Node<int>(3),false,  9),
                new Edge<int>(new Node<int>(1), new Node<int>(6), false, 14),
                new Edge<int>(new Node<int>(2), new Node<int>(3), false, 10),
                new Edge<int>(new Node<int>(2), new Node<int>(4), false, 15),
                new Edge<int>(new Node<int>(3), new Node<int>(4), false, 11),
                new Edge<int>(new Node<int>(3), new Node<int>(6), false, 2),
                new Edge<int>(new Node<int>(4), new Node<int>(5), false, 6),
                new Edge<int>(new Node<int>(5), new Node<int>(6), false, 9)
            };

            var graph = new Graph<int>(false, edges);
            return graph;
        }

        [Fact]
        public void GraphCreation()
        {
            var graph = GetGraph();

            Assert.Equal(6,graph.NumNodes);
            Assert.Equal(9, graph.NumEdges);
        }

        [Fact]
        public void GetShortestDistances()
        {
            var graph = GetGraph();

            var distances = graph.GetShortestDistancesFrom(1);

            Assert.Equal(0, distances[1]);
            Assert.Equal(7, distances[2]);
            Assert.Equal(9, distances[3]);
            Assert.Equal(20, distances[4]);
            Assert.Equal(20, distances[5]);
            Assert.Equal(11, distances[6]);
        }
    }
}
