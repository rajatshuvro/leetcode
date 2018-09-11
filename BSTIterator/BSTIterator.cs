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
            if (_statuses[_currentNode]==VisitStatus.LeftVisited) return false;
            
            var movedLeft = false;
            _statuses[_currentNode] = VisitStatus.LeftVisited;
            while (_currentNode.left != null)
            {
                movedLeft = true;
                _statuses[_currentNode] = VisitStatus.LeftVisited;
                _ancestors.Add(_currentNode);
                _currentNode = _currentNode.left;
            }

            return movedLeft;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return !(_statuses[_currentNode] == VisitStatus.RightVisited && _ancestors.Count == 0);
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
            
            while (_currentNode != null)
            {
                if(DiveLeft()) break; //we were able to move left. So, the current node is the next one

                if (_statuses[_currentNode] != VisitStatus.SelfVisited) break;

                //try to move right once and then down left since the next element is the leftmost leaf of the right subtree
                
                if (_currentNode.right != null && _statuses[_currentNode] != VisitStatus.RightVisited)
                {
                    _ancestors.Add(_currentNode);
                    _currentNode = _currentNode.right;
                    DiveLeft();
                    _statuses[_currentNode] = VisitStatus.RightVisited;

                }
                else
                {
                    //move up the ancestry
                    _currentNode = _ancestors[_ancestors.Count - 1];
                    _ancestors.RemoveAt(_ancestors.Count-1);
                }

            }
            _statuses[_currentNode] = VisitStatus.SelfVisited;
            return _currentNode?.val ?? int.MinValue;
            
        }
       
    }
}