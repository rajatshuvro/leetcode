using Problems;
using Xunit;

namespace UnitTests
{
    public class SmallestDistinctSubsequenceTests
    {
        [Theory]
        [InlineData("cdadabcc", "adbc")]
        [InlineData("aaaaaaa", "a")]
        [InlineData("abcd", "abcd")]
        [InlineData("ecbacba", "eacb")]
        [InlineData("leetcode", "letcod")]
        [InlineData("gicbjijdihjidagibifbeejgjjhfhjihcaihabhihjbiihaadijfgjdjjagcdaehcjhcfeffjhfjbghbbeageabhhjgfdihhbfjafaachibjaejegbbciejageigdeihhhbeejdahcgchjgebgcfgajeddebjfffjdgejggdjddjjihfihbcdddbjcbhdeedfhhghaddeggededfegjeffaejbfefbiighjacaecgdbhhihjbhegffhaef", "abcdefghij")]
        //[InlineData("pblspykdpqfhcfcirkrhbbfbnqagshfqrrkcjpsuaytjfwyhjpubttxkkpswuvoiicsnkxiyhsyqrqecsiabhvjfodpkdgcgdceobyfonnurqxvstxkgsagnosvfjgsnylyhbjcrkgaylgxxxmghfbpfqwpplntrrogtkapbpkkwkdxgrfmikdlcftuyywrsnfasxgiw", "")]
        public void Examples(string text, string result)
        {
            var sol = new SmallestDistinctSubsequence();
            Assert.Equal(result, sol.SmallestSubsequence(text));
        }
    }
}