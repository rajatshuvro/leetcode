using System;
using Problems;
using Xunit;

namespace UnitTests
{
    public class PricePercentileTests
    {
        [Fact]
        public void Add_tests()
        {
            var percentiler = new PricePercentile(0.01, 100);

            for (var i = 0; i < 128; i++)
            {
                var rand = new Random();
                var p = rand.NextDouble() * 100;
                p = Math.Round(p, 2);
                if (p < 0.01) p = 0.01;// the min price
                percentiler.Add(p);
            }

            Assert.Equal(128, percentiler.Count);
        }

        [Fact]
        public void GetPercentile_empty()
        {
            var percentiler = new PricePercentile(0.01, 100);

            Assert.Equal(0, percentiler.GetPercentilePrice(0.5));
        }

        [Fact]
        public void GetPercentile_onePrice()
        {
            var percentiler = new PricePercentile(0.01, 1);

            percentiler.Add(0.03);
            Assert.Equal(0.03, percentiler.GetPercentilePrice(0.5));
        }

        [Fact]
        public void GetPercentile_twoPrices()
        {
            var percentiler = new PricePercentile(0.01, 1);

            percentiler.Add(0.03);
            percentiler.Add(0.05);
            Assert.Equal(0.03, percentiler.GetPercentilePrice(0.25));
            Assert.Equal(0.05, percentiler.GetPercentilePrice(0.5));
        }
    }
}