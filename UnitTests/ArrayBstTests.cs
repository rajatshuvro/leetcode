﻿using System;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class ArrayBstTests
    {
        [Fact]
        public void Add_and_find()
        {
            var bst = new ArrayBst<int>(int.MinValue);

            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(1);
            bst.Add(4);
            bst.Add(6);
            bst.Add(9);
            bst.Add(7);

            Assert.True(bst.Find(1));
            Assert.True(bst.Find(3));
            Assert.True(bst.Find(6));
            Assert.True(bst.Find(9));
            Assert.True(bst.Find(7));

            Assert.False(bst.Find(0));
            Assert.False(bst.Find(10));

        }

        [Fact]
        public void Add_more_than_size()
        {
            var bst = new ArrayBst<int>(int.MinValue, 8);

            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(1);
            bst.Add(4);
            bst.Add(6);
            bst.Add(9);
            bst.Add(7);

            //now we will need a re-allocation
            bst.Add(2);
            bst.Add(10);

            Assert.True(bst.Find(2));
            Assert.True(bst.Find(10));

        }

        [Fact]
        public void Remove_leafs()
        {
            var bst = new ArrayBst<int>(int.MinValue, 16);

            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(1);
            bst.Add(4);
            bst.Add(6);
            bst.Add(9);
            bst.Add(7);

            bst.Remove(1);
            Assert.False(bst.Find(1));

            bst.Remove(9);
            Assert.False(bst.Find(9));

        }
        [Fact]
        public void Remove_internal_node()
        {
            var bst = new ArrayBst<int>(int.MinValue, 16);

            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(1);
            bst.Add(4);
            bst.Add(6);
            bst.Add(9);
            bst.Add(7);

            bst.Remove(8);
            Assert.False(bst.Find(8));
            Assert.True(bst.Find(6));

            bst.Remove(3);
            Assert.False(bst.Find(3));
            Assert.True(bst.Find(1));

        }

        [Fact]
        public void Remove_root()
        {
            var bst = new ArrayBst<int>(int.MinValue, 16);

            bst.Add(5);
            bst.Add(3);
            bst.Add(8);
            bst.Add(1);
            bst.Add(4);
            bst.Add(6);
            bst.Add(9);
            bst.Add(7);

            bst.Remove(5);
            Assert.False(bst.Find(5));
            Assert.True(bst.Find(6));

            Assert.True(bst.Find(1));

        }

        [Theory]
        [InlineData(new[] {5,3,8,1,4,2,6,9,7 })]
        [InlineData(new[] { 25, 3, 18, 12, 44, 22, 36, 19, 27 })]
        public void GetSortedItems(int[] items)
        {
            var bst = new ArrayBst<int>(int.MinValue, items.Length*2);

            foreach (var item in items)
            {
                bst.Add(item);
            }

            Array.Sort(items);
            Assert.Equal(items, bst.GetSortedItems());

        }

        [Theory]
        [InlineData(new[] { 5, 3, 8, 1, 4, 2, 6, 9, 7 })]
        [InlineData(new[] { 25, 3, 18, 12, 44, 22, 36, 19, 27 })]
        public void Rebalance(int[] items)
        {
            var bst = new ArrayBst<int>(int.MinValue, items.Length * 2);

            foreach (var item in items)
            {
                bst.Add(item);
            }

            Array.Sort(items);
            Assert.Equal(items, bst.GetSortedItems());

        }


    }
}