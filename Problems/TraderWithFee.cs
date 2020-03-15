using System;

namespace Problems
{
    public class TraderWithFee
    {
 /*       
        public int MaxProfit(int[] prices, int fee) {
            //if there are less than 2 trading days available, there is no point trading.
            if(prices ==null || prices.Length <= 1) return 0;
            
            // profit if you are at buyer/seller state on day i
            var buyProfits = new int[prices.Length];
            var sellProfits = new int[prices.Length];

            buyProfits[0] = -prices[0];
            
            for (var i = 1; i < prices.Length; i++)
            {
                sellProfits[i] = Math.Max(buyProfits[i - 1] + prices[i] - fee, sellProfits[i - 1]);
                buyProfits[i] = Math.Max(sellProfits[i - 1] - prices[i], buyProfits[i - 1]);
            }

            return sellProfits[prices.Length - 1] < 0? 0: sellProfits[prices.Length-1];
        }
*/
        public int MaxProfit(int[] prices, int fee) {
            //if there are less than 2 trading days available, there is no point trading.
            if(prices ==null || prices.Length <= 1) return 0;

            var prevBuyProfit = -prices[0];
            var prevSellProfit = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                int sellProfit = Math.Max(prevBuyProfit + prices[i] - fee, prevSellProfit);
                int buyProfit = Math.Max(prevSellProfit - prices[i], prevBuyProfit);
                
                prevBuyProfit = buyProfit;
                prevSellProfit = sellProfit;
            }

            return prevSellProfit;
        }
    }
}