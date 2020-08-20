using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class HitCounterTests
    {
        [Fact]
        public void Case_0()
        {
            var hc = new HitCounter();
            
            hc.Hit(1);
            hc.Hit(2);
            hc.Hit(3);
            
            Assert.Equal(3, hc.GetHits(4));
            
            hc.Hit(300);
            Assert.Equal(4, hc.GetHits(300));
            
            Assert.Equal(3, hc.GetHits(301));
        }
        
        [Fact]
        public void Case_17()
        {
            var hc = new HitCounter();
            
            hc.Hit(1);
            hc.Hit(1);
            hc.Hit(1);
            hc.Hit(300);
            
            Assert.Equal(4, hc.GetHits(300));
            
            hc.Hit(300);
            Assert.Equal(5, hc.GetHits(300));
            
            hc.Hit(301);
            Assert.Equal(3, hc.GetHits(301));
        }
        
        [Fact]
        public void Case_18()
        {
            var hc = new HitCounter();
            
            hc.Hit(1);
            hc.Hit(2);
            hc.Hit(3);
            
            Assert.Equal(3, hc.GetHits(4));
            
            hc.Hit(300);
            Assert.Equal(4, hc.GetHits(300));
            
            hc.Hit(301);
            Assert.Equal(4, hc.GetHits(301));
            Assert.Equal(0, hc.GetHits(1466000001));
        }
    }
}