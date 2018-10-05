using System.Threading;

namespace DataStructures
{
    public class DoublyLinkedItem<T>
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

    public class DoublyLinkedList<T> 
    {
        private DoublyLinkedItem<T> _leftMostItem;
        private DoublyLinkedItem<T> _rightMostItem;
        public int Count { get; private set; }

        public void AddAtLeftEnd(DoublyLinkedItem<T> item)
        {
            Count++;
            if (_leftMostItem == null)
            {
                _leftMostItem = item;
                _rightMostItem = item;
                return;
            }

            item.Right = _leftMostItem;
            _leftMostItem = item;
        }

        public void AddAtRightEnd(DoublyLinkedItem<T> item)
        {
            Count++;
            if (_rightMostItem == null)
            {
                _leftMostItem = item;
                _rightMostItem = item;
                return;
            }

            item.Left = _rightMostItem;
            _rightMostItem = item;
        }

        public DoublyLinkedItem<T> RemoveFromLeftEnd()
        {
            if (_leftMostItem == null) return null;

            var item = _leftMostItem;
            _leftMostItem = _leftMostItem.Right;
            if (_leftMostItem == null) _rightMostItem = null;
            Count--;
            return item;
        }

        public DoublyLinkedItem<T> RemoveFromRightEnd()
        {
            if (_rightMostItem== null) return null;

            var item = _rightMostItem;
            _rightMostItem = _rightMostItem.Left;
            if (_rightMostItem == null) _leftMostItem = null;
            Count--;
            return item;
        }

        public void MoveRight(DoublyLinkedItem<T> item)
        {
            if (item.Right == null) return;

            var right = item.Right;
            var left = item.Left;
            item.Right = right.Right;
            item.Left = right;

            right.Right = item;
            right.Left = left;

            if (left!=null) left.Right = right;
            if (item.Right == null) _rightMostItem = item;
        }

        public void MoveLeft(DoublyLinkedItem<T> item)
        {
            if (item.Left == null) return;

            var right = item.Right;
            var left = item.Left;
            item.Right = left;
            item.Left = left.Left;

            left.Right = right;
            right.Left = item;

            if (right != null) right.Left = left;
            if (item.Left == null) _leftMostItem = item;
        }

    }
}