using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class PermutationsTests
    {
        [Fact]
        public void Basic()
        {
            var p = new Permutations();
            var result = p.Permute(new[] {1, 2, 3});

            var expected = new List<IList<int>>()
            {
                new List<int>() {1, 2, 3},
                new List<int>() {1, 3, 2},
                new List<int>() {2, 1, 3},
                new List<int>() {2, 3, 1},
                new List<int>() {3, 2, 1},
                new List<int>() {3, 1, 2},
            };

            Assert.Equal(expected, result);
        }
    }
}