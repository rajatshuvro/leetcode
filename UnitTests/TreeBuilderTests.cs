using Algorithms;
using Problems;
using Xunit;

namespace UnitTests
{
    public class TreeBuilderTests
    {
        [Fact]
        public void Basic()
        {
            var preOrder = new int[] { 3, 9, 20, 15, 7 };
            var inOrder = new int[] {9, 3, 15, 20, 7};

            var tb = new TreeBuilder();

            var root = tb.BuildTree(preOrder, inOrder);
            var treeTraverser= new BinaryTreeTraversal<int>();

            Assert.Equal(preOrder, treeTraverser.PreOrderTraversal(root));
            Assert.Equal(inOrder, treeTraverser.InOrderTraversal(root));
        }

        
    }
}