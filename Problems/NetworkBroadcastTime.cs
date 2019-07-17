using System.Linq;
using Algorithms;
using Utilities;

namespace Problems
{
    public class NetworkBroadcastTime
    {
        //https://leetcode.com/problems/network-delay-time/
        public int NetworkDelayTime(int[][] times, int N, int K)
        {
            var diGraph = GraphUtilities.GetDiGraphFromWeightedEdges(times, N);
            var shortestDistances = Dijkstras<int>.GetShortestDistancesFrom(diGraph, K -1);
            var maxTime = shortestDistances.Values.Max();
            return maxTime == int.MaxValue? -1: maxTime;
        }
    }
}