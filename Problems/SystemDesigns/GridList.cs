using System;

namespace Problems.SystemDesigns
{
    public class GridNode<T> : IComparable<GridNode<T>> where T:IComparable<T>
    {
        public readonly T Value;
        public GridNode<T> Left;
        public GridNode<T> Right;
        public GridNode<T> Up;
        public GridNode<T> Down;

        public GridNode(T value)
        {
            Value = value;
        }

        public int CompareTo(GridNode<T> other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return -1;//all nodes are smaller than null
            return Value.CompareTo(other.Value);
        }
    }

    public class GridList<T> where T:IComparable<T>
    {
        public GridNode<T> Head;
        public GridNode<T> Tail;
        public int Count { get; private set; }
        public GridNode<T> Add(T value, GridNode<T> startNode = null, GridNode<T> downNode=null)
        {
            var node = new GridNode<T>(value);
            node.Down = downNode;

            Count++;
            if (Tail == null)
            {
                Tail = node;
                Head = Tail;
                return node;
            }
            //insert into the right place
            if (Head.CompareTo(node) >= 0)
            {
                node.Right = Head;
                Head = node;
                return node;
            }

            if (Tail.CompareTo(node) <= 0)
            {
                Tail.Right = node;
                Tail = node;
                return node;
            }

            var current = startNode ?? Head;
            while (current!=null)
            {
                var right = current.Right;
                if (node.CompareTo(right) <= 0)
                {
                    current.Right = node;
                    node.Right = right;
                    return node;
                }

                current = current.Right;
            }
            
            throw new IndexOutOfRangeException("Add should never reach this point");
        }

        public GridNode<T> Erase(T value, GridNode<T> startNode = null)
        {
            var current = startNode ?? Head;
            GridNode<T> previous=null;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    if (previous == null) Head = Head.Right;//deleting head
                    else previous.Right = current.Right;

                    if (current == Tail) Tail = previous; //deleting tail
                    Count--;
                    break;
                }

                if (current.Value.CompareTo(value) > 0) break;
                previous = current;
                current = current.Right;
            }

            return previous;
        }

        public GridNode<T> Get(int i, GridNode<T> startNode = null)
        {
            var current = startNode ?? Head;
            while (current != null && i>0)
            {
                current = current.Right;
                i--;
            }

            return current;
        }

        public bool TrySearch(T value, out GridNode<T> previous, GridNode<T> startNode = null)
        {
            var current = startNode ?? Head;
            previous = null;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    previous = current;
                    return true;
                }

                if (current.Value.CompareTo(value) > 0)
                {
                    return false;
                }

                previous = current;
                current = current.Right;
            }
            
            return false;
        }
    }
}