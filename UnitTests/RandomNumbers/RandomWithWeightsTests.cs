using System;
using System.Linq;
using Problems.RandomNumbers;
using Xunit;

namespace UnitTests.RandomNumbers
{
    public class RandomWithWeightsTests
    {
        [Theory]
        [InlineData(new int[] {1, 3})]
        [InlineData(new int[] {2, 1, 3})]
        public void CheckWeightedFrequncies(int[] weights)
        {
            var randWithWeights = new RandomWithWeights(weights);
            var frequencies = new double[weights.Length];
            var sum = weights.Sum();
            for (int i = 0; i < weights.Length; i++)
            {
                frequencies[i] = 1.0 * weights[i] / sum;
            }

            var counts = new int[weights.Length];
            var sampleSize = 1000;
            for (int i = 0; i < sampleSize; i++)
            {
                var j = randWithWeights.PickIndex();
                counts[j]++;
            }
            
            var countFrequencies = new double[weights.Length];
            for (int i = 0; i < weights.Length; i++)
            {
                countFrequencies[i] = 1.0 * counts[i] / sampleSize;
            }

            for (int i = 0; i < weights.Length; i++)
            {
                Assert.True(Math.Abs(frequencies[i] - countFrequencies[i]) < 0.001);
            }
        }
    }
}