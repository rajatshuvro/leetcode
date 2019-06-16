using Problems;
using Xunit;

namespace UnitTests
{
    public class MinimumTreeTests
    {
        [Fact]
        public void Test0()
        {
            var minTree = new SumOfFiles();
            Assert.Equal(58, minTree.minimumTime(4, new[] { 8,4,6,12}));
        }

        [Fact]
        public void Test1()
        {
            var minTree = new SumOfFiles();
            Assert.Equal(54, minTree.minimumTime(4,new []{20,4,8,2}));
        }

        [Fact]
        public void Test2()
        {
            var minTree = new SumOfFiles();
            Assert.Equal(224, minTree.minimumTime(6, new[] { 1,2,5,10,35,89}));
        }

        [Fact]
        public void OddCase()
        {
            var minTree = new SumOfFiles();
            Assert.Equal(82, minTree.minimumTime(5, new[] { 1, 2, 5, 10, 35 }));
        }

        [Fact]
        public void EdgeCase1()
        {
            var minTree = new SumOfFiles();
            Assert.Equal(52, minTree.minimumTime(1, new[] { 52 }));
        }

        [Fact]
        public void EdgeCase2()
        {
            var minTree = new SumOfFiles();
            Assert.Equal(0, minTree.minimumTime(0, null));
        }
    }
}