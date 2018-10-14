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

        [Fact]
        public void GotTimeout()
        {
            //["LFUCache","put","put","put","get","put","put","get","put","put","get","put","get","get","get","put","put","get","put","get"]
            //[[10],[7,28],[7,1],[8,15],[6],[10,27],[8,10],[8],[6,29],[1,9],[6],[10,7],[1],[2],[13],[8,30],[1,5],[1],[13,2],[12]]

            var cache = new LFUCache(10);
            var commands = new []
            {
                "put", "put", "put", "get", "put", "put", "get", "put", "put", "get", "put", "get", "get", "get", "put",
                "put", "get", "put", "get"
            };
            var parameters = new int[,]
            {
                {7, 28}, {7, 1}, {8, 15}, {6,-1}, {10, 27}, {8, 10}, {8,-1}, {6, 29}, {1, 9}, {6,-1}, {10, 7}, {1,-1}, {2,-1}, {13,-1},
                {8, 30}, {1, 5}, {1,-1}, {13, 2}, {12,-1}
            };

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                switch (command)
                {
                    case "put":
                        cache.Put(parameters[i, 0], parameters[i, 1]);
                        break;
                    case "get":
                        cache.Get(parameters[i, 0]);
                        break;
                }
            }

        }
    }
}