using Xunit;

namespace UnitTests
{
    public class BipartiteTests
    {
        [Fact]
        public void Bipartite_true()
        {
            var bg = new BipartiteGraph.BipartiteGraph();

            var result = bg.IsBipartite(new int[][]
            {
                new []{1, 3}, new[] { 0, 2}, new []{1, 3}, new []{0, 2}
            });

            Assert.True(result);
        }

        [Fact]
        public void Bipartite_false()
        {
            var bg = new BipartiteGraph.BipartiteGraph();

            var result = bg.IsBipartite(new int[][]
            {
                new []{1,2, 3}, new[] { 0, 2}, new []{0, 1, 3}, new []{0, 2}
            });

            Assert.False(result);
        }
    }
}