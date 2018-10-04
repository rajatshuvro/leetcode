using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class LruItem : IComparable<LruItem>
    {
        public readonly int Key;
        private int _value;
        private int _accessTime;

        public LruItem(int key, int value, int time)
        {
            Key = key;
            _value = value;
            _accessTime = time;
        }

        public int GetValue(int time)
        {
            _accessTime = time;
            return _value;
        }

        public int CompareTo(LruItem other)
        {
            return  _accessTime.CompareTo(other._accessTime);
        }

        public void UpdateValue(int value, int time)
        {
            _value = value;
            _accessTime = time;
        }
    }

    public class LRUCache
    {
        private readonly int _capacity;
        private readonly Dictionary<int, LruItem> _items;
        private int _time;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _time = 0;
            _items = new Dictionary<int, LruItem>(capacity);
        }

        public int Get(int key)
        {
            if (_items.TryGetValue(key, out var item))
            {
                _time++;
                return item.GetValue(_time);
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0) return;
            _time++;

            if (_items.ContainsKey(key))
            {
                _items[key].UpdateValue(value, _time);
                return;
            }

            if (_capacity <= _items.Count)
            {
                var item = _items.Values.Min();
                _items.Remove(item.Key);
            }

            _items.Add(key, new LruItem(key, value, _time));

        }
    }
}