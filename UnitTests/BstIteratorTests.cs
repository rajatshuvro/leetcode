using DataStructures;
using Problems.Trees;
using Xunit;

namespace UnitTests
{
    public class BstIteratorTests
    {
        [Fact]
        public void Test_1()
        {
            var iterator = new BstIterator(new TreeNode(1));

            Assert.True(iterator.HasNext());
            Assert.Equal(1, iterator.Next());
            Assert.False(iterator.HasNext());
            
        }

        [Fact]
        public void Test_2()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node2.left = node1;
            node2.right = node3;

            var iterator = new BstIterator(node2);

            Assert.True(iterator.HasNext());
            Assert.Equal(1, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(2, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(3, iterator.Next());
            Assert.False(iterator.HasNext());

        }

        [Fact]
        public void Test_3()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node3.left = node2;
            node2.left = node1;

            var iterator = new BstIterator(node3);

            Assert.True(iterator.HasNext());
            Assert.Equal(1, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(2, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(3, iterator.Next());
            Assert.False(iterator.HasNext());

        }

        [Fact]
        public void Test_4()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node1.right = node2;
            node2.right = node3;

            var iterator = new BstIterator(node1);

            Assert.True(iterator.HasNext());
            Assert.Equal(1, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(2, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(3, iterator.Next());
            Assert.False(iterator.HasNext());

        }

        [Fact]
        public void Test_5()
        {
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            node3.left = node1;
            node1.right = node2;

            var iterator = new BstIterator(node3);

            Assert.True(iterator.HasNext());
            Assert.Equal(1, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(2, iterator.Next());
            Assert.True(iterator.HasNext());
            Assert.Equal(3, iterator.Next());
            Assert.False(iterator.HasNext());

        }
    }
}