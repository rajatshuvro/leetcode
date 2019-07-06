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

            var edges = new List<Edge<int>>();
            var graph = new Graph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>(graph);

            var connectedComponents = componentAlgorithms.GetConnectedComponents();
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

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1])
            };
            var graph = new Graph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>(graph);

            var connectedComponents = componentAlgorithms.GetConnectedComponents();
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

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1]),
                new Edge<int>(nodes[1], nodes[2])
            };
            var graph = new Graph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>(graph);

            var connectedComponents = componentAlgorithms.GetConnectedComponents();
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

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1], true)
            };
            var graph = new Graph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>(graph);

            var connectedComponents = componentAlgorithms.GetConnectedComponents();
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

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1], true),
                new Edge<int>(nodes[0], nodes[2], true)
            };

            var graph = new Graph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>(graph);

            var connectedComponents = componentAlgorithms.GetConnectedComponents();
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

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1], true),
                new Edge<int>(nodes[1], nodes[2], true),
                new Edge<int>(nodes[2], nodes[1], true)
            };

            var graph = new Graph<int>(nodes, edges);
            var componentAlgorithms = new GraphComponents<int>(graph);

            var connectedComponents = componentAlgorithms.GetConnectedComponents();
            Assert.Equal(2, connectedComponents[nodes[0]]);
            Assert.Equal(2, connectedComponents[nodes[1]]);
            Assert.Equal(2, connectedComponents[nodes[2]]);
        }

    }
}