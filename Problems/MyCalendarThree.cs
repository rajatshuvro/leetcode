using System.Linq;
using DataStructures;

namespace Problems
{
    public class MyCalendarThree
    {
        private readonly IntervalTree _tree;
        private int _maxOverlap = 0;
        public MyCalendarThree()
        {
            _tree = new IntervalTree();
        }

        public int Book(int start, int end)
        {
            var interval = new Interval(start, end);

            var overlapCount = _tree.GetOverlappingIntervals(interval).Count();

            _tree.Add(interval);

            if (_maxOverlap < overlapCount + 1) _maxOverlap = overlapCount + 1;
            return _maxOverlap;
        }
    }
}