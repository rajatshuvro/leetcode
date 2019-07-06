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

            Assert.Equal(new[]{0,1,2}, componentAlgorithms.GetConnectedComponents());
        }
    }
}