using System.Collections.Generic;

namespace DataStructures
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class LinkedList
    {
        private ListNode _last;
        public ListNode First { get; private set; }

        public void Add(ListNode node)
        {
            if (First == null)
            {
                First = node;
                _last = First;
                return;
            }

            _last.next = node;
            _last = node;
        }

        public void AddBegin(ListNode node)
        {
            if (First == null)
            {
                First = node;
                _last = First;
                return;
            }

            node.next = First;
            First = node;
        }

        public static List<int> GetNodeValues(ListNode node)
        {
            var values = new List<int>();
            while (node != null)
            {
                values.Add(node.val);
                node = node.next;
            }

            return values;
        }

        public static ListNode GetReverseList(ListNode node)
        {
            var revList = new LinkedList();

            foreach (var value in GetNodeValues(node))
            {
                revList.AddBegin(new ListNode(value));
                node = node.next;
            }

            return revList.First;
        }
    }
}
