using System.Collections.Generic;
using DataStructures;

namespace Problems.Trees
{
    //https://leetcode.com/problems/binary-tree-paths/
    public class AllBinaryTreePaths
    {
        private List<string> _paths= new List<string>();
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            GetAllPaths(root, "");
            return _paths;
        }

        private void GetAllPaths(TreeNode node, string ancestry)
        {
            if (node == null) return;
            if (!string.IsNullOrEmpty(ancestry)) ancestry += "->";
            if (IsLeaf(node))
            {
                _paths.Add(ancestry + $"{node.val}");
                return;
            }
            GetAllPaths(node.left , ancestry + $"{node.val}");
            GetAllPaths(node.right , ancestry + $"{node.val}");
        }

        private bool IsLeaf(TreeNode node) => node.left == null && node.right == null;

    }
}