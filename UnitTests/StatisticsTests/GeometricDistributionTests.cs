using Statistics;
using Xunit;

namespace UnitTests.StatisticsTests
{
    public class GeometricDistributionTests
    {
        [Theory]
        [InlineData(5, 0.7, 0.005670000000000003)]
        public void Probability(int n, double p, double expected)
        {
            Assert.Equal(expected, GeometricDistribution.Probability(n,p));
        }

        [Theory]
        [InlineData(5, 1.0/3, 0.8683127572016461)]
        public void FirstSuccessWithin(int n, double p, double expected)
        {
            Assert.Equal(expected, GeometricDistribution.FirstSuccessWithin(n,p));
        }
    }
}