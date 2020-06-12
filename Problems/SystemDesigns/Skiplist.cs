using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Problems.SystemDesigns
{
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
            TryAddTo(0, num);
            if (_lists[0].Count > ListSizeRatio)
            {
                var head = _lists[0].Head;
                var list = new GridList<int>();
                list.Add(head.Value, null, head);
            
                // get the middle node from the next list too
                var midNode = _lists[0].Get(ListSizeRatio / 2);
                list.Add(midNode.Value, null, midNode);
                
                _lists.Insert(0, list);
                
            }

        }

        private bool TryAddTo(int i, int num, out GridNode<int> downNode, GridNode<int> startNode=null)
        {
            if (i == _lists.Count - 1)
            {
                var node = _lists[i].Add(num, startNode);
                return node;
            }

            //if num exists, return null
            if (_lists[i].TrySearch(num, out var previous, startNode)) return false;
            
            if (TryAddTo(i + 1, num, previous.Down)) return null; // the num was not inserted in the next level 
            
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