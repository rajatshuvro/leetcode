using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class ElasticArray<T>
    {
        private T[] _array;
        private int _i;

        public int Count => _i;
        public int Size => _array.Length;

        public ElasticArray(int size)
        {
            _array = new T[size];
            _i = 0;
        }

        private void Expand()
        {
            var items = new T[Size * 2];
            Array.Copy(_array, items, Count);

            _array = items;
        }
        
        public T this[int i]
        {
            get => _array[i];
            set => _array[i]=value;
        }

        public void Add(T x)
        {
            if (Count == Size) Expand();

            _array[_i] = x;
            _i++;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public int BinarySearch(T x)
        {
            return Array.BinarySearch(_array, 0, Count, x);
        }

        public void Sort()
        {
            Array.Sort(_array, 0, Count);
        }
    }
}