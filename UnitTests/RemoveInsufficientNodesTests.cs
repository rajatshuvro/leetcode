using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class RemoveInsufficientNodesTests
    {
        [Fact]
        public void Case1()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            node1.left = node2;
            node1.right = node3;

            var node4 = new TreeNode(4);
            var node_9 = new TreeNode(-9);
            node2.left = node4;
            node2.right = node_9;

            var node_33 = new TreeNode(-33);
            var node7 = new TreeNode(7);
            node3.left = node_33;
            node3.right = node7;

            var node8 = new TreeNode(8);
            var node9 = new TreeNode(9);
            node4.left = node8;
            node4.right = node9;

            var node12 = new TreeNode(12);
            var node13 = new TreeNode(13);
            node_33.left = node12;
            node_33.right = node13;

            var nodeRemover = new RemoveInsufficientNodes();

            nodeRemover.SufficientSubset(node1, 1);

            Assert.Null(node2.right);
            Assert.NotNull(node2.left);
            Assert.Null(node3.left);
            Assert.NotNull(node3.right);

        }
    }
}