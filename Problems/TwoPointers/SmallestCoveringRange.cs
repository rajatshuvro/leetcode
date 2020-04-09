using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems.TwoPointers
{
    public class NumAndIndex:IComparable<NumAndIndex>
    {
        public readonly int Value;
        public readonly int ListId;
        public int Index;

        public NumAndIndex(int value, int listId, int index = -1)
        {
            Value = value;
            ListId = listId;
            Index = index;
        }

        public int CompareTo(NumAndIndex other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Value.CompareTo(other.Value);
        }
    }

    public class SmallestCoveringRange
    {
        //https://leetcode.com/problems/smallest-range-covering-elements-from-k-lists/
        public int[] SmallestRange(IList<IList<int>> lists)
        {
            var numWithIndexLists = GetNumWithIndexLists(lists);

            var minHeap = new MinHeap<NumAndIndex>(new NumAndIndex(int.MinValue, -1,-1));
            var heapMax = int.MinValue;
            //since the arrays are sorted, the values are added to the heap in increasing order
            // so, keeping track of the max (which is required for range can be easily kept track of
            for (var k = 0; k < numWithIndexLists.Count; k++)
            {
                var item = numWithIndexLists[k][0];
                var x = item.Value;
                if (x > heapMax) heapMax = x;
                minHeap.Add(item);
            }

            var rangeMin = minHeap.GetMin().Value;
            var rangeMax = heapMax;
            while (minHeap.Count >= lists.Count)
            {
                var min = minHeap.ExtractMin();
                if (rangeMax - rangeMin > heapMax - min.Value)
                {
                    rangeMin = min.Value;
                    rangeMax = heapMax;
                }

                //if the min came from list j, we need to take in the next value from list j
                var j = min.ListId;
                var i = min.Index+1;
                if (i < numWithIndexLists[j].Count)
                {
                    var item = numWithIndexLists[j][i];
                    if (item.Value > heapMax) heapMax = item.Value;
                    minHeap.Add(item);
                }
            }

            return new[] {rangeMin, rangeMax};
        }

        private static List<IList<NumAndIndex>> GetNumWithIndexLists(IList<IList<int>> lists)
        {
            var numWithIndexLists = new List<IList<NumAndIndex>>(lists.Count);
            for (var j = 0; j < lists.Count; j++)
            {
                numWithIndexLists.Add(new List<NumAndIndex>(lists[j].Count));
                var list = lists[j];
                for (var i = 0; i < list.Count; i++)
                    numWithIndexLists[j].Add(new NumAndIndex(list[i], j,i));
            }
            return numWithIndexLists;
        }
    }
}