using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class NextGreaterNumber
    {
        public class ValueAndIndex
        {
            public readonly int Index;
            public readonly int Value;

            public ValueAndIndex(int i, int value)
            {
                Index = i;
                Value = value;
            }
        }

        public int[] NextLargerNodes(ListNode head)
        {
            var nextLarger = new List<int>(10000);
            // unassigned is an ascending list of items that haven't been assigned a larger node.
            var unassigned = new LinkedList<ValueAndIndex>();

            while (head != null)
            {
                nextLarger.Add(0);
                unassigned.AddFirst(new ValueAndIndex(nextLarger.Count-1, head.val));

                if (head.next != null && head.next.val > head.val)
                {
                    var risingValue = head.next.val;
                    
                    while (unassigned.Count > 0)
                    {
                        var value = unassigned.First.Value.Value;
                        var index = unassigned.First.Value.Index;

                        if (value >= risingValue) break;

                        nextLarger[index]=risingValue;
                        unassigned.RemoveFirst();
                    }
                    
                }

                head = head.next;
            }

            return nextLarger.ToArray();
        }
    }
}