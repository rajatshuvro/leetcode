using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class IterativeInorderTests
    {
        [Fact]
        public void Basic()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);

            node1.right = node2;
            node2.left = node3;

            var traverser = new BinaryTreeTraversal();
            var inorderList = traverser.InorderTraversal(node1);

            Assert.Equal(new []{1,3,2}, inorderList);
        }

        [Fact]
        public void Balanced()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);

            node2.left = node1;
            node2.right = node3;

            var traverser = new BinaryTreeTraversal();
            var inorderList = traverser.InorderTraversal(node2);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }

        [Fact]
        public void Left_chain()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);

            node2.left = node1;
            node3.left = node2;

            var traverser = new BinaryTreeTraversal();
            var inorderList = traverser.InorderTraversal(node3);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }

        [Fact]
        public void Right_chain()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);

            node1.right = node2;
            node2.right = node3;

            var traverser = new BinaryTreeTraversal();
            var inorderList = traverser.InorderTraversal(node1);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }
    }
}