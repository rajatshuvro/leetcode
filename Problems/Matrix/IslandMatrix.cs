using System.Collections.Generic;

namespace Problems.Matrix
{
    public class IslandMatrix
    {
        private const char Land = '1';
        public static int NumIslands(char[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if(grid[i][j] != Land) continue;//its water or known island, so just continue.
                    grid[i][j] = (char) (Land + count + 1);
                    Explore(grid, i, j);
                    count++;
                }
            }

            return count;
        }

        private static void Explore(char[][] grid, int i, int j)
        {
            var islandTag = grid[i][j];
            var queue = new Queue<(int, int)>();
            queue.Enqueue((i,j));
            while (queue.Count > 0)
            {
                (i, j) = queue.Dequeue();
                if(TagCell(grid, i-1, j, islandTag)) queue.Enqueue((i-1,j));
                if(TagCell(grid, i+1, j, islandTag)) queue.Enqueue((i+1,j));
                if(TagCell(grid, i, j-1, islandTag)) queue.Enqueue((i,j-1));
                if(TagCell(grid, i, j+1, islandTag)) queue.Enqueue((i,j+1));
            }
        }

        private static bool TagCell(char[][] grid, int i, int j, char tag)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length) return false;

            if (grid[i][j] == Land)
            {
                grid[i][j] = tag;
                return true;
            }
            return false;
        }
    }
}