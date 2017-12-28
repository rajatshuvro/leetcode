using System;

namespace RangeSum2D
{
    class RangeSum2D
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Range sum query of 2D matrix (immutable)!");

            var result = Test1();

            if (result)
                Console.WriteLine("Passed all tests");

            Console.ReadKey();
        }

        private static bool Test1()
        {
            var matrix = new int[,] { {3, 0, 1, 4, 2},
                {5, 6, 3, 2, 1},
                {1, 2, 0, 1, 5},
                {4, 1, 0, 1, 7},
                {1, 0, 3, 0, 5}};

            var sol = new RangeSum2D(matrix);

            var rangeSum = sol.SumRegion(2, 1, 4, 3);
            if (rangeSum != 8)
            {
                Console.WriteLine("Wrong range for ((2,1),(4,3)). Expected 8, observed:"+rangeSum);
                return false;
            }

            rangeSum = sol.SumRegion(1, 1, 2, 2);
            if (rangeSum != 11)
            {
                Console.WriteLine("Wrong range for ((1,1),(2,2)). Expected 11, observed:" + rangeSum);
                return false;
            }

            rangeSum = sol.SumRegion(1, 2, 2, 4);
            if (rangeSum != 12)
            {
                Console.WriteLine("Wrong range for ((1,2),(2,4)). Expected 12, observed:" + rangeSum);
                return false;
            }
            return true;
        }

        private readonly int[,] _cumulatives;// _cumulative[i,j]= m[i,0]+m[i,1]+.....+m[i,j]
        public RangeSum2D(int[,] matrix)
        {
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);
            _cumulatives = new int[n, m];

            for (var i = 0; i < n; i++)
            {
                _cumulatives[i, 0] = matrix[i, 0];
                for (var j = 1; j < m; j++)
                    _cumulatives[i, j] = _cumulatives[i, j - 1] + matrix[i, j];
            }

        }

        public int SumRegion(int row1, int col1, int row2, int col2)
        {
            if (row1 > row2 || col1 > col2) return 0;
            var sum = 0;
            for (var i = row1; i <= row2; i++)
            {
                if (col1 == 0)
                    sum += _cumulatives[i, col2];
                else
                    sum += _cumulatives[i, col2] - _cumulatives[i, col1 - 1];
            }

            return sum;
        }
    }
}
