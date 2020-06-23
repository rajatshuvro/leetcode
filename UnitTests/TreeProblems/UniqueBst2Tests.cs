using Problems.Trees;
using Xunit;

namespace UnitTests.TreeProblems
{
    public class UniqueBst2Tests
    {
        [Fact]
        public void TwoNodes()
        {
            var bstGenerator = new UniqueBst2();
            var trees = bstGenerator.GenerateTrees(2);
            
            Assert.Equal(2, trees.Count);

            var root1 = trees[0];
            Assert.Equal(1, root1.val);
            Assert.Equal(2, root1.right.val);
            
            var root2 = trees[1];
            Assert.Equal(2, root2.val);
            Assert.Equal(1, root2.left.val);
        }
        
        [Fact]
        public void ThreeNodes()
        {
            var bstGenerator = new UniqueBst2();
            var trees = bstGenerator.GenerateTrees(3);
            
            Assert.Equal(5, trees.Count);
            
        }
    }
}