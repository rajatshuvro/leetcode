using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class EnumeratorTests
    {
        private IEnumerator<char> GetChars(string s)
        {
            foreach (char c in s)
            {
                yield return c;
            }
        }
        [Theory]
        [InlineData(new string[] { }, new char[] {  })]
        [InlineData(new []{"abc"}, new []{'a', 'b', 'c'})]
        [InlineData(new[] { "abc", "def" }, new[] { 'a', 'b', 'c', 'd','e','f' })]
        [InlineData(new[] { "abc","", "def" }, new[] { 'a', 'b', 'c', 'd', 'e', 'f' })]
        public void TestEnumOfEnum(string[] words, IEnumerable<char> letters)
        {
            var enumerator = new EnumeratorOfEnumerator<char, string>(words, GetChars);
            var observed = new List<char>();
            while (enumerator.MoveNext())
            {
                observed.Add(enumerator.Current);
            }

            Assert.Equal(letters, observed);
        }
    }
}