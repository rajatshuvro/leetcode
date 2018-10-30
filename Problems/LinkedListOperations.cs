using System;
using DataStructures;

namespace Problems
{
    public class LinkedListOperations
    {
        //https://leetcode.com/problems/add-two-numbers-ii/description/
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1.val == 0) return l2;
            if (l2.val == 0) return l1;

            var rev1 = LinkedList.GetReverseList(l1);
            var rev2 = LinkedList.GetReverseList(l2);

            var addList= new LinkedList();
            var overflow = 0;
            while (rev1 != null && rev2 != null)
            {
                var value = rev1.val + rev2.val+ overflow;
                overflow = value / 10;
                value %= 10;

                addList.AddBegin(new ListNode(value));

                rev1 = rev1.next;
                rev2 = rev2.next;
            }
            //only one of the following two loops will be executed
            while (rev2 != null)
            {
                var value = rev2.val + overflow;
                overflow = value / 10;
                value %= 10;

                addList.AddBegin(new ListNode(value));

                rev2 = rev2.next;
            }

            while (rev1 != null)
            {
                var value = rev1.val + overflow;
                overflow = value / 10;
                value %= 10;

                addList.AddBegin(new ListNode(value));

                rev1 = rev1.next;
            }

            if (overflow!=0) addList.AddBegin(new ListNode(overflow));

            return addList.First;
        }
    }
}