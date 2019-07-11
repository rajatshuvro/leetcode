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

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1], true),
            };

            var graph = new Graph<int>(nodes, edges);
            var eular = new EularianPath<int>(graph);

            Assert.Equal(new[] { 0, 1 }, eular.GetEularianPath());
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

            var edges = new List<Edge<int>>()
            {
                new Edge<int>(nodes[0], nodes[1], true),
                new Edge<int>(nodes[1], nodes[2], true),
                new Edge<int>(nodes[2], nodes[0], true)
            };

            var graph = new Graph<int>(nodes, edges);
            var eular = new EularianPath<int>(graph);

            Assert.Equal(new[]{0,1,2, 0}, eular.GetEularianPath());
        }
    }
}