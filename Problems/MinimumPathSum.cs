using System;

namespace Problems
{
    public class MinimumPathSum
    {
        //https://leetcode.com/problems/minimum-path-sum/
        public int MinPathSum(int[][] grid) {
            var costs= new int [2][];
            var n = grid.Length;
            var m = grid[0].Length;
            costs[0]= new int[m];
            costs[1] = new int[m];

            var costIndex = 0;
            costs[0][0] = grid[0][0];

            //initialize the first row of the cost grid
            for (var j = 1; j < m; j++)
            {
                costs[0][j] = costs[0][j - 1] + grid[0][j];
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    if (j == 0)
                    {
                        costs[i%2][j] = grid[i][j] + costs[(i + 1) % 2][j];
                        continue;
                    }
                    
                    costs[i%2][j] = grid[i][j] + Math.Min(costs[(i+1) % 2][j], costs[i%2][j - 1]);
                }

                costIndex = i;
            }

            return costs[costIndex%2][m-1];
        }
    }
}