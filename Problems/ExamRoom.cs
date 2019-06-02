using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class ExamRoom
    {
        //https://leetcode.com/problems/exam-room/
        //In an exam room, there are N seats in a single row, numbered 0, 1, 2, ..., N-1.
        //When a student enters the room, they must sit in the seat that maximizes the distance to the closest person.If there are multiple such seats, they sit in the seat with the lowest number.  (Also, if no one is in the room, then the student sits at seat number 0.)
        //Return a class ExamRoom(int N) that exposes two functions: ExamRoom.seat() returning an int representing what seat the student sat in, and ExamRoom.leave(int p) representing that the student in seat number p now leaves the room.It is guaranteed that any calls to ExamRoom.leave(p) have a student sitting in seat p.


        private readonly MaxHeap<SeatingInterval> _gaps;
        private readonly BinarySearchTree<int> _occupiedSeats;
        private readonly int _totalSeatCount;
        private int _studentCount;
        public ExamRoom(int N)
        {
            _totalSeatCount = N;
            _studentCount = 0;
            _gaps = new MaxHeap<SeatingInterval>(new SeatingInterval(int.MinValue, int.MaxValue));
            _gaps.Add(new SeatingInterval(-1,N));
            _occupiedSeats = new BinarySearchTree<int>();
        }

        public int Seat()
        {
            if (_studentCount == _totalSeatCount) return -1;

            _studentCount++;
            var maxInterval = _gaps.ExtractMax();
            //if the interval has -1 or N, edge seats are available, we need to use those edge seats.
            if (maxInterval.Start == -1)
            {
                //first seat is available
                _gaps.Add(new SeatingInterval(0, maxInterval.End));
                _occupiedSeats.Add(0);
                return 0;
            }

            if (maxInterval.End == _totalSeatCount )
            {
                //last seat is available
                _gaps.Add(new SeatingInterval(maxInterval.Start, _totalSeatCount - 1));
                _occupiedSeats.Add(_totalSeatCount -1);
                return _totalSeatCount -1;
            }

            var seatNo = (maxInterval.End + maxInterval.Start) / 2;
            _gaps.Add(new SeatingInterval(maxInterval.Start, seatNo));
            _gaps.Add(new SeatingInterval(seatNo, maxInterval.End));
            _occupiedSeats.Add(seatNo);

            return seatNo;
        }

        public void Leave(int p)
        {
            if (_studentCount == 0) return;
            if (_occupiedSeats.Find(p) == null) return;
            _occupiedSeats.Remove(p);
            _studentCount--;

            var (predecessor, successor) = _occupiedSeats.GetPredecessorAndSuccessor(p);
            var leftOccupied = predecessor?.Value ?? -1;
            var rightOccupied = successor?.Value ?? _totalSeatCount;

            _gaps.Remove(new SeatingInterval(leftOccupied, p));
            //if (!_gaps.Remove(new SeatingInterval(leftOccupied, p)))
            //{
            //    throw new DataMisalignedException($"Missing interval in heap:{leftOccupied}-{p}");
            //}
            _gaps.Remove(new SeatingInterval(p, rightOccupied));
            //if (!_gaps.Remove(new SeatingInterval(p, rightOccupied)))
            //{
            //    throw new DataMisalignedException($"Missing interval in heap:{p}-{rightOccupied}");
            //}
            _gaps.Add(new SeatingInterval(leftOccupied, rightOccupied));
            
        }

        private class SeatingInterval:IComparable<SeatingInterval>
        {
            public readonly int Start;
            public readonly int End;

            public SeatingInterval(int start, int end)
            {
                Start = start;
                End = end;
            }
            public int CompareTo(SeatingInterval other)
            {
                var length = End - Start + 1;
                var otherLength = other.End - other.Start + 1;
                if (length != otherLength)
                    return length.CompareTo(otherLength);

                return Start == other.Start && End == other.End? 0: -1;
            }

            
            
        }
    }
}