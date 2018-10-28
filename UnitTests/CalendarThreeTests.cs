using Problems;
using Xunit;

namespace UnitTests
{
    public class CalendarThreeTests
    {
        [Fact]
        public void Basic()
        {
            var calendar = new MyCalendarThree(0,100);

            Assert.Equal(1, calendar.Book(10, 20)); // returns 1
            Assert.Equal(1,calendar.Book(50, 60)); // returns 1
            Assert.Equal(2,calendar.Book(10, 40)); // returns 2
            Assert.Equal(3, calendar.Book(5, 15)); // returns 3
            Assert.Equal(3, calendar.Book(5, 10)); // returns 3
            Assert.Equal(3, calendar.Book(25, 55)); // returns 3
        }

        [Fact]
        public void Failed_case_6()
        {
            /*
             * input: ["MyCalendarThree","book","book","book","book","book","book","book","book","book","book"]
             * [[],[24,40],[43,50],[27,43],[5,21],[30,40],[14,29],[3,19],[3,14],[25,39],[6,19]]
             * Output:[null,1,1,2,2,3,4,4,4,5,5]
             * Expected:[null,1,1,2,2,3,3,3,3,4,4]
             */

            var calendar = new MyCalendarThree(0,100);
            var operations = new int[,] { {24, 40},{43, 50},{27, 43},{5, 21},{30, 40},{14, 29},{3, 19},{3, 14},{25, 39},{6, 19}};
            var expected = new int[] { 1, 1, 2, 2, 3, 3, 3, 3, 4, 4 };
            for (int i = 0; i < operations.GetLength(0); i++)
            {
                var result = calendar.Book(operations[i, 0], operations[i, 1]);
                Assert.Equal(expected[i], result);
            }
        }

        [Fact]
        public void Failed_case_29()
        {
            /*
             * input: ["MyCalendarThree","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book","book"]
             * [[],[47,50],[1,10],[27,36],[40,47],[20,27],[15,23],[10,18],[27,36],[17,25],[8,17],[24,33],[23,28],[21,27],[47,50],[14,21],[26,32],[16,21],[2,7],[24,33],[6,13],[44,50],[33,39],[30,36],[6,15],[21,27],[49,50],[38,45],[4,12],[46,50],[13,21]]
             * output:   [null,1,1,1,1,1,2,2,2,3,3,3,4,4,4,4,5,5,5,6,6,6,6,6,6,6,6,6,6,6,6]
             * expected: [null,1,1,1,1,1,2,2,2,3,3,3,4,5,5,5,5,5,5,6,6,6,6,6,6,7,7,7,7,7,7]
             */

            var calendar = new MyCalendarThree(0, 100);
            var operations = new int[,] { {47, 50},{1, 10},{27, 36},{40, 47},{20, 27},{15, 23},{10, 18},{27, 36},{17, 25},{8, 17},{24, 33},{23, 28},{21, 27},{47, 50},{14, 21},{26, 32},{16, 21},{2, 7},{24, 33},{6, 13},{44, 50},{33, 39},{30, 36},{6, 15},{21, 27},{49, 50},{38, 45},{4, 12},{46, 50},{13, 21} };
            var expected = new int[] { 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7 };

            for (int i = 0; i < operations.GetLength(0); i++)
            {
                var result = calendar.Book(operations[i, 0], operations[i, 1]);
                Assert.Equal(expected[i], result);
            }
        }
    }


}