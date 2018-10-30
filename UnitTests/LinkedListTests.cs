using DataStructures;
using Xunit;

namespace UnitTests
{
    public class LinkedListTests
    {
        [Fact]
        public void Add_test()
        {
            var list = new LinkedList();
            var node1= new ListNode(1);
            var node2 = new ListNode(2);
            var node3= new ListNode(3);

            list.Add(node1);
            list.Add(node2);
            list.Add(node3);

            Assert.Equal(new[]{node1.val, node2.val, node3.val}, LinkedList.GetNodeValues(list.First));

        }

        [Fact]
        public void Add_begin_test()
        {
            var list = new LinkedList();
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);

            list.AddBegin(node1);
            list.AddBegin(node2);
            list.AddBegin(node3);

            Assert.Equal(new[] { node3.val, node2.val, node1.val }, LinkedList.GetNodeValues(list.First));

        }

        [Fact]
        public void Reverse_test()
        {
            var list = new LinkedList();
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);

            list.Add(node1);
            list.Add(node2);
            list.Add(node3);

            var reverse = LinkedList.GetReverseList(list.First);

            Assert.Equal(new[] { node3.val, node2.val, node1.val }, LinkedList.GetNodeValues(reverse));

        }
    }
}