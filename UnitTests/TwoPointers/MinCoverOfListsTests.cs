using System.Collections.Generic;
using Problems.TwoPointers;
using Xunit;

namespace UnitTests.TwoPointers
{
    public class MinCoverOfListsTests
    {
        [Fact]
        public void Case0()
        {
            var lists = new List<IList<int>>()
            {
                new List<int>(){4,10,15,24,26},
                new List<int>(){0,9,12,20},
                new List<int>(){5,18,22,30}
                
            };
            
            var minCover = new MinCoverOfLists();
            Assert.Equal(new[]{20,24}, minCover.SmallestRange(lists));
            
            var rangeCover = new SmallestCoveringRange();
            Assert.Equal(new[]{20,24}, rangeCover.SmallestRange(lists));
        }
        
        [Fact]
        public void Case1()
        {
            var lists = new List<IList<int>>()
            {
                new List<int>(){1},
                new List<int>(){2},
                new List<int>(){3},
                new List<int>(){4},
                new List<int>(){5},
                new List<int>(){6},
                new List<int>(){7},

            };
            
            var minCover = new MinCoverOfLists();
            Assert.Equal(new[]{1,7}, minCover.SmallestRange(lists));
            
            var rangeCover = new SmallestCoveringRange();
            Assert.Equal(new[]{1, 7}, rangeCover.SmallestRange(lists));
        }
    }
}