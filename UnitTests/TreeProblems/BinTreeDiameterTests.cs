using DataStructures;
using Problems.Trees;
using UnitTests.Utilities;
using Xunit;

namespace UnitTests.TreeProblems
{
    public class BinTreeDiameterTests
    {
        [Theory]
        [InlineData("[1,2,3,4,5]", 3)]
        [InlineData("[1,2,4,3,null,5,6,null,null,null,null,7]", 5)]
        [InlineData("[]", 0)]
        //[0,0,0,0,null,null,0,null,null,null,0]
        [InlineData("[0,0,0,0,null,null,0,null,null,null,0]", 5)]
        public void DiameterTests(string s, int diameter)
        {
            var root = TreeBuilder.Build(s);

            var bTreeDiameter = new DiameterOfBTree();
            Assert.Equal(diameter, bTreeDiameter.DiameterOfBinaryTree(root));
        }

        [Fact]
        public void Case2()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);

            node1.left = node2;
            node2.left = node3;
            node3.left = node4;
            node4.left = node5;
            node5.right = node6;
            node6.left = node7;

            var bTreeDiameter = new DiameterOfBTree();
            Assert.Equal(6, bTreeDiameter.DiameterOfBinaryTree(node1));
        }
        
        [Fact]
        public void Case3()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);
            
            node1.right = node2;
            node2.left = node3;
            node2.right = node6;
            node3.left = node4;
            node4.left = node5;
            node6.left = node7;

            var bTreeDiameter = new DiameterOfBTree();
            Assert.Equal(5, bTreeDiameter.DiameterOfBinaryTree(node1));
        }
    }
}