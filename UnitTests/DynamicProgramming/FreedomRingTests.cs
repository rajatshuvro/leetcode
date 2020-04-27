using Problems.DynamicProgramming;
using Xunit;

namespace UnitTests.DynamicProgramming
{
    public class FreedomRingTests
    {
        [Theory]
        [InlineData("password", "swarp", 17)]
        [InlineData("godding", "gd", 4)]
        [InlineData("godding", "gddg", 8)]
        [InlineData("zvyii", "iivyz", 11)]
        [InlineData("caotmcaataijjxi", "oatjiioicitatajtijciocjcaaxaaatmctxamacaamjjx", 137)]
        public void StepCount(string ring, string key, int stepCount)
        {
            var freedomRing = new FreedomRing();
            Assert.Equal(stepCount, freedomRing.FindRotateSteps(ring, key));
        }
        
    }
}