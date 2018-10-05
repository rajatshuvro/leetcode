using DataStructures;
using Xunit;

namespace UnitTests
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void BasicAddItems()
        {
            var dlist = new DoublyLinkedList<int>();

            dlist.AddAtLeftEnd(new DoublyLinkedItem<int>(1));
            dlist.AddAtRightEnd(new DoublyLinkedItem<int>(2));

            Assert.Equal(2, dlist.Count);
            Assert.Equal(1, dlist.RemoveFromLeftEnd().Value);

            dlist.AddAtRightEnd(new DoublyLinkedItem<int>(3));
            Assert.Equal(2, dlist.RemoveFromLeftEnd().Value);

            dlist.AddAtLeftEnd(new DoublyLinkedItem<int>(1));
            dlist.AddAtRightEnd(new DoublyLinkedItem<int>(2));
            dlist.AddAtLeftEnd(new DoublyLinkedItem<int>(4));
            dlist.AddAtRightEnd(new DoublyLinkedItem<int>(5));

            Assert.Equal(5, dlist.RemoveFromRightEnd().Value);
            Assert.Equal(4, dlist.RemoveFromRightEnd().Value);
            Assert.Equal(3, dlist.Count);

        }
    }
}