using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Algorithms;
using DataStructures;

namespace Problems.DynamicProgramming
{
    /*
     * Problem inspired by SA optimization in Nirvana
     * Given an ordered set of natural numbers A={a_i} where 1<= a_i <= uint.MaxValue, i <= int.MaxValue
     * and a set of intervals I={(s_i, e_i)}  where s_i = start of interval i, e_i = end of interval i,  i <= ushort.MaxValue
     * A set of costs (one for each interval) C = {c_i} where c_i = cost of interval i 
     * find a subset J of I that contains all values in A but minimizes Sum(c_i) where i \in J
     */
    
    public class IntervalCover<T>
    {
        private IntervalArray<T> _intervalArray;
        private List<int> _nums;
        private Dictionary<int, (List<Interval<T>> cover, int cost)> _subSolutions;
        private Dictionary<Interval<T>, (List<Interval<T>> cover, int cost)> _intervalCovers;

        private int _end;
        public (List<Interval<T>> set, int cost) GetOptimalCover(IList<int> nums, Interval<T>[] intervals)
        {
            _nums = nums.ToList();
            
            Array.Sort(intervals);
            _intervalArray = new IntervalArray<T>(intervals);
            _end = GetIntervalArrayEnd( _intervalArray);
            _subSolutions = new Dictionary<int, (List<Interval<T>> cover, int cost)>();
            _intervalCovers = new Dictionary<Interval<T>, (List<Interval<T>> cover, int cost)>();
            
            return GetOptimalCover(0);
        }
        
        public (List<Interval<T>> set, int cost) GetReverseCover(IList<int> nums, Interval<T>[] intervals)
        {
            _nums = nums.ToList();
            
            Array.Sort(intervals);
            _intervalArray = new IntervalArray<T>(intervals);
            _end = GetIntervalArrayEnd( _intervalArray);
            _intervalCovers = new Dictionary<Interval<T>, (List<Interval<T>> cover, int cost)>();
            
            return GetReverseCover();
        }

        private int GetIntervalArrayEnd(IntervalArray<T> intervalArray)
        {
            var lastInterval = intervalArray.Array[intervalArray.Array.Length - 1];
            var overlappers = intervalArray.GetAllOverlappingIntervals(lastInterval.End, lastInterval.End);
            return overlappers.Select(x => x.End).Max();
        }

        //Attempt to get optimal cover starting from the end of the array
        private (List<Interval<T>> set, int cost) GetReverseCover()
        {
            var firstOverlapping = _nums.Count;
            for (int i = _nums.Count-1; i >= 0; i--)
            {
                var x = _nums[i];
                if (x > _end) continue;
                var overlappers = _intervalArray.GetAllOverlappingIntervals(x, x);
                if(overlappers == null || overlappers.Length==0) continue;

                firstOverlapping = i;
                var maxBegin = int.MinValue;
                foreach (var overlapper in overlappers)
                {
                    if (overlapper.Begin > maxBegin) maxBegin = overlapper.Begin;
                    var cover = GetCover(overlapper);
                    _intervalCovers.TryAdd(overlapper, cover);
                }

                // retreat i to before the start of the last overlapping interval
                var j = _nums.BinarySearch(maxBegin);
                if (j < 0) j = ~j;
                if (j < i) i = j;
            }

            // find the first num that overlaps any interval and return the minimum cover for that position
            if (firstOverlapping >= _nums.Count) return (null, 0);

            var first = _nums[firstOverlapping];
            var firstOverlappers = _intervalArray.GetAllOverlappingIntervals(first, first);
            var minCost = int.MaxValue;
            List<Interval<T>> minCover = null;
            foreach (var overlapper in firstOverlappers)
            {
                if (minCost < _intervalCovers[overlapper].cost) continue;
                minCost = _intervalCovers[overlapper].cost;
                minCover = _intervalCovers[overlapper].cover;
            }
            
            return (minCover, minCost);
        }

        /// <summary>
        /// return optimal cover when it starts from the input interval
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        private (List<Interval<T>> set, int cost) GetCover(Interval<T> interval)
        {
            if (_intervalCovers.ContainsKey(interval)) return _intervalCovers[interval];
            
            // get the smallest position past the interval
            var index = _nums.BinarySearch(interval.End + 1);
            if (index < 0) index = ~index;
            if (index >= _nums.Count) {
                // no num past the end of 'interval'
                _intervalCovers.TryAdd(interval, (new List<Interval<T>>() {interval}, interval.Cost));
                return _intervalCovers[interval];
            }

            Interval<T>[] overlappers= null;
            // find a num that overlaps an interval past interval.End
            while ((overlappers == null || overlappers.Length == 0) && index < _nums.Count)
            {
                var x = _nums[index];
                overlappers = _intervalArray.GetAllOverlappingIntervals(x, x);
                index++;
            }
            if (index >= _nums.Count && overlappers==null)
            {
                // no overlapping num past the end of 'interval'
                _intervalCovers.TryAdd(interval, (new List<Interval<T>>() {interval}, interval.Cost));
                return _intervalCovers[interval];
            }
            
            var set = new List<Interval<T>>(){interval};
            var cost = interval.Cost;

            var minDownStreamCost = int.MaxValue;
            List<Interval<T>> minDownStreamCover = null;
            // pick the optimal downstream cover 
            foreach (var overlapper in overlappers)
            {
                if (!_intervalCovers.ContainsKey(overlapper)) GetCover(overlapper);

                    var cover = _intervalCovers[overlapper];
                if (minDownStreamCost > cover.cost)
                {
                    minDownStreamCost = cover.cost;
                    minDownStreamCover = cover.cover;
                }
            }

            if (minDownStreamCover != null)
            {
                cost += minDownStreamCost;
                set.AddRange(minDownStreamCover);
            }

            _intervalCovers.TryAdd(interval, (set, cost));
            return _intervalCovers[interval];
        }

        private (List<Interval<T>> set, int cost) GetOptimalCover(int i)
        {
            while (true)
            {
                if (i >= _nums.Count) return (null, 0);

                if (_subSolutions.ContainsKey(i)) return _subSolutions[i];

                var x = _nums[i];
                if (x > _end) return (null, 0);

                var overlappers = _intervalArray.GetAllOverlappingIntervals(x, x);
                if (overlappers == null || overlappers.Length == 0)
                {
                    //if a number is not present in any intervals, skip it
                    i++;
                    continue;
                }

                var minCost = int.MaxValue;
                var minCover = new List<Interval<T>>();
                foreach (var interval in overlappers)
                {
                    //find the first num not covered by interval
                    var index = _nums.BinarySearch(interval.End + 1);
                    if (index < 0) index = ~index;
                    var ( remainingCover, remainingCost) = GetOptimalCover(index);
                    var cost = interval.Cost + remainingCost;

                    if (cost >= minCost) continue;

                    minCover.Clear();
                    minCost = cost;
                    minCover.Add(interval);
                    if (remainingCover != null) minCover.AddRange(remainingCover);
                }

                _subSolutions.Add(i, (minCover, minCost));
                return (minCover, minCost);
                
            }
        }
    }
}