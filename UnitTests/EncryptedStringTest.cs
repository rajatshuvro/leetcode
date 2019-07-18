using Problems;
using Xunit;

namespace UnitTests
{
    public class EncryptedStringTest
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("012", 0)]
        [InlineData("100", 0)]
        [InlineData("1", 1)]
        [InlineData("10", 1)]
        [InlineData("101", 1)]
        [InlineData("110", 1)]
        [InlineData("12", 2)]
        [InlineData("01", 0)]
        [InlineData("26", 2)]
        [InlineData("29", 1)]
        [InlineData("123", 3)]
        [InlineData("103", 1)]
        [InlineData("226", 3)]
        public void EncryptedStringTests(string s, int n)
        {
            var decoder = new EncryptedString();
            Assert.Equal(n, decoder.NumDecodings(s));
        }

    }
}