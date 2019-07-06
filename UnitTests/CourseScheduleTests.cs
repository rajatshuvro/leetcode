using Problems;
using Xunit;

namespace UnitTests
{
    public class CourseScheduleTests
    {
        [Fact]
        public void TestCase_1()
        {
            var prerequisits = new int[1][];
            prerequisits[0] = new[] {1,0};

            var courseScheduler = new CourseSchedule();

            Assert.True(courseScheduler.CanFinish(2, prerequisits));
        }

        [Fact]
        public void TestCase_2()
        {
            var prerequisits = new int[2][];
            prerequisits[0] = new[] { 1, 0 };
            prerequisits[1] = new[] { 0, 1 };

            var courseScheduler = new CourseSchedule();

            Assert.False(courseScheduler.CanFinish(2, prerequisits));
        }

        [Fact]
        public void TestCase_3()
        {
            //3
            //[[0,1],[0,2],[1,2]]

            var prerequisits = new int[3][];
            prerequisits[0] = new[] { 0, 1 };
            prerequisits[1] = new[] { 0, 2 };
            prerequisits[2] = new[] { 1, 2 };

            var courseScheduler = new CourseSchedule();

            Assert.True(courseScheduler.CanFinish(3, prerequisits));
        }
    }
}