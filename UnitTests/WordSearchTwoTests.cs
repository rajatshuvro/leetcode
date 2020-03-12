using Problems;
using Xunit;

namespace UnitTests
{
    public class WordSearchTwoTests
    {
        [Fact]
        public void Case0()
        {
            var gridSearcher = new WordSearchTwo();

            var grid = new char[4][];
            grid[0] = new[] {'o', 'a', 'a', 'n'};
            grid[1] = new[] {'e','t','a','e'};
            grid[2] = new[] {'i','h','k','r'};
            grid[3] = new[] {'i','f','l','v'};
            
            Assert.Equal(new string[] {"oath","eat"}, gridSearcher.FindWords(grid, new []{"oath","pea","eat","rain"}));

        }
        
        [Fact]
        public void Case1()
        {
            var gridSearcher = new WordSearchTwo();

            var grid = new char[1][];
            grid[0] = new[] {'a'};
            
            
            Assert.Equal(new string[] {"a"}, gridSearcher.FindWords(grid, new []{"a"}));

        }
    }
}