using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class MaxHeap<T> where T : IComparable<T>, IEquatable<T>
    {
        private readonly List<T> _items;
        private readonly T _maxValue;
        public int Count => _items.Count;
        public MaxHeap(T maxValue)
        {
            _items = new List<T>();
            _maxValue = maxValue;
        }

        public void Add(T item)
        {
            _items.Add(item);
            HeapifyUp(Count-1);
        }

        
        public bool Remove(T x, int i=0)
        {
            if (i >= Count) return false;
            //if x is greater than the root, it doesn't exist in the heap
            int comparison = x.CompareTo(_items[i]);
            if ( comparison > 0) return false;

            if (x.Equals(_items[i]))
            {
                _items[i] = _maxValue;
                HeapifyUp(i);
                ExtractMax();
                return true;
            }

            return Remove(x, 2 * i+1) || Remove(x, 2 * i + 2);
        }

        private void HeapifyDown(int i)
        {
            for (; i < _items.Count / 2;)
            {
                var j = 2 * i + 1;

                if (j + 1 < _items.Count && _items[j].CompareTo(_items[j + 1]) < 0)
                    // both children are present
                    j++; //A[2*i+2] is the larger child

                if (_items[i].CompareTo(_items[j]) < 0)
                    SwapItems(_items, i, j);
                else break;
                i = j;
            }
        }

        private void HeapifyUp(int i)
        {
            while (i > 0 && i < Count)
            {
                var j = i % 2 == 0 ? i / 2 - 1 : i / 2;//the index of the parent
                if (j < 0) break;
                if (_items[i].CompareTo(_items[j]) > 0)
                    SwapItems(_items, i, j);
                else break;
                i = j;
            }
        }

        private static void SwapItems(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        public T ExtractMax()
        {
            var max = _items[0];

            // the last item form the array is brought to the root and pushed down to the appropriate position
            _items[0] = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);

            HeapifyDown(0);
            return max;
        }

        public T GetMax()
        {
            if (_items.Count == 0)
                return default(T);
            return _items[0];
        }

                
    }
}