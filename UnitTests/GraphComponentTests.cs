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
            Assert.Equal(0, connectedComponents[nodes[0]]);
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
            Assert.Equal(0, connectedComponents[nodes[0]]);
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
            Assert.Equal(0, connectedComponents[nodes[0]]);
            Assert.Equal(1, connectedComponents[nodes[1]]);
            Assert.Equal(1, connectedComponents[nodes[2]]);
        }
        [Fact]
        public void Directed_graph_components_cycle()
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
                new DirectedEdge<int>(nodes[2], nodes[0])
            };

            var graph = new DirectedGraph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>();

            var connectedComponents = componentAlgorithms.KosarajuScc(graph);
            Assert.Equal(0, connectedComponents[nodes[0]]);
            Assert.Equal(0, connectedComponents[nodes[1]]);
            Assert.Equal(0, connectedComponents[nodes[2]]);
        }
        [Fact]
        public void Wikipedia_example()
        {
            var nodes = new List<GraphNode<char>>()
            {
                new GraphNode<char>('a'),
                new GraphNode<char>('b'),
                new GraphNode<char>('c'),
                new GraphNode<char>('d'),
                new GraphNode<char>('e'),
                new GraphNode<char>('f'),
                new GraphNode<char>('g'),
                new GraphNode<char>('h')
            };

            var edges = new List<DirectedEdge<char>>()
            {
                new DirectedEdge<char>(nodes[0], nodes[1]),
                new DirectedEdge<char>(nodes[1], nodes[2]),
                new DirectedEdge<char>(nodes[1], nodes[4]),
                new DirectedEdge<char>(nodes[1], nodes[5]),
                new DirectedEdge<char>(nodes[2], nodes[3]),
                new DirectedEdge<char>(nodes[2], nodes[6]),
                new DirectedEdge<char>(nodes[3], nodes[2]),
                new DirectedEdge<char>(nodes[3], nodes[7]),
                new DirectedEdge<char>(nodes[4], nodes[5]),
                new DirectedEdge<char>(nodes[4], nodes[0]),
                new DirectedEdge<char>(nodes[5], nodes[6]),
                new DirectedEdge<char>(nodes[6], nodes[5]),
                new DirectedEdge<char>(nodes[7], nodes[3]),
                new DirectedEdge<char>(nodes[7], nodes[6]),
            };

            var graph = new DirectedGraph<char>(nodes, edges);
            var componentAlgorithms = new GraphComponents<char>();

            var connectedComponents = componentAlgorithms.KosarajuScc(graph);
            Assert.Equal('a', connectedComponents[nodes[0]]);
            Assert.Equal('a', connectedComponents[nodes[1]]);
            Assert.Equal('a', connectedComponents[nodes[4]]);
            Assert.Equal('c', connectedComponents[nodes[2]]);
            Assert.Equal('c', connectedComponents[nodes[3]]);
            Assert.Equal('c', connectedComponents[nodes[7]]);
            Assert.Equal('g', connectedComponents[nodes[5]]);
            Assert.Equal('g', connectedComponents[nodes[6]]);


        }

    }
}