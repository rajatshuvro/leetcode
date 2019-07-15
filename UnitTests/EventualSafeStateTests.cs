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

        [Fact]
        public void ThreeConnectedNodes_oneCycle()
        {
            var graph = new int[3][];
            graph[0] = new[] { 1 };
            graph[1] = new[] { 2 };
            graph[2] = new[] { 2 };
            
            var safetyFinder = new FindEventualSafeStates();
            Assert.Equal(new int[] { }, safetyFinder.EventualSafeNodes(graph));

        }
        [Fact]
        public void Nodes_in_chain()
        {
            var graph = new int[3][];
            graph[0] = new[] { 1 };
            graph[1] = new[] { 2 };
            graph[2] = new int[] { };

            var safetyFinder = new FindEventualSafeStates();
            Assert.Equal(new int[] { 0,1,2}, safetyFinder.EventualSafeNodes(graph));

        }

        [Fact]
        public void FourConnectedNodes_oneCycle_inMiddle()
        {
            var graph = new int[4][];
            graph[0] = new[] { 1 };
            graph[1] = new[] { 2 };
            graph[2] = new[] { 2, 3 };
            graph[3] = new int[] { };

            var safetyFinder = new FindEventualSafeStates();
            Assert.Equal(new int[] {3 }, safetyFinder.EventualSafeNodes(graph));

        }

        [Fact]
        public void OneCycle_oneSink()
        {
            var graph = new int[5][];
            graph[0] = new[] { 1 };
            graph[1] = new[] { 2 };
            graph[2] = new[] { 2, 3 };
            graph[3] = new int[] { };
            graph[4] = new[] { 3 };

            var safetyFinder = new FindEventualSafeStates();
            Assert.Equal(new int[] { 3 , 4 }, safetyFinder.EventualSafeNodes(graph));

        }
    }
}