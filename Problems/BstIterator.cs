using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class BstIterator
    {
        private List<TreeNode> _stack = new List<TreeNode>();
        public BstIterator(TreeNode root)
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
            var top = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);

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