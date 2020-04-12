using System.Collections.Generic;
using DataStructures;

namespace Problems.Trees
{
    public class BinTreeFromPostAndInOrder
    {
        //https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
        private Dictionary<int, int> _inOrderIndices;
        private int[] _inOrder;
        private int[] _postOrder;
        private int _n;
        private int _rootIndex;
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder == null || inorder.Length == 0) return null;
            if (inorder.Length == 1) return new TreeNode(inorder[0]);
            _n = inorder.Length;
            _inOrder = inorder;
            _postOrder = postorder;
            // we need to find a node from the inorder array quickly
            _inOrderIndices = new Dictionary<int, int>(inorder.Length);
            for (int i = 0; i < _n; i++)
            {
                _inOrderIndices[_inOrder[i]] = i;
            }

            //the root is the last node in post order
            _rootIndex = _n-1;

            return BuildTree( 0, _n - 1);
        }

        private TreeNode BuildTree(int i, int j)
        {
            if (_rootIndex < 0 ) return null;
            var root = new TreeNode(_postOrder[_rootIndex]);
            if (i >= j) return root;
            
            var inOrderRootIndex = _inOrderIndices[root.val];
            if (inOrderRootIndex < j)
            {
                _rootIndex--;
                root.right = BuildTree(inOrderRootIndex + 1, j);
            }

            if (i < inOrderRootIndex)
            {
                _rootIndex--;
                root.left = BuildTree( i, inOrderRootIndex - 1);

            }
            return root;
        }
    }
}