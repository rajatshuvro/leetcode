using System;

namespace Problems
{
    public class TraderWithFee
    {
        public int MaxProfit(int[] prices, int fee) {
            if(prices ==null || prices.Length == 0) return 0;
            var buyProfit = 0;
            var lastSellProfit = 0;
            var sellProfit = 0;
            
            for (var i = 0; i < prices.Length; i++)
            {
                var lastBuyProfit = buyProfit;
                buyProfit = Math.Max(lastSellProfit - prices[i] - fee, lastBuyProfit);
                lastSellProfit = sellProfit;
                sellProfit = Math.Max(lastBuyProfit + prices[i] - fee, lastSellProfit);
            }

            return sellProfit;
        }
    }
}