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
        public void Get_test()
        {
            var list = new GridList<int>();
            list.Add(1);
            list.Add(5);
            list.Add(10);
            list.Add(12);
            list.Add(15);
            list.Add(19);
            list.Add(20);

            Assert.NotNull(list.Get(0));
            Assert.Equal(5, list.Get(1).Value);
            Assert.Equal(20, list.Get(6).Value);
            Assert.Null(list.Get(7));
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
            Assert.True(list.TryErase(12, out var previous)); 
            Assert.NotNull(previous);
            Assert.Equal(10, previous.Value);
            
            Assert.False(list.TrySearch(12, out previous));
            Assert.Equal(10, previous.Value);
            
            list.TrySearch(5, out var node5);
            //deleting 12 again should return false
            Assert.False(list.TryErase(12, out previous, node5)); 
            Assert.NotNull(previous);
            Assert.Equal(10, previous.Value);
            
            list.Add(7, node5);
            Assert.True(list.TrySearch(7, out previous));
            //deleting 12 again should return false
            Assert.False(list.TryErase(12, out previous, node5)); 
            Assert.NotNull(previous);
            Assert.Equal(10, previous.Value);

            //remove head
            Assert.True(list.TryErase(1, out previous)); 
            Assert.Null(previous);
            Assert.False(list.TrySearch(1, out previous));
            Assert.Null(previous);//previous is null for first node
            Assert.True (list.TrySearch(5, out previous));
            
            Assert.False (list.TrySearch(3, out previous));
            Assert.Null(previous);// previous is null if query is before first node
            
            //remove tail
            Assert.True(list.TryErase(20, out previous));
            Assert.NotNull(previous);
            Assert.Equal(19, previous.Value);
            Assert.False(list.TrySearch(20, out previous));
            Assert.True(list.TrySearch(19, out previous));
            
            Assert.Equal(5, list.Count);
            //perform some add after deletion
            list.Add(3);
            Assert.True(list.TrySearch(3, out previous));
            list.Add(21);
            Assert.True(list.TrySearch(21, out previous));
            Assert.Equal(7, list.Count);
        }
    }
}