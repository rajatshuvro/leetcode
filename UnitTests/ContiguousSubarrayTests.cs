using Problems;
using Xunit;

namespace UnitTests
{
    public class ContiguousSubarrayTests
    {
        [Fact]
        public void OneElementTest()
        {
            var array = new ContiguousSubarray();

            Assert.Equal(0, array.FindMaxLength(new[] { 1 }));
        }
        [Fact]
        public void TwoElementTest()
        {
            var array = new ContiguousSubarray();

            Assert.Equal(2, array.FindMaxLength(new []{0,1}));
            Assert.Equal(0, array.FindMaxLength(new[] { 0, 0 }));
        }

        [Fact]
        public void ThreeElementTest()
        {
            var array = new ContiguousSubarray();

            Assert.Equal(2, array.FindMaxLength(new[] { 0, 1, 0 }));
            Assert.Equal(2, array.FindMaxLength(new[] { 1, 1, 0 }));
            Assert.Equal(0, array.FindMaxLength(new[] { 1, 1, 1 }));
        }

        [Fact]
        public void FourElementTest()
        {
            var array = new ContiguousSubarray();

            Assert.Equal(4, array.FindMaxLength(new[] { 0, 1, 1 ,0}));
            Assert.Equal(2, array.FindMaxLength(new[] { 0, 1, 1, 1 }));
            Assert.Equal(2, array.FindMaxLength(new[] { 0, 0, 1, 0 }));
        }

        [Fact]
        public void ManyElementTest()
        {
            var array = new ContiguousSubarray();

            Assert.Equal(8, array.FindMaxLength(new[] { 0, 1, 1, 0, 1, 1, 0, 0 }));
            Assert.Equal(6, array.FindMaxLength(new[] { 0, 1, 1, 1, 0, 0 }));
            Assert.Equal(4, array.FindMaxLength(new[] { 0, 0, 1, 0 , 0,1}));
        }
    }
}