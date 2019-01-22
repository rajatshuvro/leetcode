using Problems;
using Xunit;

namespace UnitTests
{
    public class FindDuplicateTests
    {
        [Fact]
        public void TestCase_1()
        {
            var dupliFinder = new FindDuplicateNumber();

            Assert.Equal(2, dupliFinder.FindDuplicate(new []{ 1, 3, 4, 2, 2 }));
        }

        [Fact]
        public void TestCase_2()
        {
            var dupliFinder = new FindDuplicateNumber();

            Assert.Equal(3, dupliFinder.FindDuplicate(new[] { 3, 1, 3, 4, 2 }));
        }
    }
}