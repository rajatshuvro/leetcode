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
            var commonInterval = new Interval(start, end);
            var overlapCount = 0;
            foreach (var overlappingInterval in _tree.GetOverlappingIntervals(interval).OrderBy(x=>x.Start).ThenBy(x=>x.End))
            {
                commonInterval = Intersect(commonInterval, overlappingInterval);
                if (commonInterval == null)
                {
                    if (_maxOverlap < overlapCount + 1) _maxOverlap = overlapCount + 1;
                    overlapCount = 0;
                    commonInterval = overlappingInterval;
                }
                else overlapCount++;
            }

            _tree.Add(interval);

            if (_maxOverlap < overlapCount + 1) _maxOverlap = overlapCount + 1;
            return _maxOverlap;
        }

        private Interval Intersect(Interval interval, Interval overlappingInterval)
        {
            var start = interval.Start < overlappingInterval.Start ? overlappingInterval.Start : interval.Start;
            var end =  interval.End < overlappingInterval.End ? interval.End : overlappingInterval.End;

            if (start >= end) return null;
            else return new Interval(start, end);
        }
    }
}