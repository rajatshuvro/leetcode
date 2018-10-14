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

            var stack = new List<TreeNode>(){root};
            var inOrder = new List<int>();

            while (stack.Count>0)
            {
                var node = stack[stack.Count - 1];
                if (node.left != null)
                {
                    stack.Add(node.left);
                    node.left = null;
                    continue;
                }

                stack.RemoveAt(stack.Count - 1);

                inOrder.Add(node.val);
                if (node.right != null)
                {
                    stack.Add(node.right);
                    node.right = null;
                }
            }

            return inOrder;
        }

        //https://leetcode.com/problems/binary-tree-preorder-traversal/description/
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null) return new List<int>();

            var stack = new List<TreeNode>() { root };
            var preOrder = new List<int>();

            while (stack.Count > 0)
            {
                var node = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                preOrder.Add(node.val);

                if (node.left != null)
                {
                    stack.Add(node.left);
                    node.left = null;
                    continue;
                }

                if (node.right != null)
                {
                    stack.Add(node.right);
                    node.right = null;
                }
            }

            return preOrder;
        }
    }
}