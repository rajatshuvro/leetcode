using Problems;
using Xunit;

namespace UnitTests
{
    public class LfuCacheTests
    {
        [Fact]
        public void Basic()
        {
            var cache = new LFUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.Equal(1,cache.Get(1));     

            cache.Put(3, 3);    // evicts key 2
            Assert.Equal(-1, cache.Get(2));       // returns -1 (not found)
            
            Assert.Equal(3, cache.Get(3));       // returns 3.
            cache.Put(4, 4);    // evicts key 1.
            Assert.Equal(-1, cache.Get(1));       // returns -1 (not found)
            Assert.Equal(3, cache.Get(3));       // returns 3
            Assert.Equal(4, cache.Get(4));       // returns 4
        }

        [Fact]
        public void UpdateElement()
        {
            var cache = new LFUCache(2);
            cache.Put(3, 1);
            cache.Put(2, 1);
            cache.Put(2, 2);
            cache.Put(4, 4);
            Assert.Equal(2, cache.Get(2));
        }
        [Fact]
        public void ShouldNotEvict()
        {
            var cache = new LFUCache(2);
            Assert.Equal(-1, cache.Get(2));
            cache.Put(2, 6);
            Assert.Equal(-1, cache.Get(1));
            cache.Put(1, 5);
            cache.Put(1, 2);
            Assert.Equal(2, cache.Get(1));
            Assert.Equal(6, cache.Get(2));
        }

        
    }
}