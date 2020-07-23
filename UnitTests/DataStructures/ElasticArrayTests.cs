using System;
using DataStructures;
using Xunit;

namespace UnitTests.DataStructures
{
    public class ElasticArrayTests
    {
        [Fact]
        public void Add_tests()
        {
            var size = 100;
            var array = new ElasticArray<int>(size);
            for (int i = 0; i < size; i++)
            {
                array.Add(i*2);
            }
            
            Assert.Equal(size, array.Count);
            Assert.Equal(2*5, array[5]);
            array[5] = 5;
            Assert.Equal(5, array[5]);
            
            for (int i = 0; i < size/2; i++)
            {
                array.Add(i*3);
            }
            
            Assert.Equal(size+size/2, array.Count);
            Assert.Equal(2*size, array.Size);
            
        }

        [Fact]
        public void IndexOutOfBound()
        {
            var size = 100;
            var array = new ElasticArray<int>(size);
            for (int i = 0; i < size/2; i++)
            {
                array.Add(i*2);
            }

            Assert.Throws<IndexOutOfRangeException>(() => array[size / 2 + 1]);
            Assert.Throws<IndexOutOfRangeException>(() => array[-1]);
            Assert.Throws<IndexOutOfRangeException>(() => array[size / 2 + 1]=33);
            Assert.Throws<IndexOutOfRangeException>(() => array[-1]=33);
        }

        [Fact]
        public void Sort_search()
        {
            var rand = new Random();
            var size = 100;
            var array = new ElasticArray<int>(size);
            for (int i = 0; i < size; i++)
            {
                array.Add(rand.Next());
            }
            
            array.Sort();
            for (int i = 1; i < size; i++)
            {
                Assert.True(array[i-1]<=array[i]);
            }

            var x = array[5];
            Assert.Equal(5, array.BinarySearch(x));
        }
    }
}