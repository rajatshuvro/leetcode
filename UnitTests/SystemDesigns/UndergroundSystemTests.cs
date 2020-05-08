using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class UndergroundSystemTests
    {
        [Fact]
        /*
         * ["UndergroundSystem","checkIn","checkIn","checkIn","checkOut","checkOut","checkOut","getAverageTime","getAverageTime","checkIn","getAverageTime","checkOut","getAverageTime"]
[[],[45,"Leyton",3],[32,"Paradise",8],[27,"Leyton",10],[45,"Waterloo",15],[27,"Waterloo",20],[32,"Cambridge",22],["Paradise","Cambridge"],["Leyton","Waterloo"],[10,"Leyton",24],["Leyton","Waterloo"],[10,"Waterloo",38],["Leyton","Waterloo"]]
[null,null,null,null,null,null,null,14.00000,11.00000,null,11.00000,null,12.00000]

         */
        public void Case0()
        {
            var subway = new UndergroundSystem();
            
            subway.CheckIn(45,"Leyton",3);
            subway.CheckIn(32,"Paradise",8);
            subway.CheckIn(27,"Leyton",10);
            
            subway.CheckOut(45,"Waterloo",15);
            subway.CheckOut(27,"Waterloo",20);
            subway.CheckOut(32,"Cambridge",22);
            
            Assert.Equal(14, subway.GetAverageTime("Paradise","Cambridge"));
            Assert.Equal(11, subway.GetAverageTime("Leyton","Waterloo"));
            
            subway.CheckIn(10,"Leyton",24);

            Assert.Equal(11, subway.GetAverageTime("Leyton","Waterloo"));
            subway.CheckOut(10,"Waterloo",38);
            
            Assert.Equal(12, subway.GetAverageTime("Leyton","Waterloo"));

        }
    }
}