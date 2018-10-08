using DataStructures;
using Xunit;

namespace UnitTests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void BasicAddItems()
        {
            var priorityQueue = new PriorityQueue<int>(int.MinValue);

            priorityQueue.TryAdd(1);
            priorityQueue.TryAdd(2);

            Assert.Equal(2, priorityQueue.Count);
            Assert.Equal(2, priorityQueue.ExtractFirst());

            priorityQueue.TryAdd(3);
            Assert.Equal(1, priorityQueue.ExtractLast());

            priorityQueue.TryAdd(1);
            priorityQueue.TryAdd(4);
            priorityQueue.TryAdd(5);

            Assert.Equal(1, priorityQueue.ExtractLast());
            Assert.Equal(3, priorityQueue.ExtractLast());
            Assert.Equal(2, priorityQueue.Count);

        }

        [Fact]
        public void Add_sorted()
        {
            var priorityQueue = new PriorityQueue<int>(int.MinValue);
            
            priorityQueue.TryAdd(1);
            priorityQueue.TryAdd(2);
            priorityQueue.TryAdd(3);
            priorityQueue.TryAdd(4);
            priorityQueue.TryAdd(5);
            priorityQueue.TryAdd(6);

            Assert.Equal(6, priorityQueue.ExtractFirst());
            Assert.Equal(1, priorityQueue.ExtractLast());

        }

        [Fact]
        public void Add_random()
        {
            var dlist = new PriorityQueue<int>(int.MinValue);
            
            dlist.TryAdd(3);
            dlist.TryAdd(2);
            dlist.TryAdd(4);
            dlist.TryAdd(5);
            dlist.TryAdd(6);
            dlist.TryAdd(1);

            Assert.Equal(1, dlist.ExtractLast());
            Assert.Equal(2, dlist.ExtractLast());
            Assert.Equal(6, dlist.ExtractFirst());
            Assert.Equal(5, dlist.ExtractFirst());

        }

        [Fact]
        public void MoveToBegin()
        {
            var priorityQueue = new PriorityQueue<int>(int.MinValue);

            priorityQueue.TryAdd(1);
            priorityQueue.TryAdd(2);
            priorityQueue.TryAdd(3);
            priorityQueue.TryAdd(4);
            priorityQueue.TryAdd(5);
            priorityQueue.TryAdd(6);

            priorityQueue.Remove(4);
            Assert.Equal(5, priorityQueue.Count);
            priorityQueue.MoveToBegin(3);
            Assert.Equal(3, priorityQueue.ExtractFirst());
        }
    }
}