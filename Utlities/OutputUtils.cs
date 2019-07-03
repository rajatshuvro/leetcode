using System.Text;

namespace Utilities
{
    public static class OutputUtils
    {
        public static string PrintEdges(int[,] edges)
        {
            var sb = new StringBuilder();
            sb.Append('[');
            for (var i = 0; i < edges.GetLength(0); i++)
                sb.Append($"[{edges[i, 0]}, {edges[i, 1]}]");
            sb.Append(']');

            return sb.ToString();
        }
    }
}
