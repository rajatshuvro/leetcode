using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems.Trees
{
    public class DiameterOfBTree
    {
        //https://leetcode.com/problems/diameter-of-binary-tree/
        private Dictionary<int, int> _heights= new Dictionary<int, int>();
        private Dictionary<int, int> _diameters = new Dictionary<int, int>();
        
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null)
            {
                _heights[root.val] = 0;
                _diameters[root.val] = 0;
                return 0;
            }

            if (root.left != null) DiameterOfBinaryTree(root.left);
            if (root.right != null) DiameterOfBinaryTree(root.right);

            if (root.left == null)
            {
                _heights[root.val] = _heights[root.right.val] + 1;
                _diameters[root.val] = Math.Max(_diameters[root.right.val], _heights[root.val]);
                return _diameters[root.val];
            }

            if (root.right == null)
            {
                _heights[root.val] = _heights[root.left.val] + 1;
                _diameters[root.val] = Math.Max(_diameters[root.left.val], _heights[root.val]);
                return _diameters[root.val];
            }

            _heights[root.val] = Math.Max(_heights[root.left.val], _heights[root.right.val]) + 1;
            _diameters[root.val] = Math.Max(
                                    Math.Max(_diameters[root.left.val], _diameters[root.right.val]), 
                                    _heights[root.left.val]+ _heights[root.right.val] + 2);

            return _diameters[root.val];
        }
    }
}