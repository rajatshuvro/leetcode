using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class LruItem : IComparable<LruItem>
    {
        public readonly int Key;
        private int _value;
        public int AccessTime { get; private set; }

        public LruItem(int key, int value, int time)
        {
            Key = key;
            _value = value;
            AccessTime = time;
        }

        public int GetValue(int time)
        {
            AccessTime = time;
            return _value;
        }

        public int CompareTo(LruItem other)
        {
            return  AccessTime.CompareTo(other.AccessTime);
        }

        public void UpdateValue(int value, int time)
        {
            _value = value;
            AccessTime = time;
        }
    }

    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LruItem> _items;
        private readonly PriorityQueue<LruItem> _priorityQueue;
        private int _time;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _time = 0;
            _items =new Dictionary<int, LruItem>(capacity);
            _priorityQueue = new PriorityQueue<LruItem>(new LruItem(int.MinValue, int.MinValue, int.MinValue));
        }

        public int Get(int key)
        {
            if (_items.TryGetValue(key, out var item))
            {
                _time++;
                var val= item.GetValue(_time);
                _priorityQueue.MoveToBegin(item);
                return val;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0) return;
            _time++;

            if (_items.TryGetValue(key, out var item))
            {
                item.UpdateValue(value, _time);
                _priorityQueue.MoveToBegin(item);
                return;
            }

            if (_capacity <= _items.Count)
            {
                var lruItem = _priorityQueue.ExtractLast();
                _items.Remove(lruItem.Key);
            }

            var newItem = new LruItem(key, value, _time);

            _items.Add(key, newItem);
            _priorityQueue.TryAdd(newItem);

        }
    }
}