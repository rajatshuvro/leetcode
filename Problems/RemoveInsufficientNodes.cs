using DataStructures;

namespace Problems
{
    public class RemoveInsufficientNodes
    {
        //https://leetcode.com/contest/weekly-contest-140/problems/insufficient-nodes-in-root-to-leaf-paths/
        /*
         * Given the root of a binary tree, consider all root to leaf paths: paths from the root to any leaf.  (A leaf is a node with no children.)

            A node is insufficient if every such root to leaf path intersecting this node has sum strictly less than limit.

            Delete all insufficient nodes simultaneously, and return the root of the resulting binary tree.
         */
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            if (root == null) return null;
            if (root.left == null && root.right == null)
            {
                return root.val < limit ? null : root;
            }

            if (root.left != null) root.left = SufficientSubset(root.left, limit - root.val);
            if (root.right != null) root.right = SufficientSubset(root.right, limit - root.val);

            if (root.left == null && root.right == null) return null;
            return root;
        }
    }
}