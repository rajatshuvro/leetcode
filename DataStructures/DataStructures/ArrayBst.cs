using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    //Binary search tree implementation using array instead of Treenodes with pointers
    // warning!! while benchmarking with 1M random ints, proved to be very slow because it needs frequent re-balancing 
    // to keep memory usage low. the regular BST is very fast. takes about 1 sec for 1 M adds.
    public class ArrayBst<T> where T:IComparable<T>
    {
        private T[] _items;
        private readonly T _nullValue;
        private const int RootIndex = 0;
        public ArrayBst(T nullValue, int size= 256) {
            _items = new T[size];
            _nullValue = nullValue;

            for (var i = 0; i < _items.Length; i++)
            {
                _items[i] = nullValue;
            }
        }

        // re-crate the tree
        public void ReBalance()
        {
            //Console.WriteLine("rebalancing");
            var items = GetSortedItems().ToArray();
            var newLength = GetCeilingPowerOfTwo(items.Length);

            if(_items.Length < newLength)
                _items = new T[newLength];

            for (var i = 0; i < _items.Length; i++)
            {
                _items[i] = _nullValue;
            }

            Build(items, 0, items.Length - 1, RootIndex);
        }

        private int GetCeilingPowerOfTwo(int length)
        {
            int i = 1;
            while(i < length)
            {
                i <<= 1;
            }

            return i * 2;
        }

        private void Build(T[] items, int low, int high, int rootIndex)
        {
            if (low > high) return;
            var mid = (low + high) / 2;
            _items[rootIndex] = items[mid];
            if (low == high) return;

            Build(items, low, mid - 1, LeftChildIndex(rootIndex));
            Build(items, mid + 1, high, RightChildIndex(rootIndex));
        }

        public void Add(T value)
        {
            var i = RootIndex;
            
            while (i < _items.Length && _items[i].CompareTo(_nullValue)!=0)
            {
                i = _items[i].CompareTo(value) > 0 ? LeftChildIndex(i) : RightChildIndex(i);
            }

            if (i < _items.Length) _items[i] = value;
            else
            {
                // extend the array if we have run out of space
                ReBalance();
                Add(value);
            }
        }

        public bool Find(T value)
        {
            var i = RootIndex;
            while (i < _items.Length && _items[i].CompareTo(_nullValue) != 0)
            {
                var compare = _items[i].CompareTo(value);
                if (compare == 0) return true;
                i = compare > 0 ? LeftChildIndex(i) : RightChildIndex(i);
            }

            return false;
        }

        public void Remove(T value)
        {
            var rootIndex = RootIndex;
            while (true)
            {
                var i = GetIndex(value, rootIndex);

                if (i == -1) return;
                var hasLeftChild = LeftChildExist(i);
                var hasRightChild = RightChildExist(i);

                if (!hasRightChild && !hasLeftChild)
                {
                    //this is a leaf
                    _items[i] = _nullValue;
                    return;
                }

                if (!hasLeftChild)
                {
                    //get the right child value
                    var rightChildIndex = RightChildIndex(i);
                    var rightChild = _items[rightChildIndex];
                    // replace item by its right child
                    _items[i] = rightChild;
                    //remove right child from right sub-tree
                    value = rightChild;
                    rootIndex = rightChildIndex;
                }
                else
                {
                    var leftChildIndex = LeftChildIndex(i);
                    var leftChild = _items[leftChildIndex];
                    _items[i] = leftChild;
                    value = leftChild;
                    rootIndex = leftChildIndex;
                }
            }
        }

        private int GetIndex(T value, int rootIndex)
        {
            var i = rootIndex;
            var itemIndex = -1;
            while (i < _items.Length && _items[i].CompareTo(_nullValue) != 0)
            {
                var compare = _items[i].CompareTo(value);
                if (compare == 0)
                {
                    itemIndex = i;
                    break;
                }

                i = compare > 0 ? LeftChildIndex(i) : RightChildIndex(i);
            }

            return itemIndex;
        }

        private IEnumerable<T> GetSortedItems(int rootIndex)
        {
            var i = rootIndex;
            if (IsNull(i)) yield break;

            foreach (var item in GetSortedItems(LeftChildIndex(i)))
            {
                yield return item;
            }

            yield return _items[i];
            foreach (var item in GetSortedItems(RightChildIndex(i)))
            {
                yield return item;
            }

        }
        public IEnumerable<T> GetSortedItems()
        {
            return GetSortedItems(RootIndex);
        }

        private bool IsNull(int i)
        {
            return i >= _items.Length || _items[i].CompareTo(_nullValue) == 0;
        }

        private bool LeftChildExist(int i)
        {
            var childIndex = LeftChildIndex(i);
            return childIndex < _items.Length && _nullValue.CompareTo(_items[childIndex]) != 0;
        }

        private bool RightChildExist(int i)
        {
            var childIndex = RightChildIndex(i);
            return childIndex < _items.Length && _nullValue.CompareTo(_items[childIndex]) != 0;
        }
        private bool IsLeaf(int i)
        {
            return !LeftChildExist(i) && !RightChildExist(i);
        }
        
        private static int LeftChildIndex(int i) => 2 * i + 1;

        private static int RightChildIndex(int i) => 2 * i + 2;
    }
}