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
        private List<TreeNode> _ancestors= new List<TreeNode>();
        // node status can be
        // ------left-traversed (l) 
        // ------right-traversed (r) 
        private Dictionary<TreeNode, char> _nodeStatus = new Dictionary<TreeNode, char>();
        private TreeNode _currentNode;
        public BSTIterator(TreeNode root)
        {
            _currentNode = root;
            DiveLeft();
        }

        private void DiveLeft()
        {
            while (_currentNode.left != null)
            {
                _nodeStatus[_currentNode] = 'l';
                _ancestors.Add(_currentNode);
                _currentNode = _currentNode.left;
            }
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {

        }

        /** @return the next smallest number */
        public int Next()
        {
            if (_currentNode == null) return int.MinValue;

            var value = _currentNode.val;

            //move to next node
            if (_currentNode.right != null && _nodeStatus[_currentNode]=='l')
            {
                _ancestors.Add(_currentNode);
                _nodeStatus[_currentNode] = 'r';
                //var rightNode = _currentNode.right;
                _currentNode = _currentNode.right;

                DiveLeft();
            }
            else
            {
                while (_currentNode != null)
                {
                }

                _currentNode = _ancestors.Count > 0 ? _ancestors[_ancestors.Count - 1] : null;
                _ancestors.RemoveAt(_ancestors.Count);
            }

            return value;
        }

        private bool IsLeaf(TreeNode node)
        {
            return node.left == null && node.right == null;
        }
    }
}