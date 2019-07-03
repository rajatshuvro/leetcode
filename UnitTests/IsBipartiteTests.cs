using Problems;
using Xunit;

namespace UnitTests
{
    public class IsBipartiteTests
    {
        [Fact]
        public void SingleEdgeGraph()
        {
            var graph = new int[2][];
            graph[0] = new[] {1};
            graph[1] = new[] {0};
            var checker = new BipartiteChecker();

            Assert.True(checker.IsBipartite(graph));
        }

        [Fact]
        public void ThreeNodeBipartite()
        {
            var graph = new int[3][];
            graph[0] = new[] { 1 };
            graph[1] = new[] { 0 , 2 };
            graph[2] = new[] {1};
            var checker = new BipartiteChecker();

            Assert.True(checker.IsBipartite(graph));
        }

        [Fact]
        public void ThreeNodeNotBipartite()
        {
            var graph = new int[3][];
            graph[0] = new[] { 1 ,2 };
            graph[1] = new[] { 0, 2 };
            graph[2] = new[] { 0, 1 };
            var checker = new BipartiteChecker();

            Assert.False(checker.IsBipartite(graph));
        }

        [Fact]
        public void TestCase_1()
        {
            var graph = new int[4][];
            graph[0] = new[] { 1, 3 };
            graph[1] = new[] { 0, 2 };
            graph[2] = new[] { 3, 1 };
            graph[3] = new[] { 0, 2 };

            var checker = new BipartiteChecker();

            Assert.True(checker.IsBipartite(graph));
        }
        [Fact]
        public void TestCase_2()
        {
            var graph = new int[4][];
            graph[0] = new[] { 1,2, 3 };
            graph[1] = new[] { 0, 2 };
            graph[2] = new[] { 3, 1,0 };
            graph[3] = new[] { 0, 2 };

            var checker = new BipartiteChecker();

            Assert.False(checker.IsBipartite(graph));
        }
        [Fact]
        public void TestCase_3()
        {
            var graph = new int[4][];
            graph[0] = new[] { 1};
            graph[1] = new[] { 0, 3 };
            graph[2] = new[] { 3 };
            graph[3] = new[] { 1, 2 };

            var checker = new BipartiteChecker();

            Assert.True(checker.IsBipartite(graph));
        }

        [Fact]
        public void TwoComponents()
        {
            var graph = new int[6][];
            graph[0] = new[] { 1 };
            graph[1] = new[] { 0, 3 };
            graph[2] = new[] { 4,5 };
            graph[3] = new[] { 1 };
            graph[4] = new[] {2};
            graph[5] = new[] { 2 };

            var checker = new BipartiteChecker();

            Assert.True(checker.IsBipartite(graph));
        }

        [Fact]
        public void TwoComponents_not_bipartite()
        {
            var graph = new int[6][];
            graph[0] = new[] { 1 };
            graph[1] = new[] { 0, 3 };
            graph[2] = new[] { 4, 5 };
            graph[3] = new[] { 1 };
            graph[4] = new[] { 2,5 };
            graph[5] = new[] { 2 ,4};

            var checker = new BipartiteChecker();

            Assert.False(checker.IsBipartite(graph));
        }
    }
}