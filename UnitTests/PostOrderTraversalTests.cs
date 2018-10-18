﻿using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class PostOrderTraversalTests
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
            var postOrderList = traverser.PostOrderTraversal(node1);

            Assert.Equal(new []{3,2,1}, postOrderList);
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
            var postOrderList = traverser.PostOrderTraversal(node2);

            Assert.Equal(new[] { 1, 3 , 2}, postOrderList);
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
            var postOrderList = traverser.PostOrderTraversal(node3);

            Assert.Equal(new[] { 1, 2, 3 }, postOrderList);
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
            var postOrderList = traverser.PostOrderTraversal(node1);

            Assert.Equal(new[] { 3,2,1 }, postOrderList);
        }

        [Fact]
        public void Failed_case()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);

            node1.left = node4;
            node1.right = node3;
            node4.left = node2;

            var traverser = new BinaryTreeTraversal();
            var postOrderList = traverser.PostOrderTraversal(node1);

            Assert.Equal(new[] { 2, 4, 3, 1}, postOrderList);
        }
    }
}