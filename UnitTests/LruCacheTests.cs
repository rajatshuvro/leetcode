using System;
using Problems;
using Xunit;

namespace UnitTests
{
    public class LruCacheTests
    {
        [Fact]
        public void Basic()
        {
            var cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Assert.Equal(1, cache.Get(1));

            cache.Put(3, 3);    // evicts key 2
            Assert.Equal(-1, cache.Get(2));       // returns -1 (not found)

            cache.Put(4, 4);    // evicts key 1.
            Assert.Equal(-1, cache.Get(1));       // returns -1 (not found)
            Assert.Equal(3, cache.Get(3));       // returns 3
            Assert.Equal(4, cache.Get(4));       // returns 4
        }

        [Fact]
        public void FailedCase13()
        {
            //input["LRUCache","put","put","put","put","put","get","put","get","get","put","get","put","put","put","get","put","get","get","get","get","put","put","get","get","get","put","put","get","put","get","put","get","get","get","put","put","put","get","put","get","get","put","put","get","put","put","put","put","get","put","put","get","put","put","get","put","put","put","put","put","get","put","put","get","put","get","get","get","put","get","get","put","put","put","put","get","put","put","put","put","get","get","get","put","put","put","get","put","put","put","get","put","put","put","get","get","get","put","put","put","put","get","put","put","put","put","put","put","put"]
            //[[10],[10,13],[3,17],[6,11],[10,5],[9,10],[13],[2,19],[2],[3],[5,25],[8],[9,22],[5,5],[1,30],[11],[9,12],[7],[5],[8],[9],[4,30],[9,3],[9],[10],[10],[6,14],[3,1],[3],[10,11],[8],[2,14],[1],[5],[4],[11,4],[12,24],[5,18],[13],[7,23],[8],[12],[3,27],[2,12],[5],[2,9],[13,4],[8,18],[1,7],[6],[9,29],[8,21],[5],[6,30],[1,12],[10],[4,15],[7,22],[11,26],[8,17],[9,29],[5],[3,4],[11,30],[12],[4,29],[3],[9],[6],[3,4],[1],[10],[3,29],[10,28],[1,20],[11,13],[3],[3,12],[3,8],[10,9],[3,26],[8],[7],[5],[13,17],[2,27],[11,15],[12],[9,19],[2,15],[3,16],[1],[12,17],[9,1],[6,19],[4],[5],[5],[8,1],[11,7],[5,2],[9,28],[1],[2,2],[7,4],[4,22],[7,24],[9,26],[13,28],[11,26]]
            //output[null,null,null,null,null,null,-1,null,19,17,null,-1,null,null,null,-1,null,-1,5,-1,12,null,null,3,5,5,null,null,1,null,-1,null,30,5,30,null,null,null,-1,null,-1,24,null,null,18,null,null,null,null,14,null,null,18,null,null,-1,null,null,null,null,null,18,null,null,24,null,4,-1,30,null,12,-1,null,null,null,null,29,null,null,null,null,17,22,-1,null,null,null,24,null,null,null,-1,null,null,null,-1,-1,-1,null,null,null,null,-1,null,null,null,null,null,null,null]
            //expected [null,null,null,null,null,null,-1,null,19,17,null,-1,null,null,null,-1,null,-1,5,-1,12,null,null,3,5,5,null,null,1,null,-1,null,30,5,30,null,null,null,-1,null,-1,24,null,null,18,null,null,null,null,-1,null,null,18,null,null,-1,null,null,null,null,null,18,null,null,-1,null,4,29,30,null,12,-1,null,null,null,null,29,null,null,null,null,17,22,18,null,null,null,-1,null,null,null,20,null,null,null,-1,18,18,null,null,null,null,20,null,null,null,null,null,null,null]
            var cache = new LRUCache(10);
            var commands = new string[] { "put", "put", "put", "put", "put", "get", "put", "get", "get", "put", "get", "put", "put", "put", "get", "put", "get", "get", "get", "get", "put", "put", "get", "get", "get", "put", "put", "get", "put", "get", "put", "get", "get", "get", "put", "put", "put", "get", "put", "get", "get", "put", "put", "get", "put", "put", "put", "put", "get", "put", "put", "get", "put", "put", "get", "put", "put", "put", "put", "put", "get", "put", "put", "get", "put", "get", "get", "get", "put", "get", "get", "put", "put", "put", "put", "get", "put", "put", "put", "put", "get", "get", "get", "put", "put", "put", "get", "put", "put", "put", "get", "put", "put", "put", "get", "get", "get", "put", "put", "put", "put", "get", "put", "put", "put", "put", "put", "put", "put" };
            var parameters = new int[,] {{10, 13},{3, 17},{6, 11},{10, 5},{9, 10},{13,0},{2, 19},{2,0},{3,0},{5, 25},{8,0},{9, 22},{5, 5},{1, 30},{11,0},{9, 12},{7, 0 },{5, 0 },{8, 0 },{9, 0 },{4, 30},{9, 3},{9, 0 },{10, 0 },{10, 0 },{6, 14},{3, 1},{3, 0 },{10, 11},{8, 0 },{2, 14},{1, 0 },{5, 0 },{4, 0 },{11, 4},{12, 24},{5, 18},{13, 0 },{7, 23},{8, 0 },{12, 0 },{3, 27},{2, 12},{5, 0 },{2, 9},{13, 4},{8, 18},{1, 7},{6, 0 },{9, 29},{8, 21},{5, 0 },{6, 30},{1, 12},{10, 0 },{4, 15},{7, 22},{11, 26},{8, 17},{9, 29},{5, 0 },{3, 4},{11, 30},{12, 0 },{4, 29},{3, 0 },{9, 0 },{6, 0 },{3, 4},{1, 0 },{10, 0 },{3, 29},{10, 28},{1, 20},{11, 13},{3, 0 },{3, 12},{3, 8},{10, 9},{3, 26},{8, 0 },{7, 0 },{5, 0 },{13, 17},{2, 27},{11, 15},{12, 0 },{9, 19},{2, 15},{3, 16},{1, 0 },{12, 17},{9, 1},{6, 19},{4, 0 },{5, 0 },{5, 0 },{8, 1},{11, 7},{5, 2},{9, 28},{1, 0 },{2, 2},{7, 4},{4, 22},{7, 24},{9, 26},{13, 28},{11, 26} };
            var expected = new int?[]
            {
                null, null, null, null, null, -1, null, 19, 17, null, -1, null, null, null, -1, null, -1, 5, -1,
                12, null, null, 3, 5, 5, null, null, 1, null, -1, null, 30, 5, 30, null, null, null, -1, null, -1, 24,
                null, null, 18, null, null, null, null, -1, null, null, 18, null, null, -1, null, null, null, null,
                null, 18, null, null, -1, null, 4, 29, 30, null, 12, -1, null, null, null, null, 29, null, null, null,
                null, 17, 22, 18, null, null, null, -1, null, null, null, 20, null, null, null, -1, 18, 18, null, null,
                null, null, 20, null, null, null, null, null, null, null
            };

            for (int i=0; i< commands.Length; i++)
            {
                var command = commands[i];
                switch (command)
                {
                    case "put":
                        cache.Put(parameters[i,0], parameters[i,1]);
                        break;
                    case "get":
                        Assert.Equal(expected[i], cache.Get(parameters[i,0]));
                        break;
                }
            }
        }
    }
}