using Statistics;
using Xunit;

namespace UnitTests.StatisticsTests
{
    public class NormalDistributionTests
    {
        [Theory]
        [InlineData(2, 1, 2, 0.5000000005)]
        [InlineData(0, 1, 0.5, 0.6914624627239939)]
        [InlineData(0, 1, -0.5, 0.3085375372760061)]
        [InlineData(20, 2, 19.5, 0.4012937293158862)]
        public void CumulativeDistributionTests(double mean, double std, double x, double p)
        {
            var nd = new NormalDistribution(mean, std);
            Assert.Equal(p, nd.CumulativeProbability(x));
        }

        [Theory]
        [InlineData(20,2,20,22, 0.34134473566763623)]
        public void CumulativeIntervalProbability(double mean, double std, double x, double y, double p)
        {
            var nd = new NormalDistribution(mean, std);
            Assert.Equal(p, nd.CumulativeIntervalProbability(x, y));
        }

        [Theory]
        [InlineData(70,10, 80, 0.15865526383236372)]
        [InlineData(70,10, 60, 0.8413447361676363)]
        public void ProbabilityGreaterThan(double mean, double std, double x, double p)
        {
            var nd = new NormalDistribution(mean, std);
            Assert.Equal(p, nd.ProbabilityGreaterThan(x));
        }
    }
}