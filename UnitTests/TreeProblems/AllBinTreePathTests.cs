using DataStructures;
using Problems.Trees;
using Xunit;

namespace UnitTests.TreeProblems
{
    public class AllBinTreePathTests
    {
        [Fact]
        public void Case0()
        {
            var root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(5);

            var sol = new AllBinaryTreePaths();
            var allPaths = sol.BinaryTreePaths(root);
            
            Assert.Equal("1->2->5",allPaths[0]);
            Assert.Equal("1->3",allPaths[1]);
        }
        
        [Fact]
        public void Case1()
        {
            var root = new TreeNode(1);
            
            var sol = new AllBinaryTreePaths();
            var allPaths = sol.BinaryTreePaths(root);
            
            Assert.Equal("1",allPaths[0]);
        }
    }
}