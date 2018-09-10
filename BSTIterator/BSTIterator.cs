using System.Collections.Generic;

namespace BSTIterator
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    //https://leetcode.com/problems/binary-search-tree-iterator/description/
    public class BSTIterator
    {
        private List<TreeNode> _parentNodes= new List<TreeNode>();
        private TreeNode _currentNode;
        public BSTIterator(TreeNode root)
        {
            _currentNode = root;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {

        }

        /** @return the next smallest number */
        public int Next()
        {
            while (!IsLeaf(_currentNode))
            {
                _parentNodes.Add(_currentNode);

            }
        }

        private bool IsLeaf(TreeNode node)
        {
            return node.left == null && node.right == null;
        }
    }
}