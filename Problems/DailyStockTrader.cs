namespace Problems
{
    public class DailyStockTrader
    {
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
        public int MaxProfit(int[] prices) {
            if(prices ==null || prices.Length == 0) return 0;
            // we can perform as many trades as we like. so being greedy is the way
            var priceChanges = new int [prices.Length];

            for (var i = 0; i < prices.Length - 1; i++)
                priceChanges[i] = prices[i + 1] - prices[i];
            //the price after the final day is 0 since you cannot make any profit
            priceChanges[priceChanges.Length - 1] = -1;
            
            var isOwning = priceChanges[0] > 0;
            int profit = 0;
            int purchasePrice = isOwning ? prices[0]: -1;
            
            for (var i = 0; i < priceChanges.Length; i++)
            {
                if (isOwning && priceChanges[i] < 0)
                {
                    //sell if the next day price is lower
                    profit += prices[i] - purchasePrice;
                    purchasePrice = -1;
                    isOwning = false;
                    continue;
                }

                if (!isOwning && priceChanges[i] > 0)
                {
                    //buy
                    isOwning = true;
                    purchasePrice = prices[i];
                }
            }
            
            return profit;
        }
    }
}