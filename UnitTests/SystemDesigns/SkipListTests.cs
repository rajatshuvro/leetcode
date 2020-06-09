using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class SkipListTests
    {
        [Fact]
        public void OneLevel()
        {
            var list = new Skiplist();
            list.Add(1);
            list.Add(5);
            list.Add(10);
            
            Assert.True(list.Search(1));
            Assert.True(list.Search(5));
            Assert.True(list.Search(10));
        }
        
        [Fact]
        public void TwoLevels()
        {
            var list = new Skiplist();
            list.Add(1);
            list.Add(2);
            list.Add(5);
            list.Add(7);
            //next add should trigger new level
            list.Add(10);
            list.Add(12);
            
            Assert.True(list.Search(1));
            Assert.True(list.Search(7));
            Assert.True(list.Search(12));
        }
    }
}