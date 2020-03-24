using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class KeysAndRoomTests
    {
        [Fact]
        public void Case_0()
        {
            var rooms = new List<IList<int>>()
                {new List<int>() {1}, new List<int>() {2}, new List<int>() {3}, new List<int>()};
            
            var roomVisitor = new KeysAndRooms();
            Assert.True(roomVisitor.CanVisitAllRooms(rooms));
        }
        [Fact]
        public void Case_1()
        {
            var rooms = new List<IList<int>>()
                {new List<int>() {1,3}, new List<int>() {3,0,1}, new List<int>() {2}, new List<int>(){0}};
            
            var roomVisitor = new KeysAndRooms();
            Assert.False(roomVisitor.CanVisitAllRooms(rooms));
        }
    }
}