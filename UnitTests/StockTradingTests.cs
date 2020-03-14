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

        [Theory]
        [InlineData(new[]{7,1,5,3,6,4}, 7)]
        [InlineData(new[]{7,5,3,1,3,5,4,3,4,6,5,4}, 7)]
        [InlineData(new[]{1,2,3,4,5}, 4)]
        [InlineData(new[]{7,6,4,3,1}, 0)]
        public void DailyStockTraderTests(int[] prices, int maxProfit)
        {
            var dailyTrader = new DailyStockTrader();
            Assert.Equal(maxProfit, dailyTrader.MaxProfit(prices));
        }
    }
}