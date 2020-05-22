namespace UnitTests.Utilities
{
    public class Deserializer
    {
        public static int[][] GetGrid(string s)
        {
            //[[2,1,1],[1,1,0],[0,1,1]]
            s = s.Trim('[', ']');
            var columns = s.Split("],[");
            var n = columns.Length;
            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var column = columns[i].Trim('[', ']');
                var values = column.Split(',');
                matrix[i] = new int[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    matrix[i][j] = int.Parse(values[j]);
                }
            }

            return matrix;
        }
    }
}