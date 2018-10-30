using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class LinkedListOpsTest
    {
        [Fact]
        public void Equal_length_list()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);
            var node6 = new ListNode(6);

            var list1 = new LinkedList();
            list1.Add(node1);
            list1.Add(node2);
            list1.Add(node3);

            var list2 = new LinkedList();
            list2.Add(node4);
            list2.Add(node5);
            list2.Add(node6);

            var addListNode = LinkedListOperations.AddTwoNumbers(list1.First, list2.First);

            Assert.Equal(new[]{5,7,9}, LinkedList.GetNodeValues(addListNode));
        }

        [Fact]
        public void Unequal_length_list()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);
            var node5 = new ListNode(5);

            var list1 = new LinkedList();
            list1.Add(node1);
            list1.Add(node2);
            list1.Add(node3);

            var list2 = new LinkedList();
            list2.Add(node4);
            list2.Add(node5);

            var addListNode = LinkedListOperations.AddTwoNumbers(list1.First, list2.First);

            Assert.Equal(new[] { 1, 6, 8 }, LinkedList.GetNodeValues(addListNode));
        }

        [Fact]
        public void Unequal_length_overflow()
        {
            var node1 = new ListNode(9);
            var node2 = new ListNode(9);
            var node3 = new ListNode(9);
            var node4 = new ListNode(9);
            var node5 = new ListNode(9);

            var list1 = new LinkedList();
            list1.Add(node1);
            list1.Add(node2);
            list1.Add(node3);

            var list2 = new LinkedList();
            list2.Add(node4);
            list2.Add(node5);

            var addListNode = LinkedListOperations.AddTwoNumbers(list1.First, list2.First);

            Assert.Equal(new[] { 1, 0, 9, 8 }, LinkedList.GetNodeValues(addListNode));
        }
    }
}