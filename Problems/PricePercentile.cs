using System;

namespace Problems
{
    public class PricePercentile
    {
        // interview question
        // Given a stream of prices in a given range [1 cent to 100 dollars], quickly return the p-th percentile price 
        // assumptions: smallest unit of price is a cent (i.e. price can only have two decimal precision

        private readonly int _priceCount;
        private readonly int _leafOffset;
        private readonly int[] _buckets;
        public int Count => _buckets[1];//starting tree at index 1
        public PricePercentile(double low, double high)
        {
            _priceCount = (int)((high - low) * 100) + 1;
            _leafOffset = 1;
            while (_leafOffset < _priceCount)
            {
                _leafOffset <<= 1;//doubling the leaf offset
            }
            // in order to create a tree on the bucket counts, we need 2 times the items in this array
            // they are all auto initialized to 0 which gives the correct tree.
            _buckets = new int[_leafOffset + _priceCount +  1];
        }

        public void Add(double price)
        {
            if (price < 0.01) 
                throw new ArgumentOutOfRangeException("price has to be at least 0.01");

            int bucketIndex = (int) (price * 100) + _leafOffset -1;
            // the tree starts from node 1. This makes indexing easy
            while (bucketIndex > 0)
            {
                _buckets[bucketIndex]++;
                bucketIndex /= 2;
            }
        }

        public double GetPercentilePrice(double percentile)
        {
            if (Count == 0 || percentile.Equals(0)) return 0;
            // using 1 based rank
            var rank = (int) (Count * percentile) + 1;
            if (rank > Count) rank = Count;
            return GetPriceWithRank(rank, 1);
        }

        private double GetPriceWithRank(int rank, int rootIndex)
        {
            if (rank < 0) return -1;// this is an error!!
            if (rank > _buckets[rootIndex]) return -1; // error!! you have reached a node that has fewer elements than rank

            if (rootIndex >= _leafOffset)
                return (double) (rootIndex - _leafOffset +1) / 100;

            int leftIndex = rootIndex * 2;
            int leftCount = _buckets[leftIndex];
            int rightIndex = leftIndex + 1;

            return rank <= leftCount ? GetPriceWithRank(rank, leftIndex) : GetPriceWithRank(rank - leftCount, rightIndex);
        }
    }
}