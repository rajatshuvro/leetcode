using System;

namespace Problems.DynamicProgramming
{
    public class RangeSum2D
    {

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
