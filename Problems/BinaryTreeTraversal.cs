using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class BinaryTreeTraversal
    {
        //https://leetcode.com/problems/binary-tree-inorder-traversal/description/

        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            var stack = new Stack<TreeNode>();
            stack.Push(root);
            var inOrder = new List<int>();

            while (stack.Count>0)
            {
                var node = stack.Peek();
                if (node.left != null)
                {
                    stack.Push(node.left);
                    node.left = null;
                    continue;
                }

                inOrder.Add(stack.Pop().val);
                if (node.right != null)
                {
                    stack.Push(node.right);
                    node.right = null;
                }
            }

            return inOrder;
        }

        //https://leetcode.com/problems/binary-tree-preorder-traversal/description/
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            var stack = new Stack<TreeNode>();
            stack.Push(root);
            var preOrder = new List<int>();

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                preOrder.Add(node.val);

                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                }
                
            }

            return preOrder;
        }
    }
}