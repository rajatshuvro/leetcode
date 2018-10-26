using System;

namespace DataStructures
{
    public class SegmentTreeNode
    {
        public readonly int Start;
        public readonly int End;
        public int Booked;
        public int Saved;
        public SegmentTreeNode Left;
        public SegmentTreeNode Right;
        public SegmentTreeNode(int start, int end, int booked, int saved)
        {
            Start = start;
            End = end;
            Booked = booked;
            Saved = saved;
        }
    }
    public class SegmentTree
    {
        public SegmentTree()
        {
            _root= new SegmentTreeNode(0, 1_000_000_000, 0, 0);
        }

        private readonly SegmentTreeNode _root;

        public int AddValue(int start, int end)
        {
            AddValue(start, end, 1, _root);
            return _root.Saved;
        }

        private void AddValue(int start, int end, int val, SegmentTreeNode node)
        {
            //if the new interval is completely contains the root of this sub tree
            if (start <= node.Start && node.End <= end)
            {
                node.Booked += val;
                node.Saved += val;
                return;
            }
            int mid = (node.End + node.Start) / 2;
            if (start <= mid)
            {
                if (node.Left == null) node.Left = new SegmentTreeNode(node.Start, mid, 0, 0);
                AddValue(start, Math.Min(mid, end), val, node.Left);
            }
            if (end >= mid + 1)
            {
                if (node.Right == null) node.Right = new SegmentTreeNode(mid + 1, node.End, 0, 0);
                AddValue(Math.Max(mid + 1, start), end, val, node.Right);
            }
            node.Saved = Math.Max(node.Left?.Saved ?? 0,
                             node.Right?.Saved ?? 0) + node.Booked;
        }

        
    }
}