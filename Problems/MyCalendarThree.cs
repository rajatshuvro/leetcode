using System.Linq;
using DataStructures;

namespace Problems
{
    public class MyCalendarThree
    {
        private readonly SegmentTree _segmentTree;
        public MyCalendarThree(int min=0, int max= 1_000_000_000)
        {
            _segmentTree = new SegmentTree(min, max);
        }

        public int Book(int start, int end)
        {
            return _segmentTree.AddValue(start, end - 1);
        }
    }
}