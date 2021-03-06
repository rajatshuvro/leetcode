﻿using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class BinarySearchTree<T> where T:IComparable<T>
    {
        private TreeNode<T> _root;
        
        public void Add(T value)
        {
            var node = new TreeNode<T>(value);
            _root = Add(node, _root);
        }
        //recursive implementation that keeps the tree balanced for random adds.
        private TreeNode<T> Add(TreeNode<T> node, TreeNode<T> root)
        {
            if (root == null)
            {
                return node;
            }

            var compare = node.Value.CompareTo(root.Value);
            if (compare <= 0)
            {
                root.Left = Add(node, root.Left);
                return Balance(root);
            }

            root.Right = Add(node, root.Right);
            return Balance(root);
        }

        private TreeNode<T> Balance(TreeNode<T> root)
        {
            if (IsBalanced(root))
            {
                root.Height = RecomputeHeight(root);
                return root;
            }

            if (GetHeight(root.Left) < GetHeight(root.Right))
            {
                var rootRight    = root.Right;
                root.Right       = rootRight.Left;
                root.Height      = RecomputeHeight(root);
                rootRight.Left   = root;
                rootRight.Height = RecomputeHeight(rootRight);
                return rootRight;
            }

            var rootLeft    = root.Left;
            root.Left       = rootLeft.Right;
            root.Height     = RecomputeHeight(root);
            rootLeft.Right  = root;
            rootLeft.Height = RecomputeHeight(rootLeft);
            return rootLeft;
        }

        private static bool IsBalanced(TreeNode<T> node)
        {
            if (node == null) return true;
            return Math.Abs(GetHeight(node.Left)-GetHeight(node.Right)) <=1;
        }

        private static byte RecomputeHeight(TreeNode<T> node)
        {
            return (byte)(Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1);
        }

        private static byte GetHeight(TreeNode<T> node)
        {
            if (node == null) return 0;
            return node.Height;
        }
        public void Remove(T value)
        {
            _root = Remove(value, _root);
        }

        //returns new tree root of the tree with value deleted
        private TreeNode<T> Remove(T value, TreeNode<T> node)
        {
            if (node == null) return null;
            var compare = value.CompareTo(node.Value);
            
            if (compare < 0)
            {
                if (node.Left == null) return node;
                node.Left = Remove(value, node.Left);
                return Balance(node);
            }

            if (compare > 0)
            {
                if (node.Right == null) return node;
                node.Right = Remove(value, node.Right);
                return Balance(node);
            }

            //value found
            //if one of the children is null, the other can replace the node
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;
            
            //both child present, replace the node with its predecessor
            var predecessor = FindMaxNode(node.Left);

            node.Left = Remove(predecessor.Value, node.Left);
            node.Value = predecessor.Value;
            return Balance(node);
        }

        private static TreeNode<T> FindMaxNode(TreeNode<T> node)
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

        public IEnumerable<T> GetSortedValues(bool reverse=false)
        {
            return reverse ? ReverseOrderValues(_root): InOrderValues(_root);
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

        private static IEnumerable<T> InOrderValues(TreeNode<T> root)
        {
            if (root == null) yield break;

            foreach (var value in InOrderValues(root.Left))
            {
                yield return value;
            }

            yield return root.Value;

            foreach (var value in InOrderValues(root.Right))
            {
                yield return value;
            }
        }

        private static IEnumerable<T> ReverseOrderValues(TreeNode<T> root)
        {
            if (root == null) yield break;

            foreach (var value in ReverseOrderValues(root.Right))
            {
                yield return value;
            }

            yield return root.Value;

            foreach (var value in ReverseOrderValues(root.Left))
            {
                yield return value;
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