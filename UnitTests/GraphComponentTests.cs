using System.Collections.Generic;
using Algorithms;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class GraphComponentTests
    {
        [Fact]
        public void NoEdge_undirected_graph_components()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
                new GraphNode<int>(2)
            };

            var edges = new List<UndirectedEdge<int>>();
            var graph = new UndirectedGraph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>();

            var connectedComponents = componentAlgorithms.DfsConnectedComponents(graph);
            Assert.Equal(0, connectedComponents[nodes[0]]);
            Assert.Equal(1, connectedComponents[nodes[1]]);
            Assert.Equal(2, connectedComponents[nodes[2]]);
        }

        [Fact]
        public void Undirected_graph_components_1()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
                new GraphNode<int>(2)
            };

            var edges = new List<UndirectedEdge<int>>()
            {
                new UndirectedEdge<int>(nodes[0], nodes[1])
            };
            var graph = new UndirectedGraph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>();

            var connectedComponents = componentAlgorithms.DfsConnectedComponents(graph);
            Assert.Equal(0, connectedComponents[nodes[0]]);
            Assert.Equal(0, connectedComponents[nodes[1]]);
            Assert.Equal(2, connectedComponents[nodes[2]]);
        }

        [Fact]
        public void Undirected_graph_components_2()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
                new GraphNode<int>(2)
            };

            var edges = new List<UndirectedEdge<int>>()
            {
                new UndirectedEdge<int>(nodes[0], nodes[1]),
                new UndirectedEdge<int>(nodes[1], nodes[2])
            };
            var graph = new UndirectedGraph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>();

            var connectedComponents = componentAlgorithms.DfsConnectedComponents(graph);
            Assert.Equal(0, connectedComponents[nodes[0]]);
            Assert.Equal(0, connectedComponents[nodes[1]]);
            Assert.Equal(0, connectedComponents[nodes[2]]);
        }

        [Fact]
        public void Directed_graph_components_1()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
                new GraphNode<int>(2)
            };

            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(nodes[0], nodes[1])
            };
            var graph = new DirectedGraph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>();

            var connectedComponents = componentAlgorithms.KosarajuScc(graph);
            Assert.Equal(1, connectedComponents[nodes[0]]);
            Assert.Equal(1, connectedComponents[nodes[1]]);
            Assert.Equal(2, connectedComponents[nodes[2]]);
        }
        [Fact]
        public void Directed_graph_components_2()
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
                new DirectedEdge<int>(nodes[0], nodes[2])
            };

            var graph = new DirectedGraph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>();

            var connectedComponents = componentAlgorithms.KosarajuScc(graph);
            Assert.Equal(2, connectedComponents[nodes[0]]);
            Assert.Equal(1, connectedComponents[nodes[1]]);
            Assert.Equal(2, connectedComponents[nodes[2]]);
        }
        [Fact]
        public void Directed_graph_components_3()
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
            var componentAlgorithms = new GraphComponents<int>();

            var connectedComponents = componentAlgorithms.KosarajuScc(graph);
            Assert.Equal(2, connectedComponents[nodes[0]]);
            Assert.Equal(2, connectedComponents[nodes[1]]);
            Assert.Equal(2, connectedComponents[nodes[2]]);
        }

    }
}