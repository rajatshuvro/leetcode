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
            var trader = new OneTimeTrader();
            Assert.Equal(maxProfit, trader.MaxProfit(prices));
        }
        
        [Theory]
        [InlineData(1, new []{7,1,5,3,6,4}, 5)]
        [InlineData(1, new []{7,6,4,3,1}, 0)]
        [InlineData(2, new[]{7,1,5,3,6,4,0}, 7)]
        [InlineData(2, new[]{1,2,3,4,5}, 4)]
        [InlineData(3, new[]{7,5,3,1,3,5,4,3,4,6,5,4}, 7)]
        [InlineData(2, new[]{3,2,6,5,0,3}, 7)]
        [InlineData(1, new[]{1,2,3,4,5}, 4)]
        [InlineData(4, new[]{1,2,4,2,5,7,2,4,9,0}, 15)]
        public void LimitedTransactions(int k, int[] prices, int maxProfit)
        {
            var trader = new LimitedTransactionsTrader();
            Assert.Equal(maxProfit, trader.MaxProfit(k, prices));
        }


        [Theory]
        [InlineData(new[]{7,1,5,3,6,4}, 7)]
        [InlineData(new[]{7,5,3,1,3,5,4,3,4,6,5,4}, 7)]
        [InlineData(new[]{1,2,3,4,5}, 4)]
        [InlineData(new[]{7,6,4,3,1}, 0)]
        public void DailyStockTraderTests(int[] prices, int maxProfit)
        {
            var trader = new DailyStockTrader();
            Assert.Equal(maxProfit, trader.MaxProfit(prices));
        }
        
        [Theory]
        [InlineData(new[]{1,2,3,0,2}, 3)]
        public void AlternateDayTraderTests(int[] prices, int maxProfit)
        {
            var trader = new AlternateDayStockTrader();
            Assert.Equal(maxProfit, trader.MaxProfit(prices));
        }
        
        [Theory]
        [InlineData(new[]{1, 3, 2, 8, 4, 9}, 2, 8)]
        [InlineData(new[]{1,3,7,5,10,3}, 3, 6)]
        [InlineData(new[]{2,1,4,4,2,3,2,5,1,2}, 1, 4)]
        [InlineData(new[]{2,2,1,1,5,5,3,1,5,4}, 2, 4)]
        public void TraderWithFeesTests(int[] prices, int fee, int maxProfit)
        {
            var trader = new TraderWithFee();
            Assert.Equal(maxProfit, trader.MaxProfit(prices, fee));
        }
    }
}