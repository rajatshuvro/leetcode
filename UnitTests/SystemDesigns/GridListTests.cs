using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class GridListTests
    {
        [Fact]
        public void GridList_add()
        {
            var list = new GridList<int>();
            list.Add(1);
            list.Add(5);
            list.Add(10);

            Assert.Equal(3, list.Count);
            GridNode<int> node;
            Assert.True(list.TrySearch(1, out node));
            Assert.Equal(1, node.Value);
            
            Assert.False(list.TrySearch(0, out node));
            Assert.Null(node);
            
            Assert.True(list.TrySearch(5, out node));
            Assert.Equal(5, node.Value);
            
            Assert.False(list.TrySearch(3, out node));
            Assert.Equal(1, node.Value);
            
            Assert.False(list.TrySearch(12, out node));
            Assert.Equal(10, node.Value);

            //testing add from a given node
            list.TrySearch(5, out var node5);
            list.Add(7, node5);
            Assert.True(list.TrySearch(7, out node));
            Assert.Equal(7, node.Value);
            
            //testing find from a given node
            Assert.True(list.TrySearch(7, out node, node5));
            Assert.Equal(7, node.Value);
        }
        
        [Fact]
        public void GridList_remove()
        {
            var list = new GridList<int>();
            list.Add(1);
            list.Add(5);
            list.Add(10);
            list.Add(12);
            list.Add(15);
            list.Add(19);
            list.Add(20);

            Assert.Equal(7, list.Count);
            Assert.True(list.Erase(12));
            GridNode<int> node;
            Assert.False(list.TrySearch(12, out node));
            Assert.Equal(10, node.Value);
            
            list.TrySearch(5, out var node5);
            Assert.False(list.Erase(12, node5));
            
            list.Add(7, node5);
            Assert.True(list.TrySearch(7, out node));
            Assert.True(list.Erase(7, node5));
            
            //remove head
            Assert.True(list.Erase(1));
            Assert.False(list.TrySearch(1, out node));
            Assert.Null(node);//previous is null for first node
            Assert.True (list.TrySearch(5, out node));
            
            Assert.False (list.TrySearch(3, out node));
            Assert.Null(node);// previous is null if query is before first node
            
            //remove tail
            Assert.True(list.Erase(20));
            Assert.False(list.TrySearch(20, out node));
            Assert.True(list.TrySearch(19, out node));
            
            Assert.Equal(4, list.Count);
            //perform some add after deletion
            list.Add(3);
            Assert.True(list.TrySearch(3, out node));
            list.Add(21);
            Assert.True(list.TrySearch(21, out node));
            Assert.Equal(6, list.Count);
        }
    }
}