using Problems;
using Xunit;

namespace UnitTests
{
    public class OccuranceAfterBigramTests
    {
        [Fact]
        public void Trivial()
        {
            var trigram = new OccuranceAfterBigram();

            Assert.Equal(new []{"girl", "student"}, trigram.FindOcurrences("alice is a good girl she is a good student", "a" , "good"));
        }

        [Fact]
        public void Trivial_2()
        {
            var trigram = new OccuranceAfterBigram();

            Assert.Equal(new[] { "we", "rock" }, trigram.FindOcurrences("we will we will rock you", "we", "will"));
        }
    }
}