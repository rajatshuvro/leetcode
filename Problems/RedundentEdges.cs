namespace Problems
{
    public class RedundentEdges
    {
        public static int[] FindRedundantConnection(int[,] edges)
        {
            var unionFinder = new DataStructures.UnionFinder<int>();
            int a = -1, b = -1;
            for (var i = 0; i < edges.GetLength(0); i++)
            {
                if (!unionFinder.Unite(edges[i, 0], edges[i, 1])) continue;
                a = edges[i, 0];
                b = edges[i, 1];
            }
            return new[] { a, b };
        }
    }
}