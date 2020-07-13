using System;
using System.Threading;

namespace DataStructures
{
    public class Interval:IComparable<Interval>
    {
        public int Begin;
        public int End;

        public Interval() { Begin = 0; End = 0; }

        public Interval(int begin, int end)
        {
            Begin = begin;
            End = end;
        }

        public bool Overlaps(Interval other)
        {
            return Begin <= other.End && other.Begin <= End;
        }

        public bool Overlaps(int s, int e)
        {
            return Begin <= e && s <= End;
        }
        public int CompareTo(Interval other)
        {
            return Begin!=other.Begin? Begin.CompareTo(other.Begin): End.CompareTo(other.End);
        }
    }

    public interface IIntervalSearch<out T>
    {
        T[] GetAllOverlappingValues(int begin, int end);
    }

    public struct Interval<T>
    {
        public readonly int Begin;
        public readonly int End;
        public readonly T Value;
        public int Max;

        public Interval(int begin, int end, T value)
        {
            Begin = begin;
            End   = end;
            Value = value;
            Max   = -1;
        }

        /// <summary>
        /// our compare function
        /// </summary>
        public int CompareMax(int position)
        {
            if (position < Max) return -1;
            return position > Max ? 1 : 0;
        }

        /// <summary>
        /// returns true if this interval overlaps with the specified interval
        /// </summary>
        public bool Overlaps(int intervalBegin, int intervalEnd)
        {
            return End >= intervalBegin && Begin <= intervalEnd;
        }
    }
}