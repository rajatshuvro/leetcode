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
            
            Assert.True(list.Erase(5));
            Assert.False(list.Search(5));
            
            list.Add(4);
            list.Add(4);
            Assert.True(list.Erase(4));
            Assert.True(list.Search(4));

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
            
            //add random order
            list.Add(9);
            list.Add(4);
            list.Add(19);
            list.Add(17);
            
            Assert.True(list.Search(17));
            Assert.True(list.Search(4));
        }
        
        [Fact]
        public void TwoLevels_Erase()
        {
            var list = new Skiplist();
            list.Add(1);
            list.Add(2);
            list.Add(5);
            list.Add(7);
            //next add should trigger new level
            list.Add(10);
            list.Add(12);
            
            //add random order
            list.Add(9);
            list.Add(4);
            list.Add(19);
            list.Add(17);

            Assert.True(list.Erase(5));
            Assert.False(list.Search(5));

            Assert.True(list.Erase(1));
            Assert.False(list.Search(1));
            
            Assert.True(list.Search(10));


        }

        [Fact]
        public void Many_levels()
        {
            var sList = new Skiplist();
            var size = 32;

            for (int i = 0; i < size; i+=2)
            {
                sList.Add(i);
            }
            for (int i = 1; i < size; i+=2)
            {
                sList.Add(i);
            }

            for (int i = 0; i < size; i++)
            {
                Assert.True(sList.Search(i));
            }

            // removing every 3rd element
            for (int i = 0; i < size; i+=3)
            {
                Assert.True(sList.Erase(i));
            }
            // make sure the remaining elements are there
            for (int i = 0; i < size; i++)
            {
                if(i%3==0) continue;
                Assert.True(sList.Search(i));
            }
        }
    }
}