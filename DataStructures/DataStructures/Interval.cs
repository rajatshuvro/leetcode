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

    public class Interval<T>:Interval
    {
        public readonly T Value;

        public Interval(int begin, int end, T v):base(begin,end)
        {
            Value = v;
        }

    }
}