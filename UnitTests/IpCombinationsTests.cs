using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class IpCombinationsTests
    {
        [Fact]
        public void Basic()
        {
            var sol = new IpCombinations();

            var combinations = sol.RestoreIpAddresses("25525511135");

            Assert.Equal(new []{ "255.255.11.135", "255.255.111.35" }, combinations);
        }

        [Fact]
        public void OneValidTriplet()
        {
            var sol = new IpCombinations();

            var combinations = sol.GetValidIpTriplets("135",1);

            Assert.Equal(new[] { "135" }, combinations);
        }

        [Fact]
        public void OneInvalidTriplet()
        {
            var sol = new IpCombinations();

            var combinations = sol.GetValidIpTriplets("1135", 1);

            Assert.Null( combinations);
        }

        [Fact]
        public void TwoValidTriplets_3()
        {
            var sol = new IpCombinations();

            var combinations = sol.GetValidIpTriplets("1135", 2);

            Assert.Equal(new[] { "1.135", "11.35", "113.5" }, combinations);
        }

        [Fact]
        public void TwoValidTriplets_1()
        {
            var sol = new IpCombinations();

            var combinations = sol.GetValidIpTriplets("52135", 2);

            Assert.Equal(new[] { "52.135"}, combinations);
        }

        [Fact]
        public void TwoValidTriplets_2()
        {
            var sol = new IpCombinations();

            var combinations = sol.GetValidIpTriplets("2552", 2);

            Assert.Equal(new[] { "25.52", "255.2" }, combinations);
        }

        [Fact]
        public void All_zeros()
        {
            var sol = new IpCombinations();

            var combinations = sol.GetValidIpTriplets("0000", 4);

            Assert.Equal(new[] { "0.0.0.0"}, combinations);
        }

        [Fact]
        public void No_leading_zeros()
        {
            var sol = new IpCombinations();

            var combinations = sol.GetValidIpTriplets("010010", 4);

            Assert.Equal(new[] { "0.10.0.10", "0.100.1.0" }, combinations);
        }

        [Fact]
        public void Empty_input()
        {
            var sol = new IpCombinations();

            var combinations = sol.RestoreIpAddresses("");

            Assert.Equal(new List<string>(), combinations);
        }
    }
}