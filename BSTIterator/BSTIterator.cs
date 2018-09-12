using System.Collections.Generic;

namespace BSTIterator
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    //https://leetcode.com/problems/binary-search-tree-iterator/description/
    public class BSTIterator
    {
        private List<TreeNode> _ancestors= new List<TreeNode>();
        // node status can be
        // ---left-traversed (l) 
        // ---right-traversed (r) 
        private Dictionary<TreeNode, VisitStatus> _statuses = new Dictionary<TreeNode, VisitStatus>();
        private TreeNode _currentNode;
        public BSTIterator(TreeNode root)
        {
            _currentNode = root;
            _statuses[_currentNode] = VisitStatus.Unvisited;
        }

        private bool DiveLeft()
        {
            //if node has been visited, we cannot visit its left subtree again
            if (_statuses[_currentNode]==VisitStatus.LeftVisited 
                || _statuses[_currentNode] == VisitStatus.SelfVisited) return false;
            
            var movedLeft = false;
            _statuses[_currentNode] = VisitStatus.LeftVisited;
            while (_currentNode.left != null)
            {
                movedLeft = true;
                _ancestors.Add(_currentNode);
                _currentNode = _currentNode.left;
                _statuses[_currentNode] = VisitStatus.LeftVisited;
            }
            _statuses[_currentNode] = VisitStatus.SelfVisited;
            return movedLeft;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            if (!_movedToNext) MoveToNext();
            return _currentNode !=null;
        }

        private enum VisitStatus:byte
        {
            Unvisited,
            LeftVisited,
            SelfVisited,
            RightVisited
        }
        /** @return the next smallest number */
        public int Next()
        {
            if (_movedToNext)
                MoveToNext();

            _movedToNext = false;
            return _currentNode?.val ?? int.MinValue;
        }

        private bool _movedToNext = false;

        private void MoveToNext()
        {
            if (_movedToNext) return;
            _movedToNext = false;
            while (_currentNode != null)
            {
                _statuses.TryAdd(_currentNode, VisitStatus.Unvisited);

                switch (_statuses[_currentNode])
                {
                    case VisitStatus.Unvisited:
                        if(DiveLeft()) return;
                        else continue;
                    case VisitStatus.LeftVisited:
                        _statuses[_currentNode] = VisitStatus.SelfVisited;
                        return;
                    case VisitStatus.SelfVisited:
                        _statuses[_currentNode] = VisitStatus.RightVisited;
                        if (_currentNode.right == null) continue;

                        _ancestors.Add(_currentNode);
                        _currentNode = _currentNode.right;
                        DiveLeft();
                        return;

                    case VisitStatus.RightVisited:
                        if (_ancestors.Count <= 0)
                        {
                            _currentNode = null;
                        }
                        else
                        {
                            _currentNode = _ancestors[_ancestors.Count - 1];
                            _ancestors.RemoveAt(_ancestors.Count - 1);
                        }
                        break;

                }
                

            }

            
        }

    }
}