using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class DoublyLinkedItem<T> where T:IComparable<T>
    {
        public T Value;
        public DoublyLinkedItem<T> Left;
        public DoublyLinkedItem<T> Right;

        public DoublyLinkedItem(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    public class PriorityQueue<T> where T:IComparable<T>
    {
        private readonly Dictionary<T, DoublyLinkedItem<T>> _items= new Dictionary<T, DoublyLinkedItem<T>>();
        public DoublyLinkedItem<T> FirstItem { get; private set; }
        public DoublyLinkedItem<T> LastItem { get; private set; }
        public int Count { get; private set; }
        public readonly T NullValue;
        public PriorityQueue (T nullValue)
        {
            NullValue = nullValue;
        }

        public bool TryAdd(T x)
        {
            if (_items.ContainsKey(x)) return false;

            var item = new DoublyLinkedItem<T>(x);
            _items.Add(x, item);
            if (FirstItem == null)
            {
                AddAtBegin(item);
                return true;
            }

            if (item.Value.CompareTo(FirstItem.Value) >= 0) AddAtBegin(item);
            else
            {
                AddAtEnd(item);
                Prioritize(item);
            }

            return true;
        }

        public bool Contains(T x)
        {
            return _items.ContainsKey(x);
        }

        private void AddAtBegin(DoublyLinkedItem<T> item)
        {

            Count++;
            if (FirstItem == null)
            {
                FirstItem = item;
                LastItem = item;
                return;
            }

            item.Right = FirstItem;
            FirstItem.Left = item;
            FirstItem = item;
        }

        private void AddAtEnd(DoublyLinkedItem<T> item)
        {
            Count++;
            if (LastItem == null)
            {
                FirstItem = item;
                LastItem = item;
                return;
            }

            item.Left = LastItem;
            LastItem.Right = item;
            LastItem = item;
        }

        public void Remove(T x)
        {
            if (!_items.TryGetValue(x, out var item)) return;
            Remove(item);
            _items.Remove(x);
        }

        public bool MoveToBegin(T x)
        {
            if (!_items.TryGetValue(x, out var item)) return false;
            Remove(item);
            AddAtBegin(item);
            return true;
        }

        public bool MoveToEnd(T x)
        {
            if (!_items.TryGetValue(x, out var item)) return false;
            Remove(item);
            AddAtEnd(item);
            return true;
        }


        private void Remove(DoublyLinkedItem<T> item)
        {
            if (item == FirstItem)
            {
                ExtractFirstItem();
                return;
            }

            if (item == LastItem)
            {
                ExtractLastItem();
                return;
            }

            Count--;
            var left = item.Left;
            var right = item.Right;

            left.Right = right;
            right.Left = left;
        }

        public T ExtractFirst()
        {
            if (Count == 0) return NullValue;
            var first = ExtractFirstItem().Value;
            _items.Remove(first);
            return first;
        }

        private DoublyLinkedItem<T> ExtractFirstItem()
        {
            if (FirstItem == null) return null;

            var item = FirstItem;
            FirstItem = FirstItem.Right;
            if (FirstItem == null) LastItem = null;
            else FirstItem.Left = null;

            Count--;
            return item;
        }

        public T ExtractLast()
        {
            if (Count == 0) return NullValue;
            var last = ExtractLastItem().Value;
            _items.Remove(last);
            return last;
        }

        private DoublyLinkedItem<T> ExtractLastItem()
        {
            if (LastItem== null) return null;

            var item = LastItem;
            LastItem = LastItem.Left;
            if (LastItem == null) FirstItem = null;
            else LastItem.Right = null;

            Count--;
            return item;
        }

        public void UpdatePriority(T x)
        {
            if (!_items.TryGetValue(x, out var item)) return;
            Prioritize(item);
        }

        private void Prioritize(DoublyLinkedItem<T> item)
        {
            while (item.Right != null && item.Value.CompareTo(item.Right.Value) < 0)
            {
                StepDown(item);
            }

            while (item.Left != null && item.Value.CompareTo(item.Left.Value) > 0)
            {
                StepUp(item);
            }
        }

        private void StepDown(DoublyLinkedItem<T> item)
        {
            if (item.Right == null) return ;

            var right = item.Right;
            var left = item.Left;
            if (FirstItem == item) FirstItem = right;
            item.Right = right.Right;
            item.Left = right;
            if (item.Right != null) item.Right.Left = item;

            right.Right = item;
            right.Left = left;

            if (left!=null) left.Right = right;
            if (item.Right == null) LastItem = item;
        }

        private void StepUp(DoublyLinkedItem<T> item)
        {
            if (item.Left == null) return;

            var right = item.Right;
            var left = item.Left;
            if (LastItem == item) LastItem = left;
            item.Right = left;
            item.Left = left.Left;
            if (item.Left != null) item.Left.Right = item;

            left.Right = right;
            left.Left = item;

            if (right != null) right.Left = left;
            if (item.Left == null) FirstItem = item;
        }

    }
}