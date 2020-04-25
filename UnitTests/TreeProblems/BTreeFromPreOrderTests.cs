using Problems.Trees;
using Xunit;

namespace UnitTests.TreeProblems
{
    public class BTreeFromPreOrderTests
    {
        [Theory]
        [InlineData("1-2--3--4-5--6--7", "1,2,3,null,null,4,null,null,5,6,null,null,7,null,null")]
        [InlineData("1-2--3---4-5--6---7", "1,2,3,4,null,null,null,null,5,6,7,null,null,null,null")]
        [InlineData("1-401--349---90--88", "1,401,349,90,null,null,null,88,null,null,null")]
        public void BuildFromPreOrder(string preOrder, string serializedTree)
        {
            var treeBuilder = new BinTreeFromPreOrder();
            var root = treeBuilder.RecoverFromPreorder(preOrder);
            var treeSerializer = new BinTreeCodec();
            var serialization = treeSerializer.serialize(root);
            
            Assert.NotNull(root);
            Assert.Equal(serializedTree, serialization);
        }
    }
}