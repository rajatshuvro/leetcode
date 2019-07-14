using Problems;
using Xunit;

namespace UnitTests
{
    public class EventualSafeStateTests
    {
        [Fact]
        public void TestCase_0()
        {
            var graph = new int[7][];
            graph[0] = new[] { 1, 2 };
            graph[1] = new[] { 2, 3 };
            graph[2] = new[] { 5 };
            graph[3] = new[] { 0 };
            graph[4] = new[] { 5 };
            graph[5] = new int[0] ;
            graph[6] = new int[0];

            var safetyFinder = new FindEventualSafeStates();
            Assert.Equal(new []{ 2, 4, 5, 6 }, safetyFinder.EventualSafeNodes(graph));

        }

        [Fact]
        public void TestCase_1()
        {
            //[[0],[2,3,4],[3,4],[0,4],[]]
            var graph = new int[5][];
            graph[0] = new[] { 0 };
            graph[1] = new[] { 2, 3, 4 };
            graph[2] = new[] { 3,4 };
            graph[3] = new[] { 0,4 };
            graph[4] = new int[0];
            
            var safetyFinder = new FindEventualSafeStates();
            Assert.Equal(new[] { 4 }, safetyFinder.EventualSafeNodes(graph));

        }
    }
}