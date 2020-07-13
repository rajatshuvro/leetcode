using System.Collections.Generic;
using DataStructures;
using Problems.Trees;
using Xunit;

namespace UnitTests
{
    public class DupSubtreesTests
    {
        [Fact]
        public void Case_0()
        {
            var node1 = new TreeNode(1);
            var node2_1 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node2_2 = new TreeNode(2);
            var node4_1 = new TreeNode(4);
            var node4_2 = new TreeNode(4);
            var node4_3 = new TreeNode(4);

            node1.left = node2_1;
            node1.right = node3;

            node2_1.left = node4_1;

            node3.left = node2_2;
            node3.right = node4_3;
            node2_2.left = node4_2;
            
            var dupFinder = new DuplicateSubtree();
            var dupTrees = dupFinder.FindDuplicateSubtrees(node1);
            
            Assert.Equal(new List<TreeNode>(){node4_2, node2_2}, dupTrees);
        }
    }
}