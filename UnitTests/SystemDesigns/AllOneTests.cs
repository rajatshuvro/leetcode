using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class AllOneTests
    {
        [Fact]
        public void Case0()
        {
            var allOne = new AllOne();
            
            allOne.Inc("milk");
            allOne.Inc("egg");
            allOne.Inc("bread");
            allOne.Inc("berry");
            allOne.Inc("berry");
            
            allOne.Inc("egg");
            allOne.Inc("milk");
            allOne.Inc("milk");
            
            Assert.Equal("milk", allOne.GetMaxKey());
            Assert.Equal("bread", allOne.GetMinKey());
            
            allOne.Dec("bread");
            
            Assert.Equal("berry", allOne.GetMinKey());
            
            allOne.Dec("egg");
            Assert.Equal("egg", allOne.GetMinKey());
            
            allOne.Inc("berry");
            allOne.Inc("berry");
            Assert.Equal("berry", allOne.GetMaxKey());


        }
    }
}