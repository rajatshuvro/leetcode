using System;
using System.Collections.Generic;

namespace Problems.Matrix
{
    public class RottenOranges
    {
        //https://leetcode.com/problems/rotting-oranges/
        public int OrangesRotting(int[][] grid)
        {
            var rottenCells = new Queue<(int, int)>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2) rottenCells.Enqueue((i,j));
                }
            }

            var time = 0;
            GetNewRottenCells(rottenCells, grid);
            while (rottenCells.Count > 0)
            {
                time++;
                GetNewRottenCells(rottenCells, grid);
            }

            return HasFreshOranges(grid)?  -1 : time;
        }

        private bool HasFreshOranges(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) return true;
                }
            }

            return false;
        }

        private void GetNewRottenCells(Queue<(int, int)> rottenCells, int[][] grid)
        {
            var count = rottenCells.Count;
            // by doing only c interations we ensure that we only take out the rotten cells at time t0
            // by the end of this loop, the queue contains new rotten cells for t1.
            for (int c = 0; c < count; c++)
            {
                var (i, j) = rottenCells.Dequeue();
                if (j > 0 && grid[i][j - 1] == 1)
                {
                    //left neighbor
                    grid[i][j - 1] = 2;
                    rottenCells.Enqueue((i, j-1));
                }
                if (j < grid[i].Length-1 && grid[i][j + 1] == 1)
                {
                    //right neighbor
                    grid[i][j + 1] = 2;
                    rottenCells.Enqueue((i, j + 1));
                }
                if (i > 0 && grid[i-1][j] == 1)
                {
                    //upstairs neighbor
                    grid[i-1][j] = 2;
                    rottenCells.Enqueue((i-1, j));
                }
                if (i < grid.Length -1 && grid[i+1][j] == 1)
                {
                    //downstairs neighbor
                    grid[i+1][j] = 2;
                    rottenCells.Enqueue((i+1, j));
                }
            }
            
        }
        
    }
}