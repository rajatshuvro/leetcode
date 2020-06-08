using System;
using System.Collections.Generic;
using System.Net.Sockets;

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

        public bool Erase(T value, GridNode<T> startNode = null)
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
                    return true;
                }

                if (current.Value.CompareTo(value) > 0) return false;
                previous = current;
                current = current.Right;
            }

            return false;
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

    public class Skiplist
    {
        //https://leetcode.com/problems/design-skiplist/
        private List<GridList<int>> _lists;
        private const int ListSizeRatio = 4;
        private List<double> _insertionProbabilities;
        private Random _random;
        public Skiplist() {
            _lists = new List<GridList<int>>()
            {
                new GridList<int>()
            };
            _random = new Random();
            _insertionProbabilities = new List<double>(){1.0};
            
            //creating a hard coded set of lists to work with finding.
            _lists[1].Add(10);
            _lists[1].Add(20);
            _lists[1].Add(30);
            _lists[1].Add(40);
            _lists[1].Add(50);
            _lists[1].Add(60);
            _lists[1].Add(70);
            _lists[1].Add(80);

            GridNode<int> node;
            _lists[1].TrySearch(10, out node);
            _lists[0].Add(10, null, node);
            
            _lists[1].TrySearch(40, out node);
            _lists[0].Add(40, null, node);
            
            _lists[1].TrySearch(70, out node);
            _lists[0].Add(70, null, node);


        }
    
        public bool Search(int target)
        {
            GridNode<int> previous=null, start=null;
            for (int i = 0; i < _lists.Count; i++)
            {
                if (_lists[i].TrySearch(target, out previous, start)) return true;
                //search in the next level
                if (previous == null || previous.Down==null) return false;
                start = previous.Down;
            }
            return false;
        }
    
        public void Add(int num)
        {
            if (Search(num)) return;// item already exists
            AddAt(0, num);

        }

        private GridNode<int> AddAt(int i, int num, GridNode<int> startNode=null)
        {
            if (i == _lists.Count - 1)
            {
                var node = _lists[i].Add(num);
                return node;
            }

            //if num exists, return null
            if (_lists[i].TrySearch(num, out var previous, startNode)) return null;
            
            var downNode = AddAt(i + 1, num, previous.Down);
            if (downNode == null) return null; // the num was not inserted in the next level 
            
            var probability = GetInsertionProbability(i);
            var rand = _random.NextDouble();
            if (rand < probability)
            {
                return _lists[i].Add(num, startNode, downNode);
            }

            return null;// not added to level i, should not be added to any level 0...(i-1)
        }

        private double GetInsertionProbability(int i)
        {
            var n = _lists.Count - i -1;
            if (n == 0) return 1.0;
            return 1.0/Math.Pow(ListSizeRatio, n);
        }

        public bool Erase(int num)
        {
            return false;
        }
    }
}