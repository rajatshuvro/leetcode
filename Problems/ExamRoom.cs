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


        private MaxHeap<SeatingInterval> _gaps;
        private BinarySearchTree<int> _occupiedSeats;
        private int _totalSeatCount;
        private int _studentCount;
        public ExamRoom(int N)
        {
            _totalSeatCount = N;
            _studentCount = 0;
            _gaps = new MaxHeap<SeatingInterval>(new SeatingInterval(int.MinValue, int.MaxValue));
            //_gaps.Add(new SeatingInterval(-1,N));
            _occupiedSeats = new BinarySearchTree<int>();
        }

        public int Seat()
        {
            if (_studentCount == 0)
            {
                _occupiedSeats.Add(0);
            }

            int seatNo = 0;
            var maxGap = _gaps.GetMax();
            var candidateSeats = new List<int>();

            return seatNo;
        }

        public void Leave(int p)
        {

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

                return length.CompareTo(otherLength);
            }
        }
    }
}