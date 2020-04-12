using System.Collections.Generic;
using Problems;
using Problems.Graphs;
using Xunit;

namespace UnitTests
{
    public class AncestryTests
    {
        [Fact]
        public void RelationshipCheck()
        {
            var trios = new List<(uint, uint, uint)>()
            {
                (1, 2, 3),
                (3, 4, 6),
                (5, 4, 0),
                (15, 5, 0),
                (7, 9, 8),
                (8, 10, 0)
            };

            var ancesTree= new Ancestry(trios);

            Assert.True(ancesTree.HasCommonAncestry(1, 3));// parent
            Assert.True(ancesTree.HasCommonAncestry(1, 6));// grandparent
            Assert.True(ancesTree.HasCommonAncestry(1, 5)); // uncle
            Assert.True(ancesTree.HasCommonAncestry(1, 15)); // cousin
            Assert.False(ancesTree.HasCommonAncestry(1, 10)); // no relationship
        }
    }
}