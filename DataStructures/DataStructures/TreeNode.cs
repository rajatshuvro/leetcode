using System;

namespace DataStructures
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class TreeNode<T> where T:IComparable<T>
    {
        public T Value;
        public byte Height;
        public TreeNode<T> Left;
        public TreeNode<T> Right;

        public TreeNode(T x)
        {
            Value = x;
            Height = 1;
        }
    }
}