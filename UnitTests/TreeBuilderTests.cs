using Algorithms;
using Problems;
using Xunit;

namespace UnitTests
{
    public class TreeBuilderTests
    {
        [Theory]
        [InlineData(new[] {3, 9, 20, 15, 7}, new[] {9, 3, 15, 20, 7})]
        [InlineData(new[] { 1,2 },new[] { 1,2 })]
        [InlineData(new[] { 1, 2, 3, 4 }, new[] { 3, 1, 2,4 })]
        public void BuildFromInOrderAndPreOrder(int[] inOrder, int[] preOrder)
        {
            var tb = new BinTreeFromPreAndInOrder();

            var root = tb.BuildTree(preOrder, inOrder);
            var treeTraverser= new BinaryTreeTraversal<int>();

            Assert.Equal(preOrder, treeTraverser.PreOrderTraversal(root));
            Assert.Equal(inOrder, treeTraverser.InOrderTraversal(root));
        }
        
        [Theory]
        [InlineData(new [] {9,3,15,20,7}, new [] {9,15,7,20,3})]
        [InlineData(new[] {1,2},new[] {2,1 })]
        [InlineData(new[] {2,1},new[] {2,1 })]
        public void BuildFromInOrderAndPostOrder(int[] inOrder, int[] postOrder)
        {
            var tb = new BinTreeFromPostAndInOrder();

            var root = tb.BuildTree(inOrder, postOrder);
            var treeTraverser= new BinaryTreeTraversal<int>();
            
            Assert.Equal(inOrder, treeTraverser.InOrderTraversal(root));
            
        }

    }
}