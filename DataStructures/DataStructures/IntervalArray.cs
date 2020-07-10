using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class IntervalArray<T> where T:IComparable<T>
    {
        private readonly List<Interval<T>> _intervals;
        
        public IntervalArray(List<Interval<T>> intervals)
        {
            intervals.Sort();
            _intervals = intervals;
        }

        public bool OverlapsAny(int start, int end)
        {
            var i = BinarySearch(start);
            if (i < 0) i = ~i;
            if (i >= _intervals.Count) return false;

            return _intervals[i].Overlaps(start, end);
        }

        // get all overlapping intervals in O(lg n + k) 
        public List<Interval<T>> GetOverlappingIntervals(int start, int end)
        {
            var i = BinarySearch(start);
            if (i < 0) i = ~i;
            if (i >= _intervals.Count) return null;
            
            var intervals = new List<Interval<T>>();

            for (int j = i; j < _intervals.Count; j++)
            {
                if (!_intervals[j].Overlaps(start, end)) break;
                intervals.Add(_intervals[j]);
            }
            
            return intervals.Count>0?intervals: null;
        }
        
        public List<Interval<T>> GetOverlappingIntervals(int x)
        {
            return GetOverlappingIntervals(x,x);
        }
        
        public int BinarySearch(int x)
        {
            var begin = 0;
            int end   = _intervals.Count - 1;

            while (begin <= end)
            {
                int index = begin + (end - begin >> 1);

                //We search on the end of intervals
                int ret = _intervals[index].End.CompareTo(x);
                if (ret == 0) return index;
                if (ret < 0) begin = index + 1;
                else end           = index - 1;
            }

            return ~begin;
        }
    }

}