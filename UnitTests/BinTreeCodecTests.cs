using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class BinTreeCodecTests
    {
        [Fact]
        public void SerializationTest_1()
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
            
            var codec = new BinTreeCodec();
            var s = codec.serialize(node1);
            
            Assert.Equal("1,2,4,null,null,null,3,2,4,null,null,null,4,null,null", s);
        }
    }
}