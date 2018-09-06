namespace MaxAreaOfIsland
{
    public class Solution
    {
        private int[,] _grid;
        private int _dim1;
        private int _dim2;
        public int MaxAreaOfIsland(int[,] grid)
        {
            var newIslandId = -1;
            var maxArea = 0;
            _grid = grid;
            _dim1 = grid.GetLength(0);
            _dim2 = grid.GetLength(1);
            for (int i = 0; i < _dim1; i++)
            for (int j = 0; j < _dim2; j++)
            {
                if (grid[i, j] <= 0) continue;

                var area = ExploreNewIsland(i, j, newIslandId);

                newIslandId--;

                if (area > maxArea) maxArea = area;
            }
            return maxArea;
        }

        private int ExploreNewIsland(int i, int j, int islandId)
        {
            if (i < 0 || i >= _dim1) return 0;
            if (j < 0 || j >= _dim2) return 0;
            if (_grid[i, j] <= 0) return 0;

            int size = 1;
            _grid[i, j] = islandId;

            size += ExploreNewIsland(i - 1, j, islandId);
            size += ExploreNewIsland(i + 1, j, islandId);
            size += ExploreNewIsland(i, j - 1, islandId);
            size += ExploreNewIsland(i, j + 1, islandId);

            return size;
        }
    }
}