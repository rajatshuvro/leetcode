using Problems;
using Xunit;

namespace UnitTests
{
    public class ExamRoomTests
    {
        [Fact]
        public void Seat_nominal()
        {
            var examRoom = new ExamRoom(10);

            Assert.Equal(0,examRoom.Seat());
            Assert.Equal(9, examRoom.Seat());
            Assert.Equal(4, examRoom.Seat());
            Assert.Equal(6, examRoom.Seat());
        }

        [Fact]
        public void Leave_nominal()
        {
            var examRoom = new ExamRoom(10);

            Assert.Equal(0, examRoom.Seat());
            Assert.Equal(9, examRoom.Seat());
            Assert.Equal(4, examRoom.Seat());
            Assert.Equal(6, examRoom.Seat());

            examRoom.Leave(4);
            Assert.Equal(3, examRoom.Seat());
        }

        [Fact]
        public void Leave_at_boundaries()
        {
            var examRoom = new ExamRoom(10);

            Assert.Equal(0, examRoom.Seat());
            Assert.Equal(9, examRoom.Seat());
            Assert.Equal(4, examRoom.Seat());
            Assert.Equal(6, examRoom.Seat());

            examRoom.Leave(0);
            Assert.Equal(0, examRoom.Seat());
            examRoom.Leave(9);
            examRoom.Leave(6);
            Assert.Equal(9, examRoom.Seat());
        }
    }
}