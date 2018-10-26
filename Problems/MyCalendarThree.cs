using System.Linq;
using DataStructures;

namespace Problems
{
    public class MyCalendarThree
    {
        private readonly SegmentTree _segmentTree;
        public MyCalendarThree()
        {
            _segmentTree = new SegmentTree();
        }

        public int Book(int start, int end)
        {
            return _segmentTree.AddValue(start, end - 1);
        }
    }
}