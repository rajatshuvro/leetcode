using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class Interval:IComparable<Interval>
    {
        public int Start;
        public int End;

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }

        public bool Overlaps(Interval other)
        {
            return Start < other.End && other.Start < End;
        }

        public int CompareTo(Interval other)
        {
            return Start!=other.Start? Start.CompareTo(other.Start): End.CompareTo(other.End);
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
            Range = new Interval(value.Start, value.End);
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

            if (root.Range.Start > node.Range.Start) root.Range.Start = node.Range.Start;
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
    }
}