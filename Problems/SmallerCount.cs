using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;

namespace Problems
{
    public class NumsAndSmaller
    {
        public readonly int X;
        public int Count;

        public NumsAndSmaller(int x, int count=0)
        {
            X = x;
            Count = count;
        }
    }

    public class SmallerCount
    {
        //https://leetcode.com/problems/count-of-smaller-numbers-after-self/
        private NumsAndSmaller[] _mergeArray;//temp array to be used for merge sorting
        public IList<int> CountSmaller(int[] nums)
        {
            var numItems = new NumsAndSmaller[nums.Length];
            for (var i=0; i < nums.Length;i++)
            {
                numItems[i]= new NumsAndSmaller(nums[i]);
            }
            _mergeArray = new NumsAndSmaller[nums.Length];
            var items = new NumsAndSmaller[nums.Length];
            for (var i=0; i < nums.Length;i++)
            {
                items[i] = numItems[i];
            }

            CountSmaller(items, 0, items.Length-1);
            return numItems.Select(x=>x.Count).ToArray();
        }

        private void CountSmaller(NumsAndSmaller[] items, int start, int end)
        {
            var n = end - start + 1;
            if (n <= 1) return;
            if (n == 2)
            {
                if (items[end].X < items[start].X)
                {
                    items[start].Count++;
                    ArrayUtils.Swap(items, start, end);
                }
                return;
            }
            
            //for more than 2 items, we need to do the merge sort style sorting while keeping track of smaller count
            var i = start;
            var mid = start + n / 2;
            var j = mid;
            // sort the two halves
            CountSmaller(items, start, mid - 1);
            CountSmaller(items, mid, end);
            
            var mergeIndex = start;
            var smallerOnRightCount = 0;
            while (i < mid && j <= end)
            {
                if (items[j].X < items[i].X)
                {
                    smallerOnRightCount++;
                    _mergeArray[mergeIndex++] = items[j++];
                }
                else
                {
                    items[i].Count += smallerOnRightCount;
                    _mergeArray[mergeIndex++] = items[i++];
                }
            }
            //merging the remaining items
            while (i< mid)
            {
                items[i].Count += smallerOnRightCount;
                _mergeArray[mergeIndex++] = items[i++];
            }

            while (j <= end)
            {
                _mergeArray[mergeIndex++] = items[j++];
            }
            
            Array.Copy(_mergeArray,start, items, start, n);
            
        }
    }
}