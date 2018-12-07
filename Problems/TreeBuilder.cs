using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class TreeBuilder
    {
        Dictionary<int, int> _inOrderIndex= new Dictionary<int, int>();
        private int[] _inOrder;
        private int[] _preOrder;
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            _inOrder = inorder;
            _preOrder = preorder;

            for (var i = 0; i < inorder.Length; i++)
                _inOrderIndex[inorder[i]] = i;

            return BuildTree(0, 0, inorder.Length-1);
        }

        private TreeNode BuildTree(int rootIndex, int i, int j)
        {
            if (rootIndex >= _preOrder.Length) return null;

            var val = _preOrder[rootIndex];
            var root = new TreeNode(val);

            var index = _inOrderIndex[val];
            if(i < index)
                root.left = BuildTree(++rootIndex, i, index - 1);
            if(index < j)
                root.right = BuildTree(++rootIndex, index + 1, j);
            return root;
        }
    }
}