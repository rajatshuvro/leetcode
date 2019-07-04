using Problems;
using Xunit;

namespace UnitTests
{
    public class EleminationGameTests
    {
        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        [InlineData(9, 6)]
        [InlineData(24, 14)]
        public void EleminateTests(int numberOfPeople, int luckyGuy)
        {
            var elemination = new EleminationGame();

            Assert.Equal(luckyGuy, elemination.LastRemaining(numberOfPeople));
        }
    }
}