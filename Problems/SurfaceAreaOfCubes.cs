namespace Problems
{
    public class SurfaceAreaOfCubes
    {
        //https://leetcode.com/problems/surface-area-of-3d-shapes/
        public int SurfaceArea(int[][] grid)
        {
            var surfaceArea = 0;
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    surfaceArea += OpenSurfaceCount(grid, i, j);
                }
            }

            return surfaceArea;
        }

        private int OpenSurfaceCount(int[][] grid, int i, int j)
        {
            var count = 0;
            for (var h = 1; h <= grid[i][j]; h++)
            {
                if (i + 1 == grid.GetLength(0)) count++;
                else
                    if (grid[i + 1][j] < h) count++;

                if (i - 1 < 0) count++;
                else
                    if (grid[i - 1][j] < h) count++;
                
                if (j + 1 == grid[i].Length) count++;
                else
                    if (grid[i][j + 1] < h) count++;

                if (j - 1 < 0)count++;
                else
                    if (grid[i][j - 1] < h) count++;
                
            }

            
            return grid[i][j]>0?count+2: count;//the top and bottom surface
        }
    }
}