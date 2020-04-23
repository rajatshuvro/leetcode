using Problems.Recursion;
using Xunit;

namespace UnitTests.Recursion
{
    public class CountAtomsTests
    {
        [Theory]
        [InlineData("H2O", "H2O")]
        [InlineData("Mg(OH)2", "H2MgO2")]
        [InlineData("H2O2He3Mg4", "H2He3Mg4O2")]
        [InlineData("H2SO4(Mg(OH)2)3", "H8Mg3O10S")]
        public void AtomCounting(string formula, string expectedCounts)
        {
            var atomCounter = new CountAtoms();
            Assert.Equal(expectedCounts, atomCounter.CountOfAtoms(formula));
        }
    }
}