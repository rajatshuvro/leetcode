using UnitTests.Utilities;
using Xunit;

namespace UnitTests.TreeProblems
{
    public class TreeBuilderTests
    {
        [Fact]
        public void LeafNode()
        {
            var root = TreeBuilder.Build("[1]");
            
            Assert.Equal(1, root.val);
            Assert.Null(root.right);
            Assert.Null(root.left);
        }
        
        [Fact]
        public void CompleteTree()
        {
            var root = TreeBuilder.Build("[1,2,3]");
            
            Assert.Equal(1, root.val);
            Assert.NotNull(root.right);
            Assert.NotNull(root.left);

            var left = root.left;
            var right = root.right;
            Assert.Equal(2,left.val);
            Assert.Equal(3,right.val);
        }
        
        [Fact]
        public void Chain()
        {
            var root = TreeBuilder.Build("[1,2,null,3,null]");
            
            Assert.Equal(1, root.val);
            Assert.Null(root.right);
            Assert.NotNull(root.left);
            
            var node2 = root.left;
            Assert.Equal(2,node2.val);
            Assert.Null(node2.right);
            Assert.NotNull(node2.left);
            
            var node3 = node2.left;
            Assert.Equal(3,node3.val);
            Assert.Null(node3.left);
            Assert.Null(node3.right);
        }
    }
}