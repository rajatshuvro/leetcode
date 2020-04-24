using Problems.Trees;
using Xunit;

namespace UnitTests.TreeProblems
{
    public class BTreeFromPreOrderTests
    {
        [Fact]
        public void Case0()
        {
            var treeBuilder = new BinTreeFromPreOrder();
            Assert.NotNull(treeBuilder.RecoverFromPreorder("1-2--3--4-5--6--7"));
        }
    }
}