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
            if (_root == null)
            {
                _root = node;
                return;
            }

            var current = _root;
            while (true)
            {
                if (current.Value.CompareTo(node.Value) >= 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = node;
                        return;
                    }
                    current = current.Left;
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = node;
                        return;
                    }
                    current = current.Right;
                }
            }
        }

        public void Remove(T value)
        {
            _root = Remove(value, _root);
        }

        //returns new tree root of the tree with value deleted
        private TreeNode<T> Remove(T value, TreeNode<T> node)
        {
            if (node == null) return null;
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null) return node;
                node.Left = Remove(value, node.Left);
                return node;
            }

            if (value.CompareTo(node.Value) > 0)
            {
                if (node.Right == null) return node;
                node.Right = Remove(value, node.Right);
                return node;
            }

            //value found
            //if one of the children is null, the other can replace the node
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;
            
            //both child present, replace the node with its predecessor
            var predecessor = FindMaxNode(node.Left);

            node.Left = Remove(predecessor.Value, node.Left);
            node.Value = predecessor.Value;

            return node;
        }

        private TreeNode<T> FindMaxNode(TreeNode<T> node)
        {
            if (node == null) return null;
            while (node.Right != null)
                node = node.Right;

            return node;
        }

        public bool IsLeaf(TreeNode<T> node)
        {
            return node.Left == null && node.Right == null;
        }

        public IEnumerable<TreeNode<T>> GetValuesInOrder()
        {
            return GetValuesInOrder(_root);
        }

        private TreeNode<T> _predecessor, _successor;
        public (TreeNode<T> predecessor,TreeNode<T> successor) GetPredecessorAndSuccessor(T value)
        {
            if (_root == null) return (null, null);
            _predecessor = null;
            _successor = null;
            GetPredecessorAndSuccessor(value, _root);
            return (_predecessor,_successor);
        }

        public void GetPredecessorAndSuccessor(T value, TreeNode<T> root)
        {
            if (root == null) return;

            if (root.Value.CompareTo(value) == 0)
            {
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
            else
            {
                if (root.Value.CompareTo(value) > 0)
                {
                    _successor = root;
                    GetPredecessorAndSuccessor(value, root.Left);
                }
                else
                {
                    _predecessor = root;
                    GetPredecessorAndSuccessor(value, root.Right);
                }
            }

            
            
        }

        public TreeNode<T> Find(T value)
        {
            var node = _root;
            while (node != null)
            {
                if (node.Value.CompareTo(value) == 0) return node;
                node = node.Value.CompareTo(value) < 0 ? node.Right : node.Left;
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