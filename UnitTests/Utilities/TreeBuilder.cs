using DataStructures;

namespace UnitTests.Utilities
{
    public static class TreeBuilder
    {
        //leetcode tree builder
        public static TreeNode Build(string s)
        {
            s = s.Trim(new[] {'[', ']'});
            if (string.IsNullOrEmpty(s)) return null;

            var nodeVals = s.Split(',');

            return Build(nodeVals, 0);
        }

        private static TreeNode Build(string[] nodeVals, int i)
        {
            if (i >= nodeVals.Length) return null;
            if (i < nodeVals.Length && nodeVals[i] == "null") return null;
            
            var node = new TreeNode(int.Parse(nodeVals[i]));
            node.left = Build(nodeVals, 2 * i + 1);
            node.right = Build(nodeVals, 2 * i + 2);

            return node;
        }
    }
}