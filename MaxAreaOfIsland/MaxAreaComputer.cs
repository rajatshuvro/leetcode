using System;
using System.Collections.Generic;

namespace MaxAreaOfIsland
{
    class MaxAreaComputer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Computing max area of island!");
            var result = UnitTest1();
            result &= UnitTest2();

            if (result)
                Console.WriteLine("Passed all unit tests");

            Console.Read();
        }

        private static bool UnitTest2()
        {
            var grid = new int[,] { {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
                {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0}};

            if (MaxAreaOfIsland(grid) == 11)
                return true;

            Console.WriteLine("Failed unit test 2");
            return false;
        }

        private static bool UnitTest1()
        {
            var grid = new int[,] { {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0},
                {0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0}};

            if (MaxAreaOfIsland(grid) == 6)
                return true;

            Console.WriteLine("Failed unit test 1");
            return false;
        }

        public static int MaxAreaOfIsland(int[,] grid)
        {
            var newIslandId = -1;
            var maxArea = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] <= 0) continue;

                    var area = ExploreNewIsland(grid, i, j, newIslandId);

                    newIslandId--;

                    if (area > maxArea) maxArea = area;
                }

            return maxArea;
        }

        private static int ExploreNewIsland(int[,] grid, int i, int j, int islandId)
        {
            if (i < 0 || i >= grid.GetLength(0)) return 0;
            if (j < 0 || j >= grid.GetLength(1)) return 0;
            if (grid[i, j] <= 0) return 0;

            int size = 1;
            grid[i, j] = islandId;
            
            size += ExploreNewIsland(grid, i - 1, j, islandId);
            size += ExploreNewIsland(grid, i + 1, j, islandId);
            size += ExploreNewIsland(grid, i, j - 1, islandId);
            size += ExploreNewIsland(grid, i, j + 1, islandId);

            return size;
        }
    }
}
