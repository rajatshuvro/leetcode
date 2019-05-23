using DataStructures;
using Xunit;

namespace UnitTests
{
    public sealed class BinaryTreeTests
    {
        [Fact]
        public void BST_find()
        {
            var bst = new BinarySearchTree<int>();

            bst.Add(25);
            bst.Add(15);
            bst.Add(40);
            bst.Add(10);
            bst.Add(18);
            bst.Add(5);
            bst.Add(19);
            bst.Add(20);
            bst.Add(40);
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            Assert.NotNull(bst.Find(10));
            Assert.Null(bst.Find(9));
            Assert.Null(bst.Find(33));
            Assert.NotNull(bst.Find(49));
        }

        [Theory]
        [InlineData(25, 20, 35)]
        [InlineData(10, 5, 15)]
        [InlineData(19, 18, 20)]
        [InlineData(40, 35, 44)]
        [InlineData(45, 44, 49)]
        public void BST_find_predecessor_successor(int val, int pred, int succ)
        {
            var bst = new BinarySearchTree<int>();

            bst.Add(25);
            bst.Add(15);
            bst.Add(40);
            bst.Add(10);
            bst.Add(18);
            bst.Add(5);
            bst.Add(19);
            bst.Add(20);
            bst.Add(40);
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            var (predNode, succNode) = bst.GetPredecessorAndSuccessor(val);
            Assert.Equal(pred, predNode.Value);
            Assert.Equal(succ, succNode.Value);
        }

    }
}