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
            Assert.Equal(2, dlist.RemoveFromRightEnd().Value);
            Assert.Equal(3, dlist.Count);

        }

        [Fact]
        public void MoveRight()
        {
            var dlist = new DoublyLinkedList<int>();
            var item1 = new DoublyLinkedItem<int>(1);
            var item2 = new DoublyLinkedItem<int>(2);
            var item3 = new DoublyLinkedItem<int>(3);
            var item4 = new DoublyLinkedItem<int>(4);
            var item5 = new DoublyLinkedItem<int>(5);
            var item6 = new DoublyLinkedItem<int>(6);

            dlist.AddAtLeftEnd(item1);
            dlist.AddAtRightEnd(item2);
            dlist.AddAtRightEnd(item3);
            dlist.AddAtLeftEnd(item4);
            dlist.AddAtRightEnd(item5);
            dlist.AddAtLeftEnd(item6);

            while(item6.Right!=null && item6.Value > item6.Right.Value)
                dlist.MoveRight(item6);
            Assert.Equal(6, dlist.RemoveFromRightEnd().Value);

            while (item4.Right != null && item4.Value > item4.Right.Value)
                dlist.MoveRight(item4);
            Assert.Equal(5, item4.Right.Value);
            Assert.Equal(3, item4.Left.Value);
            Assert.Equal(1, dlist.RemoveFromLeftEnd().Value);

        }

        [Fact]
        public void MoveLeft()
        {
            var dlist = new DoublyLinkedList<int>();
            var item1 = new DoublyLinkedItem<int>(1);
            var item2 = new DoublyLinkedItem<int>(2);
            var item3 = new DoublyLinkedItem<int>(3);
            var item4 = new DoublyLinkedItem<int>(4);
            var item5 = new DoublyLinkedItem<int>(5);
            var item6 = new DoublyLinkedItem<int>(6);

            dlist.AddAtRightEnd(item3);
            dlist.AddAtRightEnd(item2);
            dlist.AddAtLeftEnd(item4);
            dlist.AddAtRightEnd(item5);
            dlist.AddAtLeftEnd(item6);
            dlist.AddAtRightEnd(item1);

            while (item1.Left != null && item1.Value < item1.Left.Value)
                dlist.MoveLeft(item1);
            Assert.Equal(1, dlist.RemoveFromLeftEnd().Value);

            while (item2.Left != null && item2.Value < item2.Left.Value)
                dlist.MoveLeft(item2);

            while (item4.Left != null && item4.Value < item4.Left.Value)
                dlist.MoveLeft(item4);
            Assert.Equal(6, item4.Right.Value);
            Assert.Equal(2, item4.Left.Value);

            Assert.Equal(2, dlist.RemoveFromLeftEnd().Value);
            Assert.Equal(4, dlist.LeftMostItem.Value);

        }
    }
}