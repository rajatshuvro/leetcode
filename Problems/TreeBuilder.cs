using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class TreeBuilder
    {
        Dictionary<int, int> _inOrderIndex;
        private int[] _preOrder;
        private int _rootIndex;
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0) return null;
            _preOrder = preorder;

            _inOrderIndex = new Dictionary<int, int>(_preOrder.Length);

            for (var i = 0; i < inorder.Length; i++)
                _inOrderIndex[inorder[i]] = i;

            return BuildTree(0, inorder.Length-1);
        }

        private TreeNode BuildTree(int i, int j)
        {
            if (_rootIndex >= _preOrder.Length) return null;

            var val = _preOrder[_rootIndex];
            var root = new TreeNode(val);

            var index = _inOrderIndex[val];
            if (i < index)
            {
                _rootIndex++;
                root.left = BuildTree( i, index - 1);
            }

            if (index < j)
            {
                _rootIndex++;
                root.right = BuildTree( index + 1, j);
            }
            return root;
        }
    }
}