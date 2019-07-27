using System;

namespace Problems
{
    public class PricePercentile
    {
        // interview question
        // Given a stream of prices in a given range [1 cent to 100 dollars], quickly return the p-th percentile price 
        // assumptions: smallest unit of price is a cent (i.e. price can only have two decimal precision

        private readonly int _priceCount;
        private readonly int[] _buckets;
        public int Count => _buckets[1];// the tree starts from node 1. This makes indexing easy
        public PricePercentile(double low, double high)
        {
            _priceCount = (int)((high - low) * 100);
            // in order to create a tree on the bucket counts, we need 2 times the items in this array
            // they are all auto initialized to 0 which gives the correct tree.
            _buckets = new int[_priceCount * 2 + 1];
        }

        public void Add(double price)
        {
            if (price < 0.01) 
                throw new ArgumentOutOfRangeException("price has to be at least 0.01");

            int bucketIndex = (int) (price * 100) + _priceCount;
            // the tree starts from node 1. This makes indexing easy
            while (bucketIndex > 0)
            {
                _buckets[bucketIndex]++;
                bucketIndex /= 2;
            }
            
        }

        public double GetPercentilePrice(double percentile)
        {
            if (Count == 0) return 0;
            // using 1 based rank
            var rank = (int) (Count * percentile) + 1;

            return GetPriceWithRank(rank, 1);
        }

        private double GetPriceWithRank(int rank, int rootIndex)
        {
            if (rank < 0) return -1;// this is an error!!
            if (rank > _buckets[rootIndex]) return -1; // error!! you have reached a node that has fewer elements than rank

            if (rootIndex >= _priceCount)
            {
                if (_buckets[rootIndex] == 0) return 0;
                return (double) (rootIndex - _priceCount) / 100;
            }

            int leftIndex = rootIndex * 2;
            int leftCount = _buckets[leftIndex];
            int rightIndex = leftIndex + 1;

            return rank <= leftCount ? GetPriceWithRank(rank, leftIndex) : GetPriceWithRank(rank - leftCount, rightIndex);
        }
    }
}