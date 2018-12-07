using System.Linq;
using Algorithms;
using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class InOrderTraversalTests
    {
        [Fact]
        public void Basic()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);

            node1.right = node2;
            node2.left = node3;

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderTraversal(node1);

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

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderTraversal(node2);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }

        [Fact]
        public void Balanced_iterator()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);

            var tree = new BinarySearchTree<int>();
            tree.Add(node2);
            tree.Add(node1);
            tree.Add(node3);
            var inorderList = tree.GetValuesInOrder().Select(x => x.Value).ToArray();

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

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderTraversal(node3);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }

        [Fact]
        public void LeftChain_iterator()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);

            var tree = new BinarySearchTree<int>();
            tree.Add(node3);
            tree.Add(node2);
            tree.Add(node1);
            var inorderList = tree.GetValuesInOrder().Select(x => x.Value).ToArray();

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

            var traverser = new BinaryTreeTraversal<int>();
            var inorderList = traverser.InOrderTraversal(node1);

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }

        [Fact]
        public void RightChain_iterator()
        {
            var node1 = new TreeNode<int>(1);
            var node2 = new TreeNode<int>(2);
            var node3 = new TreeNode<int>(3);

            var tree = new BinarySearchTree<int>();
            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);
            var inorderList = tree.GetValuesInOrder().Select(x=>x.Value).ToArray();

            Assert.Equal(new[] { 1, 2, 3 }, inorderList);
        }

    }
}