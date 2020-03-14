using Problems;
using Xunit;

namespace UnitTests
{
    public class StockTradingTests
    {
        [Theory]
        [InlineData(new []{7,1,5,3,6,4}, 5)]
        [InlineData(new []{7,6,4,3,1}, 0)]
        public void MaxProfitOneTransaction(int[] prices, int maxProfit)
        {
            var oneTimeTrader = new OneTimeTrader();
            Assert.Equal(maxProfit, oneTimeTrader.MaxProfit(prices));
        }
    }
}