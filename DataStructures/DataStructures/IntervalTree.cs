using System;
using System.Collections.Generic;

namespace DataStructures
{
    
    public class IntervalTreeNode:IComparable<IntervalTreeNode>
    {
        public readonly Interval Value;
        public Interval Range;
        public IntervalTreeNode Left;
        public IntervalTreeNode Right;

        public IntervalTreeNode (Interval value)
        {
            Value = value;
            Range = new Interval(value.Begin, value.End);
        }

        public int CompareTo(IntervalTreeNode other)
        {
            return Value.CompareTo(other.Value);
        }
    }

    public class IntervalTree
    {
        private IntervalTreeNode _root;

        /// <summary>
        /// Provided a sorted list of intervals, builds a tree with all those intervals.
        /// </summary>
        /// <param name="intervals">Sorted list of intervals</param>
        /// <returns></returns>
        public static IntervalTree Build(IList<Interval> intervals)
        {
            var tree = new IntervalTree();
            
            tree._root = Build(intervals, 0, intervals.Count - 1);

            return tree;
        }

        private static IntervalTreeNode Build(IList<Interval> intervals, int i, int j)
        {
            if (i > j) return null;

            var mid = (i + j) / 2;
            var root = new IntervalTreeNode(intervals[mid]);
            root.Left = Build(intervals, i, mid - 1);
            root.Right = Build(intervals, mid + 1, j);
            
            var rangeBegin = root.Left?.Range.Begin ?? root.Value.Begin;
            var rangeEnd = root.Right?.Range.End ?? root.Value.End;
            root.Range = new Interval(rangeBegin, rangeEnd);
            return root;
        }

        private void Add(ref IntervalTreeNode root, IntervalTreeNode node)
        {
            if (root == null)
            {
                root = node;
                return;
            }

            if (root.Range.Begin > node.Range.Begin) root.Range.Begin = node.Range.Begin;
            if (root.Range.End < node.Range.End) root.Range.End = node.Range.End;

            if (node.CompareTo(root) < 0) Add(ref root.Left, node);
            if (node.CompareTo(root) > 0) Add(ref root.Right, node);
        }

        public void Add(Interval interval)
        {
            Add(ref _root, new IntervalTreeNode(interval));
        }

        public Interval GetRange()
        {
            return _root?.Range;
        }

        private IEnumerable<Interval> GetOverlappingIntervals(IntervalTreeNode root, Interval interval)
        {
            if (root == null || ! root.Range.Overlaps(interval)) yield break;
            if (root.Value.Overlaps(interval)) yield return root.Value;

            foreach (var leftInterval in GetOverlappingIntervals(root.Left, interval))
            {
                yield return leftInterval;
            }
            foreach (var rightInterval in GetOverlappingIntervals(root.Right, interval))
            {
                yield return rightInterval;
            }
        }

        public IEnumerable<Interval> GetOverlappingIntervals(Interval interval)
        {
            return GetOverlappingIntervals(_root, interval);
        }
        
        private readonly Interval _query = new Interval();
        public IEnumerable<Interval> GetOverlappingIntervals(int begin, int end)
        {
            _query.Begin = begin;
            _query.End = end;
            return GetOverlappingIntervals(_query);
        }
    }
}