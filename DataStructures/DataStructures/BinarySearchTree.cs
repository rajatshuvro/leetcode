using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class BinarySearchTree<T> where T:IComparable<T>
    {
        private TreeNode<T> _root;

        public void Add(T value)
        {
            Add(new TreeNode<T>(value));
        }

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

        private TreeNode<T> _predecessor, _successor;
        public (TreeNode<T> predecessor,TreeNode<T> successor) GetPredecessorAndSuccessor(T value)
        {
            if (_root == null) return (null, null);

            GetPredecessorAndSuccessor(value, _root);
            return (_predecessor,_successor);
        }

        public void GetPredecessorAndSuccessor(T value, TreeNode<T> root)
        {
            if (root == null) return;
            if (root.Value.CompareTo(value) < 0)
            {
                _successor = root;
                GetPredecessorAndSuccessor(value, root.Left);
            }

            if (root.Value.CompareTo(value) > 0)
            {
                _predecessor = root;
                GetPredecessorAndSuccessor(value, root.Right);
            }
            // we found the value
            if (root.Left != null)
            {
                _predecessor = root.Left;
                while (_predecessor.Right != null)
                    _predecessor = _predecessor.Right;
            }

            if (root.Right != null)
            {
                _successor = root.Right;
                while (_successor.Left != null)
                    _successor = _successor.Left;
            }

        }

        public TreeNode<T> Find(T value)
        {
            var currentNode = _root;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0) return currentNode;
                currentNode = currentNode.Value.CompareTo(value) < 0 ? currentNode.Right : currentNode.Left;
            }

            return null;
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