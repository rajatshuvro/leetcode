using System;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class HeapTests
    {
        [Fact]
        public void BasicMinHeapTests()
        {
            var minHeap = new MinHeap<int>(int.MinValue);

            minHeap.Add(4);
            minHeap.Add(3);
            minHeap.Add(5);

            Assert.Equal(3, minHeap.GetMin());

            minHeap.Add(2);
            Assert.Equal(2, minHeap.ExtractMin());
            minHeap.Add(1);

            Assert.Equal(1, minHeap.ExtractMin());

        }

        [Fact]
        public void BasicMaxHeapTest()
        {
            var maxHeap = new MaxHeap<int>(int.MaxValue);

            maxHeap.Add(4);
            maxHeap.Add(3);
            maxHeap.Add(5);

            Assert.Equal(5, maxHeap.GetMax());
            
            maxHeap.Add(2);
            Assert.Equal(5, maxHeap.ExtractMax());
            
            maxHeap.Add(1);
            Assert.Equal(4, maxHeap.ExtractMax());
            
        }
    }
        
}