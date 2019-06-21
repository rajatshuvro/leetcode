using DataStructures;
using Xunit;

namespace UnitTests
{
    public class BitMapTests
    {
        [Fact]
        public void AddItems()
        {
            var bitMap = new BitMap();

            Assert.True(bitMap.Set(0));
            Assert.True(bitMap.Set(4));
            Assert.False(bitMap.Set(65));

            Assert.True(bitMap.IsSet(0));
            Assert.True(bitMap.IsSet(4));
            Assert.False(bitMap.IsSet(3));

            bitMap.Clear(4);
            Assert.False(bitMap.IsSet(4));
        }

        [Fact]
        public void CountTest()
        {
            var bitMap = new BitMap();

            Assert.True(bitMap.Set(0));
            Assert.True(bitMap.Set(0));
            Assert.Equal(1, bitMap.Count);
            Assert.True(bitMap.Set(4));
            Assert.False(bitMap.Set(65));
            Assert.Equal(2, bitMap.Count);

            bitMap.Clear(4);
            Assert.False(bitMap.IsSet(4));
            bitMap.Clear(4);
            Assert.Equal(1, bitMap.Count);
            bitMap.Clear(0);
            Assert.Equal(0, bitMap.Count);
        }
    }
}