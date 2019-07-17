using System.Collections.Generic;
using Algorithms;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class DijkstraTests
    {
        private static UndirectedGraph<int> GetGraph()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(1), new GraphNode<int>(2),
                new GraphNode<int>(3), new GraphNode<int>(4),
                new GraphNode<int>(5), new GraphNode<int>(6),
            };
            var edges = new List<UndirectedEdge<int>>()
            {
                new UndirectedEdge<int>(nodes[0], nodes[1],  7),
                new UndirectedEdge<int>(nodes[0], nodes[2],  9),
                new UndirectedEdge<int>(nodes[0], nodes[5], 14),
                new UndirectedEdge<int>(nodes[1], nodes[2], 10),
                new UndirectedEdge<int>(nodes[1], nodes[3], 15),
                new UndirectedEdge<int>(nodes[2], nodes[3], 11),
                new UndirectedEdge<int>(nodes[2], nodes[5], 2),
                new UndirectedEdge<int>(nodes[3], nodes[4], 6),
                new UndirectedEdge<int>(nodes[4], nodes[5], 9)
            };

            var graph = new UndirectedGraph<int>(nodes, edges);
            return graph;
        }

        [Fact]
        public void GetShortestDistances()
        {
            var graph = GetGraph();

            var distances = Dijkstras<int>.GetShortestDistancesFrom(graph, 1);

            Assert.Equal(0, distances[1]);
            Assert.Equal(7, distances[2]);
            Assert.Equal(9, distances[3]);
            Assert.Equal(20, distances[4]);
            Assert.Equal(20, distances[5]);
            Assert.Equal(11, distances[6]);
        }

        [Fact]
        public void GetShortestPath()
        {
            var graph = GetGraph();
            var shortestPath = Dijkstras<int>.GetShortestPath(graph, 1, 6);

            Assert.Equal(new[] { 1, 3, 6 }, shortestPath);
        }

        private DirectedGraph<int> GetDirectedGraph()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1), new GraphNode<int>(2),
                new GraphNode<int>(3), new GraphNode<int>(4),
                new GraphNode<int>(5)
            };
            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(nodes[0], nodes[1],  7),
                new DirectedEdge<int>(nodes[0], nodes[2],  9),
                new DirectedEdge<int>(nodes[0], nodes[5], 14),
                new DirectedEdge<int>(nodes[1], nodes[2], 10),
                new DirectedEdge<int>(nodes[1], nodes[3], 15),
                new DirectedEdge<int>(nodes[2], nodes[3], 11),
                new DirectedEdge<int>(nodes[2], nodes[5], 2),
                new DirectedEdge<int>(nodes[3], nodes[4], 6),
                new DirectedEdge<int>(nodes[4], nodes[5], 9)
            };

            var graph = new DirectedGraph<int>(nodes, edges);
            return graph;
        }

        [Fact]
        public void GetShortestDirectedDistances()
        {
            var graph = GetDirectedGraph();

            var distances = Dijkstras<int>.GetShortestDistancesFrom(graph, 0);

            Assert.Equal(0, distances[0]);
            Assert.Equal(7, distances[1]);
            Assert.Equal(9, distances[2]);
            Assert.Equal(20, distances[3]);
            Assert.Equal(26, distances[4]);
            Assert.Equal(11, distances[5]);
        }

    }
}