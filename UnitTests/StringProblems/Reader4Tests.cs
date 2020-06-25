using System.IO;
using System.Text;
using Problems.StringProblems;
using Xunit;

namespace UnitTests.StringProblems
{
    public class Reader4Tests
    {
        private Stream GetStream(string s)
        {
            var stream = new MemoryStream();
            using (var writer = new StreamWriter(stream, Encoding.Default,1024, true))
            {
                writer.Write(s);
            }

            stream.Position = 0;
            return stream;
        }

        [Theory]
        [InlineData(10, "The quick ")]
        [InlineData(0, "")]
        [InlineData(1, "T")]
        public void Individual_reads(int n, string expected)
        {
            var reader4 = new Reader4(GetStream("The quick brown fox jumps over the lazy dog"));

            var buf = new char[512];
            var count = reader4.Read(buf, n);
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));
        }

        [Fact]
        public void Cumulative_reads_case0()
        {
            var reader4 = new Reader4(GetStream("abc"));

            var buf = new char[512];
            var count = reader4.Read(buf, 1);
            var expected = "a";
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));

            count = reader4.Read(buf, 2);
            expected = "bc";
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));

            count = reader4.Read(buf, 1);
            expected = "";
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));

        }
        [Fact]
        public void Cumulative_reads_case1()
        {
            var reader4 = new Reader4(GetStream("abc"));

            var buf = new char[512];
            var count = reader4.Read(buf, 4);
            var expected = "abc";
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));
            
            count = reader4.Read(buf, 1);
            expected = "";
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));

        }
        
        [Fact]
        public void Cumulative_reads_case2()
        {
            var reader4 = new Reader4(GetStream("ab"));

            var buf = new char[512];
            var count = reader4.Read(buf, 1);
            var expected = "a";
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));
            
            count = reader4.Read(buf, 2);
            expected = "b";
            Assert.Equal(expected.Length, count);
            Assert.Equal(expected, new string(buf,0,expected.Length));

        }
    }
}