using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class CombineTests
    {
        //https://leetcode.com/problems/combinations/description/

        [Fact]
        public void BasicTest()
        {
            var s = new Combinations();

            var results = s.Combine(4, 2);
            var expected = new List<IList<int>>()
            {
                new List<int>(){1,2},
                new List<int>(){1,3},
                new List<int>(){1,4},
                new List<int>(){2, 3},
                new List<int>(){2, 4},
                new List<int>(){3,4}
            };
            Assert.Equal(expected, results);
        }
    }
}