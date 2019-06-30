using System;

namespace Problems
{
    public class MinCostStairs
    {
        //https://leetcode.com/problems/min-cost-climbing-stairs/description/
        //On a staircase, the i-th step has some non-negative cost cost[i] assigned (0 indexed).
        //Once you pay the cost, you can either climb one or two steps.You need to find minimum cost to reach the top of the floor, and you can either start from the step with index 0, or the step with index 1.

        public int MinCostClimbingStairs(int[] stepCost)
        {
            var n = stepCost.Length;
            if (n == 1) return 0;
            if (n == 2) return Math.Min(stepCost[0], stepCost[1]);
            var climbingCost = new int[n];

            climbingCost[n - 1] = stepCost[n - 1];
            climbingCost[n - 2] = stepCost[n - 2];
            
            for (int i = n - 3; i >= 0; i--)
            {
                climbingCost[i] = stepCost[i] + Math.Min(climbingCost[i + 1], climbingCost[i + 2]);
            }

            return Math.Min(climbingCost[0], climbingCost[1]);
        }
    }
}