using System;
using System.Collections.Generic;

namespace DataStructures
{
    public sealed class MinHeap<T> where T : IComparable<T>
    {
        private readonly List<T> _items;
        public int Count => _items.Count;

        public MinHeap()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            _items.Add(item);
            HeapifyUp();
        }

        private void HeapifyUp()
        {
            var i = _items.Count - 1;
            while (i > 0)
            {
                var j = i % 2 == 0 ? i / 2 - 1 : i / 2;//the index of the parent
                if (_items[i].CompareTo(_items[j]) < 0)
                    SwapItems(_items, i, j);
                else break;
                i = j;
            }
        }

        private void HeapifyDown(int i)
        {
            for (; i < _items.Count / 2;)
            {
                var j = 2 * i + 1;

                if (j + 1 < _items.Count && _items[j].CompareTo(_items[j + 1]) > 0)
                    // both children are present
                    j++; //A[2*i+2] is the smaller child

                if (_items[i].CompareTo(_items[j]) > 0)
                    SwapItems(_items, i, j);
                else break;
                i = j;
            }
        }

        public T ExtractMin()
        {
            var min = _items[0];

            // the last item form the array is brought to the root and pushed down to the appropriate position
            _items[0] = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);

            HeapifyDown(0);
            return min;
        }

        public void Delete(T item)
        {
            int i= _items.Count-1;
            while (i >=0 && _items[i].Equals(item)) i--;

            SwapItems(_items, i, _items.Count - 1);
            _items.RemoveAt(_items.Count - 1);

            HeapifyDown(i);
        }
        private static void SwapItems(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public T GetMin()
        {
            if (_items.Count == 0)
                return default(T);
            return _items[0];
        }
        
    }
}