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
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            var (predNode, succNode) = bst.GetPredecessorAndSuccessor(val);
            Assert.Equal(pred, predNode.Value);
            Assert.Equal(succ, succNode.Value);
        }

        [Fact]
        public void Missing_predecessor_or_successor()
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
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            var (predNode, succNode) = bst.GetPredecessorAndSuccessor(5);
            Assert.Null(predNode);
            Assert.Equal(10, succNode.Value);

            (predNode, succNode) = bst.GetPredecessorAndSuccessor(49);
            Assert.Null(succNode);
            Assert.Equal(45, predNode.Value);
        }

        [Fact]
        public void Remove_Leaf()
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
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            bst.Remove(5);
            var (predNode, succNode) = bst.GetPredecessorAndSuccessor(10);
            Assert.Null(predNode);
            Assert.Equal(15, succNode.Value);

            bst.Remove(49);
            (predNode, succNode) = bst.GetPredecessorAndSuccessor(45);
            Assert.Null(succNode);
            Assert.Equal(44, predNode.Value);
        }

        [Fact]
        public void Remove_node_with_one_child()
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
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            bst.Remove(10);
            var (predNode, succNode) = bst.GetPredecessorAndSuccessor(15);
            Assert.Equal(5,predNode.Value);
            Assert.Equal(18, succNode.Value);
            
        }

        [Fact]
        public void Remove_node_with_two_child()
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
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            bst.Remove(40);
            var (predNode, succNode) = bst.GetPredecessorAndSuccessor(35);
            Assert.Equal(25, predNode.Value);
            Assert.Equal(44, succNode.Value);

        }

        [Fact]
        public void Remove_root()
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
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            bst.Remove(25);
            var (predNode, succNode) = bst.GetPredecessorAndSuccessor(20);
            Assert.Equal(19, predNode.Value);
            Assert.Equal(35, succNode.Value);

        }

        [Fact]
        public void Remove_random()
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
            bst.Add(35);
            bst.Add(45);
            bst.Add(44);
            bst.Add(49);

            bst.Remove(25);
            Assert.Null(bst.Find(25));
            bst.Remove(35);
            Assert.Null(bst.Find(35));
            bst.Remove(20);
            Assert.Null(bst.Find(20));

        }

    }
}