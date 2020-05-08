using System;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class BitMapTests
    {
        [Fact]
        public void AddItems()
        {
            var bitMap = new BitMap(64);

            bitMap.Set(0);
            bitMap.Set(4);
            Assert.Throws<IndexOutOfRangeException>(()=> bitMap.Set(65));
            

            Assert.True(bitMap.IsSet(0));
            Assert.True(bitMap.IsSet(4));
            Assert.False(bitMap.IsSet(3));

            bitMap.Reset(4);
            Assert.False(bitMap.IsSet(4));
        }

        [Fact]
        public void CountTest()
        {
            var bitMap = new BitMap(64);

            bitMap.Set(0);
            bitMap.Set(0);
            Assert.Equal(1, bitMap.Count);
            bitMap.Set(4);
            Assert.Throws<IndexOutOfRangeException>(()=> bitMap.Set(65));

            Assert.Equal(2, bitMap.Count);

            bitMap.Reset(4);
            Assert.False(bitMap.IsSet(4));
            bitMap.Reset(4);
            Assert.Equal(1, bitMap.Count);
            bitMap.Reset(0);
            Assert.Equal(0, bitMap.Count);
        }
    }
}