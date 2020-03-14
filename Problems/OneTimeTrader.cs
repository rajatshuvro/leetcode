namespace Problems
{
    public class OneTimeTrader
    {
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public int MaxProfit(int[] prices)
        {
            // minPrices[i] is the min price of the stock until day i
            
            if(prices ==null || prices.Length == 0) return 0;
            var minPrices = new int[prices.Length];
            var minPrice  = prices[0];
            minPrices[0]  = prices[0];
            
            for (var i = 1; i < minPrices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                minPrices[i] = minPrice;
            }

            var maxProfit = 0;
            for (var i = 1; i < prices.Length; i++)
            {
                // if i buy at the min price till day i-1 and sold at day i 
                var profit = prices[i] - minPrices[i-1];
                if (maxProfit < profit) maxProfit = profit;
            }

            return maxProfit;
        }
    }
}