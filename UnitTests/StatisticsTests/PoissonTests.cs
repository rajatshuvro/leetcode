using Statistics;
using Xunit;

namespace UnitTests.StatisticsTests
{
    public class PoissonTests
    {
        [Theory]
        [InlineData(3,2,0.1804470443154836)]
        public void ProbabilityTests(int x, double mean, double prob)
        {
            Assert.Equal(prob, PoissonDistribution.Probability(x,mean));
        }
        
        [Theory]
        [InlineData(3,5.0,0.26502591529736175)]
        public void AtLeastTests(int x, double mean, double prob)
        {
            Assert.Equal(prob, PoissonDistribution.AtLeast(x,mean));
        }
    }
}