using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataStructures;

namespace Problems
{
    public class CacheItem:IComparable<CacheItem>
    {
        public readonly int Key;
        private int _value;
        private int _frequency;
        private int _accessTime;

        public CacheItem(int key, int value, int time)
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

        public int CompareTo(CacheItem other)
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
        private readonly Dictionary<int, CacheItem> _items;

        private int _time;
        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _time = 0;
            _items = new Dictionary<int, CacheItem>(capacity);
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

            _items.Add(key, new CacheItem(key, value, _time));

        }
    }
}