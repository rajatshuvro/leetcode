using System;
using DataStructures;

namespace Problems.Trees
{
    public class BinTreeFromPreOrder
    {
        //https://leetcode.com/problems/recover-a-tree-from-preorder-traversal/
        public TreeNode RecoverFromPreorder(string preOrder)
        {
            if (string.IsNullOrEmpty(preOrder)) return null;
            var i = 0;
            var (val, depth) = GetNextNode(preOrder, ref i);
            var root = new TreeNode(val);
            var (leftSubTree, rightIndex) = GetSubTreeString(preOrder.Substring(i), depth);
            if (leftSubTree == null) return root;
            var rightSubTree = preOrder.Substring(i+rightIndex);
            root.left = RecoverFromPreorder(leftSubTree);
            root.right = RecoverFromPreorder(rightSubTree);

            return root;
        }

        private (string, int) GetSubTreeString(string preOrder, int parentDepth)
        {
            if(string.IsNullOrEmpty(preOrder)) return (null, -1);
            var depth = parentDepth + 1;
            var i = 0;
            var (nextDepth, nextIndex) = GetNextHeightAndIndex(preOrder, i);
            if (nextDepth != depth) return (null, -1);
            i = nextIndex;
            do
            {
                (nextDepth, nextIndex) = GetNextHeightAndIndex(preOrder, i);
                if (nextDepth <= depth) break;
                i = nextIndex;

            } while (i < preOrder.Length);

            while (i < preOrder.Length && char.IsDigit(preOrder[i])) i++;
            
            return i==preOrder.Length? (preOrder, preOrder.Length):(preOrder.Substring(0, i), i);

        }

        private (int depth, int i) GetNextHeightAndIndex(string preOrder, int i)
        {
            var depth = 0;
            while (i < preOrder.Length && char.IsDigit(preOrder[i])) i++;//skip numbers
            while (i < preOrder.Length && preOrder[i]=='-')
            {
                depth++;
                i++;
            }

            return (depth, i);
        }

        private (int val, int depth) GetNextNode(string preOrder, ref int i)
        {
            var val = 0;
            var depth = 0;
            
            while (i < preOrder.Length && preOrder[i]=='-')
            {
                depth++;
                i++;
            }
            while (i < preOrder.Length && char.IsDigit(preOrder[i]))
            {
                val = val * 10 + preOrder[i] - '0';
                i++;
            }

            return (val, depth);
        }
    }
}