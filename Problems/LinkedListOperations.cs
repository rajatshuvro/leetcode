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

            var nums1 = LinkedList.GetNodeValues(l1);
            var nums2 = LinkedList.GetNodeValues(l2);

            nums1.Reverse();
            nums2.Reverse();

            var addList = new LinkedList();
            var overflow = 0;
            int i = 0, j=0;
            while (i < nums1.Count && j < nums2.Count)
            {
                var value = nums1[i++]+ nums2[j++] + overflow;
                overflow = value / 10;
                value %= 10;

                addList.AddBegin(new ListNode(value));
            }
            //only one of the following two loops will be executed
            while (i < nums1.Count )
            {
                var value = nums1[i++] + overflow;
                overflow = value / 10;
                value %= 10;

                addList.AddBegin(new ListNode(value));
            }

            while (j < nums2.Count)
            {
                var value = nums2[j++] + overflow;
                overflow = value / 10;
                value %= 10;

                addList.AddBegin(new ListNode(value));
            }

            if (overflow != 0) addList.AddBegin(new ListNode(overflow));

            return addList.First;
        }
    }
}