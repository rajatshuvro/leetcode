using System;
using System.Collections.Generic;

namespace MinDistBstNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minimum Distance Between BST Nodes!");

            
            var result = UnitTest1();

            Console.ReadKey();
        }

        private static bool UnitTest1()
        {
            var s = new Solution();

            var root = new TreeNode(5)
            {
                left = new TreeNode(3),
                right = new TreeNode(7)
            };

            s.MinDiffInBST(root);
            return true;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public class Solution
        {
            private long _lastVal = long.MinValue;
            private long _minDiff = long.MaxValue; //0 indicates invalid since all values are distinct
            private bool isFirstValue = true;
            public int MinDiffInBST(TreeNode root)
            {
                //special check for null root on one element tree
                if (root == null) return 0;
                if (root.left == null && root.right == null) return 0;
                //since this is a BST, traversing in-order will give a sorted order and we can keep track of the min diff
                foreach (var val in InorderTraversal(root))
                {
                    if (isFirstValue)
                    {
                        isFirstValue = false;
                    }
                    else
                    {
                        var diff = Math.Abs(_lastVal - val);
                        _minDiff = diff < _minDiff ? diff : _minDiff;
                    }

                    Console.WriteLine($"val:{val}, min-diff:{_minDiff}");
                    _lastVal = val;

                }

                return (int)_minDiff;
            }

            private IEnumerable<int> InorderTraversal(TreeNode root)
            {
                if (root == null) yield break;

                foreach (var val in InorderTraversal(root.left))
                {
                    yield return val;
                }
                yield return root.val;

                foreach (var val in InorderTraversal(root.right))
                {
                    yield return val;
                }


            }
            //private void TraverseInorder(TreeNode root)
            //{
            //    if (root == null) return;

            //    TraverseInorder(root.left);

            //    var diff = _lastVal==long.MinValue? 0: Math.Abs(root.val - _lastVal);//this is the first value in the series
            //    _minDiff = _minDiff == 0 ? diff : Math.Min(diff, _minDiff);
            //    _lastVal = root.val;

            //    TraverseInorder(root.right);

            //}
        }

    }

}
