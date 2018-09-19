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
        private List<TreeNode> _stack = new List<TreeNode>();
        public BSTIterator(TreeNode root)
        {
            while (root != null)
            {
                _stack.Add(root);
                root = root.left;
            }
        }

        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        public int Next()
        {
            var top = _stack[_stack.Count- 1];
            _stack.RemoveAt(_stack.Count-1);

            var result = top.val;
            top = top.right;
            while (top != null)
            {
                _stack.Add(top);
                top = top.left;
            }

            return result;
        }
        
    }
}