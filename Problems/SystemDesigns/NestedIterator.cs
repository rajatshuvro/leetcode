using System.Collections.Generic;

namespace Problems.SystemDesigns
{
    //https://leetcode.com/problems/flatten-nested-list-iterator/
    public class NestedInteger
    {
        private readonly bool _isInteger;

        private readonly int _value;

        private readonly IList<NestedInteger> _nestedList;

        public NestedInteger(int value, IList<NestedInteger> nestedList)
        {
            _isInteger = nestedList == null;
            _value = value;
            _nestedList = nestedList;
        }

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        public bool IsInteger()=>_isInteger;

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        public int GetInteger()=> _value;

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        public IList<NestedInteger> GetList()=> _isInteger? null : _nestedList;
    }

    public class NestedIterator
    {
        private IList<NestedInteger> _nestedList;
        private int _i,_j;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            _nestedList = nestedList;
            _i=0;//index of item
            _j = 0;// index within an item
        }

        public bool HasNext()
        {
            while (_i < _nestedList.Count)
            {
                if (_nestedList[_i].IsInteger()) return true;
                var list = _nestedList[_i].GetList();
                if (list.Count > _j)
                {
                    return true;
                }

                _i++;
                _j = 0;//since we moved to a new item
            }
            return false;
            
        }

        public int Next()
        {
            if (_nestedList[_i].IsInteger()) 
            {
                _nestedList[_i].GetInteger();
                _i++;
            }
            else
            {
                var list = _nestedList[_i].GetList();
                
            }

            return 0;
        }
    }

    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}