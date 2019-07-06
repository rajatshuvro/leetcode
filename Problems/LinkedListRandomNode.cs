using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class LinkedListRandomNode
    {
        /** @param head The linked list's head.
        Note that the head is guaranteed to be not null, so it contains at least one node. */
        private readonly ListNode _head;
        private ListNode _current;
        private readonly Random _random;
        private readonly List<int> _reservoir;
        private const int ReservoirCapacity = 20;
        private int _linkedListIndex;
        public LinkedListRandomNode(ListNode head)
        {
            _head    = head;
            _current = head;
            _reservoir = InitializeReservoir();
            _random  = new Random();
        }

        private List<int> InitializeReservoir()
        {
            var reservoir = new List<int>();
            _linkedListIndex = 0; 
            while (_current != null && _linkedListIndex < ReservoirCapacity)
            {
                reservoir.Add(_current.val);
                _current = _current.next;
                _linkedListIndex++;
            }

            return reservoir;
        }

        private int GetRandomFromReservoir()
        {
            var i = _random.Next(0, _reservoir.Count);
            return _reservoir[i];
        }

        /** Returns a random node's value. */
        public int GetRandom()
        {
            if (_reservoir.Count < ReservoirCapacity) return GetRandomFromReservoir();

            if (_current == null) _current = _head;

            //reservoir did not fill up
            TryAddToReservoir(_current.val);
            _current = _current.next;

            return GetRandomFromReservoir();
        }

        private void TryAddToReservoir(int value)
        {
            if (_reservoir.Count < ReservoirCapacity)
            {
                _reservoir.Add(value);
                return;
            }

            //reservoir full, we need to replace an item
            var i = _random.Next(0, _reservoir.Count);
            _linkedListIndex++;
            if (_random.NextDouble() < 1.0 / _linkedListIndex) _reservoir[i] = value;
        }
    }
}