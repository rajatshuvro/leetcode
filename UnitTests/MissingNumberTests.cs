using Problems;
using Xunit;

namespace UnitTests
{
    public class MissingNumberTests
    {
        [Fact]
        public void Missing_2()
        {
            var array = new[] {3, 0, 1};

            var sol = new FindMissingNumber();

            Assert.Equal(2, sol.MissingNumber(array));
        }

        [Fact]
        public void Missing_8()
        {
            var array = new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };

            var sol = new FindMissingNumber();

            Assert.Equal(8, sol.MissingNumber(array));
        }

        [Fact]
        public void Missing_0()
        {
            var array = new[] { 2,1 };

            var sol = new FindMissingNumber();

            Assert.Equal(0, sol.MissingNumber(array));
        }

        [Fact]
        public void Missing_no_missing()
        {
            var array = new[] { 0,2, 1};

            var sol = new FindMissingNumber();

            Assert.Equal(3, sol.MissingNumber(array));
        }
    }
}