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
        private Random _random;
        public Skiplist() {
            _lists = new List<GridList<int>>()
            {
                new GridList<int>()
            };
            _random = new Random();
            new List<double>(){1.0};
            
        }
    
        public bool Search(int target)
        {
            GridNode<int> start=null;
            for (int i = 0; i < _lists.Count; i++)
            {
                if (_lists[i].TrySearch(target, out var previous, start)) return true;
                if (previous?.Down == null) return false;
                start = previous.Down;
            }
            return false;
        }
        
        public bool Erase(int num)
        {
            GridNode<int> start=null;
            var result = false;
            for (int i = 0; i < _lists.Count; i++)
            {
                //if the item can be deleted from list i, it should be deleted from i+1, ...
                result = _lists[i].TryErase(num, out var previous, start);
                start = previous?.Down;
            }
            // if a list has become too small, it needs to be deleted
            // given the expected size difference, each erase can have at most one list to delete
            for (int i = 0; i < _lists.Count-1; i++)
            {
                if (_lists[i].Count >= _lists[i + 1].Count)
                {
                    RemoveList(i);
                    break;
                }
            }
            return result;
        }

        private void RemoveList(int i)
        {
            if (i == 0)
            {
                _lists.RemoveAt(0);
                return;
            }

            foreach (var node in _lists[i-1].GetAllNodes())
            {
                var down = node.Down;
                node.Down = down.Down;
            }
            _lists.RemoveAt(i);
        }

        public void Add(int num)
        {
            TryAddTo(0, num, out var _);

        }

        private bool TryAddTo(int i, int num, out GridNode<int> downNode, GridNode<int> startNode=null)
        {
            if (i == _lists.Count - 1)
            {
                downNode = _lists[i].Add(num, startNode);
                return true;
            }

            downNode = null;
            //if num exists, return null
            if (_lists[i].TrySearch(num, out var previous, startNode))
            {
                return false;
            }

            if (TryAddTo(i + 1, num, out var down, previous.Down)) {
                return false; // the num was not inserted in the next level 
            }
            // given that the insertion at level i is conditioned on insertion on level i+1,
            // the insertion probability should be 1/ListSizeRatio
            var probability = 1.0 / ListSizeRatio;
            var rand = _random.NextDouble();
            
            //if a list is empty, a node needs to be added
            if (rand < probability || _lists[i].Count==0 )
            {
                downNode = _lists[i].Add(num, startNode, down);
                return true;
            }
            return false;// not added to level i, should not be added to any level 0...(i-1)
        }

    }
}