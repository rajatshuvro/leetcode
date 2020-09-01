namespace Problems.ArrayProblems
{
    //https://www.hackerrank.com/challenges/crush/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=arrays
    public class MaxNumber
    {
        public static long arrayManipulation(int n, int[][] queries)
        {
            var array = new long[n+1];

            long max = 0;
            for (int i = 0; i < queries.Length; i++)
            {
                var query = queries[i];
                var a = query[0];
                var b = query[1];
                var k = query[2];

                array[a - 1] += k;
                array[b] -= k;
                
            }

            long slope = 0;
            for (int i = 0; i < array.Length; i++)
            {
                slope += array[i];
                if (max < slope) max = slope;
            }
            return max;
        }

    }
}