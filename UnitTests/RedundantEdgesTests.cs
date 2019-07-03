using Problems;
using Xunit;

namespace UnitTests
{
    public class RedundantEdgesTests
    {
        [Fact]
        public void Test_one()
        {
            var edges = new[,] {{1, 2}, {1, 3}, {2, 3}};
            var expected = new[] {2, 3};

            Assert.Equal(expected, RedundentEdges.FindRedundantConnection(edges));
        }

        [Fact]
        public void Test_two()
        {
            var edges = new[,] { { 1, 2 }, { 2, 3 }, { 3, 4 }, { 1, 4 }, { 1, 5 } };
            var expected = new[] {1, 4};

            Assert.Equal(expected, RedundentEdges.FindRedundantConnection(edges));
        }
        [Fact]
        public void Test_three()
        {
            var edges = new[,] { { 3, 4 }, { 1, 2 }, { 2, 4 }, { 3, 5 }, { 2, 5 } };
            var expected = new[] { 2, 5 };

            Assert.Equal(expected, RedundentEdges.FindRedundantConnection(edges));
        }
    }
}