using System.Collections.Generic;
using System.Linq;

namespace LeafSimilarTrees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public static class LeafSimilarCheck
    {
        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var leaves1= new List<int>();
            GetLeaves(root1, leaves1);

            var leaves2 = new List<int>();
            GetLeaves(root2, leaves2);

            return leaves1.SequenceEqual(leaves2);
        }

        public static void GetLeaves(TreeNode root, List<int> leaves)
        {
            if (root.left == null && root.right == null)
            {
                leaves.Add(root.val);
                return;
            }

            if (root.left != null ) GetLeaves(root.left, leaves);
            if (root.right != null) GetLeaves(root.right, leaves);
        }
    }
}