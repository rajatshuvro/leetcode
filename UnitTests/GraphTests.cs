using System.Collections.Generic;
using Algorithms;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class GraphTests
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
        public void GraphCreation()
        {
            var graph = GetGraph();

            Assert.Equal(6,graph.NumNodes);
            Assert.Equal(9, graph.NumEdges);
        }

        
    }
}
