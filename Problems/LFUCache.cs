using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataStructures;

namespace Problems
{
    public class LfuItem:IComparable<LfuItem>
    {
        public readonly int Key;
        private int _value;
        private int _frequency;
        private int _accessTime;

        public LfuItem(int key, int value, int time)
        {
            Key = key;
            _value = value;
            _accessTime = time;
            _frequency = 1;
        }

        public int GetValue(int time)
        {
            _frequency++;
            _accessTime = time;
            return _value;
        }

        public int CompareTo(LfuItem other)
        {
            var comparison = _frequency.CompareTo(other._frequency);
            return comparison != 0 ? comparison : _accessTime.CompareTo(other._accessTime);
        }

        public void UpdateValue(int value, int time)
        {
            _value = value;
            _frequency++;
            _accessTime = time;
        }
    }

    public class LFUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LfuItem> _items;
        private readonly PriorityQueue<LfuItem> _priorityQueue;
        private int _time;
        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _time = 0;
            _items = new Dictionary<int, LfuItem>(capacity);
            _priorityQueue = new PriorityQueue<LfuItem>(new LfuItem(-1, -1, -1));
        }

        public int Get(int key)
        {
            if (_items.TryGetValue(key, out var item))
            {
                _time++;
                var val = item.GetValue(_time);
                _priorityQueue.UpdatePriority(item);
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
                _priorityQueue.UpdatePriority(item);
                return;
            }

            if (_capacity <= _items.Count)
            {
                var lfuItem = _priorityQueue.ExtractLast();
                _items.Remove(lfuItem.Key);
            }

            var newItem = new LfuItem(key, value, _time);

            _items.Add(key, newItem);
            _priorityQueue.AddAtEnd(newItem);

        }
    }
}