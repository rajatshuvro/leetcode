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
            //"1-2--3--4-5--6--7"
            var (val, depth) = GetNextNode(preOrder);
            var root = new TreeNode(val);
            var (leftSubTree, rightSubTree) = GetSubTreeStrings(preOrder, depth);
            root.left = RecoverFromPreorder(leftSubTree);
            root.right = RecoverFromPreorder(rightSubTree);

            return root;
        }

        private (string leftSubTree, string rightSubTree) GetSubTreeStrings(string preOrder, int parentDepth)
        {
            var depth = parentDepth + 1;
            var depthChars = new char[depth];
            Array.Fill(depthChars, '-');
            var depthString = new string(depthChars);

            var leftStartIndex = preOrder.IndexOf(depthString);
            var rightStartIndex = preOrder.IndexOf(depthString, leftStartIndex + depth);
            while ((rightStartIndex < preOrder.Length && preOrder[rightStartIndex-1] == '-' )
                   || (rightStartIndex+ depth < preOrder.Length && preOrder[rightStartIndex+depth] == '-'))
            {
                rightStartIndex = preOrder.IndexOf(depthString, rightStartIndex + depth);
            }

            if (rightStartIndex >= 0)
            {
                var leftSubTreeString = preOrder.Substring(leftStartIndex, rightStartIndex - leftStartIndex);
                var rightSubTreeString = preOrder.Substring(rightStartIndex);

                return (leftSubTreeString, rightSubTreeString);
            }

            return (preOrder.Substring(leftStartIndex), null);

        }

        private (int val, int depth) GetNextNode(string preOrder)
        {
            var val = 0;
            var depth = 0;
            var i = 0;
            while (i < preOrder.Length && preOrder[i]=='-')
            {
                depth++;
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