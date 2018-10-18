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
    }
}