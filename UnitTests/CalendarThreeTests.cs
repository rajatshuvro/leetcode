using Problems;
using Xunit;

namespace UnitTests
{
    public class CalendarThreeTests
    {
        [Fact]
        public void Basic()
        {
            var calendar = new MyCalendarThree();

            Assert.Equal(1, calendar.Book(10, 20)); // returns 1
            Assert.Equal(1,calendar.Book(50, 60)); // returns 1
            Assert.Equal(2,calendar.Book(10, 40)); // returns 2
            Assert.Equal(3, calendar.Book(5, 15)); // returns 3
            Assert.Equal(3, calendar.Book(5, 10)); // returns 3
            Assert.Equal(3, calendar.Book(25, 55)); // returns 3
        }

        [Fact]
        public void Failed_case1()
        {
            /*
             * input: ["MyCalendarThree","book","book","book","book","book","book","book","book","book","book"]
             * [[],[24,40],[43,50],[27,43],[5,21],[30,40],[14,29],[3,19],[3,14],[25,39],[6,19]]
             * Output:[null,1,1,2,2,3,4,4,4,5,5]
             * Expected:[null,1,1,2,2,3,3,3,3,4,4]
             */
        }
    }


}