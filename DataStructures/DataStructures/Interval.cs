using System;
using System.Threading;

namespace DataStructures
{
    public class Interval<T>:IComparable<Interval<T>>
    {
        public readonly int Start;
        public readonly int End;
        public readonly T Value;

        public Interval(int s, int e, T v)
        {
            Start = s;
            End = e;
            Value = v;
        }

        /// <summary>
        /// Compares by the End co-ordinate first. Then my start.
        /// this makes the interval overlap search easy for Interval array.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Interval<T> other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            return End != other.End ? End.CompareTo(other.End) : Start.CompareTo(other.Start);
        }
        
        public bool Overlaps(int start, int end)
        {
            return Start <= end && start <= End;
        }

    }
}