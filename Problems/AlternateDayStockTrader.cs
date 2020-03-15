using System;

namespace Problems
{
    public class AlternateDayStockTrader
    {
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-with-cooldown/
        // as many trades as you want, but after each sell, there is a 1 day cool down period 
        public int MaxProfit(int[] prices) {
            if(prices ==null || prices.Length == 0) return 0;

            var lastBuyProfit = 0;
            var buyProfit = int.MinValue;
            var lastSellProfit = 0;
            var sellProfit = 0;

            for (var i = 0; i < prices.Length; i++)
            {
                lastBuyProfit = buyProfit;
                buyProfit = Math.Max(lastSellProfit - prices[i], lastBuyProfit);
                lastSellProfit = sellProfit;
                sellProfit = Math.Max(lastBuyProfit + prices[i], lastSellProfit);
            }

            return sellProfit;
        }
    }
}