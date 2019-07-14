using System.Collections.Generic;
using Algorithms;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class EularianPathTests
    {
        [Fact]
        public void Directed_single_edge()
        {
            var nodes = new List<GraphNode<int>>()
            {
                new GraphNode<int>(0),
                new GraphNode<int>(1),
            };

            var edges = new List<DirectedEdge<int>>()
            {
                new DirectedEdge<int>(nodes[0], nodes[1]),
            };

            var graph = new DirectedGraph<int>(nodes, edges);
            var eular = new EularianPath<int>(graph);

            Assert.Equal(new[] { 0, 1 }, eular.GetEularianPath(0));
        }

        [Fact]
        public void Directed_circuit()
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
            var eular = new EularianPath<int>(graph);

            Assert.Equal(new[]{0,1,2, 0}, eular.GetEularianPath(0));
        }
    }
}