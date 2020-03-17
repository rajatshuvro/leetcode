using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class LimitedTransactionsTrader
    {
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-iv/
        // profit from k transactions from day i to day j
        private readonly Dictionary<(int i, int j, int k), int> _maxProfits= new Dictionary<(int, int, int), int>();
        public int MaxProfit(int k, int[] prices)
        {
            if (k == 0 || prices == null || prices.Length <= 1) return 0;
            var n = prices.Length;
            ComputeOneTransactionProfits(prices);
            if (k == 1) return _maxProfits[(0, n - 1, 1)];
            
            return GetMaxProfit(0,n-1,k);
        }

        private int GetMaxProfit(int i, int j, int k)
        {
            if (k <= 0 || i>=j) return 0;
            if (_maxProfits.TryGetValue((i, j, k), out var p)) return p;

            var maxProfit = GetMaxProfit(i, j, k - 1);
            _maxProfits.TryAdd((i, j, k - 1), maxProfit);

            for (var x = i + 1; x < j; x++)
            {
                var maxProfitOne = GetMaxProfit(i, x, k - 1);
                _maxProfits.TryAdd((i, x, k - 1), maxProfitOne);
                var maxProfitTwo = GetMaxProfit(x + 1, j, 1);
                if (maxProfitOne + maxProfitTwo > maxProfit) maxProfit = maxProfitOne + maxProfitTwo;
            }

            if (maxProfit < 0) maxProfit = 0;
            _maxProfits.TryAdd((i, j, k), maxProfit);
            return maxProfit;
        }

        private void ComputeOneTransactionProfits(int[] prices)
        {
            
            var minPrices = GetMinPrices(prices);
            var maxPrices = GetMaxPrices(prices);
            
            // compute p_(1,i,1) i=2...n-1
            var n = prices.Length;
            var maxProfit = 0;
            for (var i = 1; i < n; i++)
            {
                var profit = prices[i] - minPrices[i - 1];
                if(profit > maxProfit) maxProfit=profit;
                _maxProfits.Add((0, i, 1), maxProfit);
            }
            // compute p_(i,n,1) i=2...n-1
            maxProfit = 0;
            for (var j = n - 2; j > 0; j--)
            {
                var profit = maxPrices[j + 1] - prices[j];
                if(profit > maxProfit) maxProfit=profit;
                _maxProfits.Add((j,n-1,1), maxProfit);
            }
        }

        private static int[] GetMaxPrices(int[] prices)
        {
            var n = prices.Length;
            var maxPrices = new int[n];
            var maxPrice = prices[n-1];
            maxPrices[n-1] = maxPrice;
            for (var i = n-2; i >=0; i--)
            {
                if (prices[i] > maxPrice)
                {
                    maxPrice = prices[i];
                }

                maxPrices[i] = maxPrice;
            }

            return maxPrices;
        }

        private static int[] GetMinPrices(int[] prices)
        {
            var n = prices.Length;

            var minPrices = new int[n];
            var minPrice = prices[0];
            minPrices[0] = minPrice;
            for (var i = 1; i < n; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }

                minPrices[i] = minPrice;
            }

            return minPrices;
        }
    }
}