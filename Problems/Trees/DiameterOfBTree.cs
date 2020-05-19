using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems.Trees
{
    public class DiameterOfBTree
    {
        //https://leetcode.com/problems/diameter-of-binary-tree/
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            var diameter = GetDepth(root.left) + GetDepth(root.right);

            return Math.Max(diameter, Math.Max(DiameterOfBinaryTree(root.left), DiameterOfBinaryTree(root.right)));
        }

        private int GetDepth(TreeNode root)
        {
            if (root == null) return 0;
            var depth = Math.Max(GetDepth(root.left), GetDepth(root.right)) + 1;
            return depth;
        }
    }
}