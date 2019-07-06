using Problems;
using Xunit;

namespace UnitTests
{
    public class CourseOrderingTests
    {
        [Fact]
        public void TestCase_0()
        {
            var prerequisits = new int[0][];

            var courseScheduler = new CourseOrdering();

            Assert.Equal(new[] { 0 }, courseScheduler.FindOrder(1, prerequisits));
        }
        [Fact]
        public void TestCase_1()
        {
            var prerequisits = new int[1][];
            prerequisits[0] = new[] { 1, 0 };

            var courseScheduler = new CourseOrdering();

            Assert.Equal(new []{0,1}, courseScheduler.FindOrder(2, prerequisits));
        }

        [Fact]
        public void TestCase_2()
        {
            var prerequisits = new int[4][];
            prerequisits[0] = new[] { 1, 0 };
            prerequisits[1] = new[] { 2, 0 };
            prerequisits[2] = new[] { 3, 1 };
            prerequisits[3] = new[] { 3, 2 };

            var courseScheduler = new CourseOrdering();

            Assert.Equal(new[] { 0, 1, 2, 3 }, courseScheduler.FindOrder(4, prerequisits));
        }

        [Fact]
        public void TestCase_3()
        {
            var prerequisits = new int[2][];
            prerequisits[0] = new[] { 1, 0 };
            prerequisits[1] = new[] { 0, 1 };

            var courseScheduler = new CourseOrdering();

            Assert.Equal(new int[] {  }, courseScheduler.FindOrder(2, prerequisits));
        }

        [Fact]
        public void TestCase_4()
        {
            var prerequisits = new int[1][];
            prerequisits[0] = new[] { 1, 0 };

            var courseScheduler = new CourseOrdering();

            Assert.Equal(new [] {0,1,2 }, courseScheduler.FindOrder(3, prerequisits));
        }
    }
}