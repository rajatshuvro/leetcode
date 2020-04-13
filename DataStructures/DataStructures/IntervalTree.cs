using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Interval:IComparable<Interval>
    {
        public int start;
        public int end;

        public Interval() { start = 0; end = 0; }

        public Interval(int s, int e)
        {
            start = s;
            end = e;
        }

        public bool Overlaps(Interval other)
        {
            return start <= other.end && other.start <= end;
        }

        public int CompareTo(Interval other)
        {
            return start!=other.start? start.CompareTo(other.start): end.CompareTo(other.end);
        }
    }

    public class IntervalTreeNode:IComparable<IntervalTreeNode>
    {
        public readonly Interval Value;
        public Interval Range;
        public IntervalTreeNode Left;
        public IntervalTreeNode Right;

        public IntervalTreeNode (Interval value)
        {
            Value = value;
            Range = new Interval(value.start, value.end);
        }

        public int CompareTo(IntervalTreeNode other)
        {
            return Value.CompareTo(other.Value);
        }
    }

    public class IntervalTree
    {
        private IntervalTreeNode _root;

        private void Add(ref IntervalTreeNode root, IntervalTreeNode node)
        {
            if (root == null)
            {
                root = node;
                return;
            }

            if (root.Range.start > node.Range.start) root.Range.start = node.Range.start;
            if (root.Range.end < node.Range.end) root.Range.end = node.Range.end;

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
    }
}