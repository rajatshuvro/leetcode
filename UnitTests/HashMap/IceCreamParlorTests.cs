using Problems.HashMap;
using Xunit;

namespace UnitTests.HashMap
{
    public class IceCreamParlorTests
    {
        [Theory]
        [InlineData(new int[]{2,1,3,5,6}, 5, 0,2)]
        [InlineData(new int[]{1, 4, 5, 3, 2}, 4, 0,3)]
        [InlineData(new int[]{2, 2, 4, 3}, 4, 0,1)]
        [InlineData(new int[]{4, 3, 2, 5, 7}, 8, 1,3)]
        [InlineData(new int[]{3, 3, 2, 5, 7}, 6, 0,1)]
        [InlineData(new int[]{3, 3, 2, 5, 5, 6, 9}, 10, 3, 4)]
        [InlineData(new int[]{3, 3, 2, 5, 5, 6, 8}, 4, -1, -1)]
        public void FindPairsTests(int[] costs, int money, int i, int j)
        {
            var (x, y) = IceCreamParlor.GetTwoFlavors(costs, money);
            Assert.Equal(i, x);
            Assert.Equal(j, y);
        }
    }
}