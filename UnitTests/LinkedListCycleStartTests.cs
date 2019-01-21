using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class LinkedListCycleStartTests
    {
        [Fact]
        public void No_cycle()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);

            node2.next = node3;
            node1.next = node2;

            var cycleStartFinder = new LinkedListCycleStart();
            Assert.Null(cycleStartFinder.DetectCycle(node1));
        }

        [Fact]
        public void Loop_from_head()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            
            node2.next = node1;
            node1.next = node2;

            var cycleStartFinder = new LinkedListCycleStart();
            Assert.Equal(node1, cycleStartFinder.DetectCycle(node1));
        }

        [Fact]
        public void Cycle_length_3()
        {
            var node1 = new ListNode(1);
            var node2 = new ListNode(2);
            var node3 = new ListNode(3);
            var node4 = new ListNode(4);

            node3.next = node4;
            node2.next = node3;
            node1.next = node2;

            node4.next = node2;

            var cycleStartFinder = new LinkedListCycleStart();
            Assert.Equal(node2, cycleStartFinder.DetectCycle(node1));
        }
    }
}