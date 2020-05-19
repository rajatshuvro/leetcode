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

        private static TreeNode Build(string[] s, int i)
        {
            if (i >= s.Length) return null;
            if (i < s.Length && s[i].Trim() == "null") return null;
            
            var node = new TreeNode(int.Parse(s[i]));
            node.left = Build(s, 2 * i + 1);
            node.right = Build(s, 2 * i + 2);

            return node;
        }
    }
}