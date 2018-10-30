using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class BinarySearchTree<T> where T:IComparable<T>
    {
        private TreeNode<T> _root;

        public void Add(TreeNode<T> node)
        {
            Add(node, ref _root);
        }

        private static void Add(TreeNode<T> node, ref TreeNode<T> root)
        {
            if (root == null)
            {
                root = node;
                return;
            }

            if (root.Value.CompareTo(node.Value) >= 0) Add(node, ref root.Left);
            else Add(node, ref root.Right);
        }

        public IEnumerable<TreeNode<T>> GetValuesInOrder()
        {
            return GetValuesInOrder(_root);
        }

        private IEnumerable<TreeNode<T>> GetValuesInOrder(TreeNode<T> root)
        {
            if (root == null) yield break;

            foreach (var node in GetValuesInOrder(root.Left))
            {
                yield return node;
            }

            yield return root;

            foreach (var node in GetValuesInOrder(root.Right))
            {
                yield return node;
            }
        }

        public IEnumerable<TreeNode<T>> GetValuesWithin(T begin, T end)
        {
            return GetValuesWithin(_root, begin, end);
        }

        private IEnumerable<TreeNode<T>> GetValuesWithin(TreeNode<T> root, T begin, T end)
        {
            if (root == null) yield break;

            if (begin.CompareTo(root.Value) < 0)
            {
                foreach (var node in GetValuesWithin(root.Left, begin, root.Value))
                {
                    yield return node;
                }
            }

            if (begin.CompareTo(root.Value) <= 0 && root.Value.CompareTo(end) <= 0) yield return root;

            if (end.CompareTo(root.Value) > 0)
            {
                foreach (var node in GetValuesWithin(root.Right, root.Value, end))
                {
                    yield return node;
                }
            }
        }
    }
}