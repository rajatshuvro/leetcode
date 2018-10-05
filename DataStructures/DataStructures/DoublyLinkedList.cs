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
        public DoublyLinkedItem<T> LeftMostItem { get; private set; }
        public DoublyLinkedItem<T> RightMostItem { get; private set; }
        public int Count { get; private set; }

        public void AddAtLeftEnd(DoublyLinkedItem<T> item)
        {
            Count++;
            if (LeftMostItem == null)
            {
                LeftMostItem = item;
                RightMostItem = item;
                return;
            }

            item.Right = LeftMostItem;
            LeftMostItem.Left = item;
            LeftMostItem = item;
        }

        public void AddAtRightEnd(DoublyLinkedItem<T> item)
        {
            Count++;
            if (RightMostItem == null)
            {
                LeftMostItem = item;
                RightMostItem = item;
                return;
            }

            item.Left = RightMostItem;
            RightMostItem.Right = item;
            RightMostItem = item;
        }

        public DoublyLinkedItem<T> RemoveFromLeftEnd()
        {
            if (LeftMostItem == null) return null;

            var item = LeftMostItem;
            LeftMostItem = LeftMostItem.Right;
            if (LeftMostItem == null) RightMostItem = null;
            else LeftMostItem.Left = null;

            Count--;
            return item;
        }

        public DoublyLinkedItem<T> RemoveFromRightEnd()
        {
            if (RightMostItem== null) return null;

            var item = RightMostItem;
            RightMostItem = RightMostItem.Left;
            if (RightMostItem == null) LeftMostItem = null;
            else RightMostItem.Right = null;

            Count--;
            return item;
        }

        public void MoveRight(DoublyLinkedItem<T> item)
        {
            if (item.Right == null) return;

            var right = item.Right;
            var left = item.Left;
            if (LeftMostItem == item) LeftMostItem = right;
            item.Right = right.Right;
            item.Left = right;
            if (item.Right != null) item.Right.Left = item;

            right.Right = item;
            right.Left = left;

            if (left!=null) left.Right = right;
            if (item.Right == null) RightMostItem = item;
        }

        public void MoveLeft(DoublyLinkedItem<T> item)
        {
            if (item.Left == null) return;

            var right = item.Right;
            var left = item.Left;
            if (RightMostItem == item) RightMostItem = left;
            item.Right = left;
            item.Left = left.Left;
            if (item.Left != null) item.Left.Right = item;

            left.Right = right;
            left.Left = item;

            if (right != null) right.Left = left;
            if (item.Left == null) LeftMostItem = item;
        }

    }
}