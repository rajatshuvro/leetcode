using System.Collections.Generic;
using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class LinkedListRandomNodeTester
    {
        //[Theory]
        //[InlineData(new[] { 10, 100, 100, 20, 20, 100 })]
        //[InlineData(new[] { 10, 1, 10, 20, 100 })]
        //public void TestRandomness(int[] numbers)
        //{
        //    var inputFreq = GetFrequencies(numbers);
        //    var linkedList = new LinkedList();
        //    foreach (var number in numbers)
        //    {
        //        linkedList.Add(new ListNode(number));
        //    }

        //    var randomNodeGenerator = new LinkedListRandomNode(linkedList.First);
        //    var randomNodeFrequencies = GetRandomNodeFreq(randomNodeGenerator, numbers.Length);

        //    Assert.Equal(inputFreq.Count, randomNodeFrequencies.Count);
        //    foreach (var (number, frequency) in inputFreq)
        //    {
        //        var observedFreq = randomNodeFrequencies[number];
        //        var freqRatio = frequency > observedFreq ? observedFreq / frequency : frequency / observedFreq;
        //        Assert.True(freqRatio > 0.95);
        //    }
        //}

        private Dictionary<int, double> GetRandomNodeFreq(LinkedListRandomNode randomNodeGenerator, int count)
        {
            var array = new int[count * 100];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNodeGenerator.GetRandom();
            }

            return GetFrequencies(array);
        }

        private Dictionary<int, double> GetFrequencies(int[] numbers)
        {
            var counts = new Dictionary<int, double>();

            foreach (var number in numbers)
            {
                if (counts.ContainsKey(number))
                    counts[number] += 1;
                else counts[number] = 1;
            }

            var frequencies = new Dictionary<int, double>();
            foreach (var (number, count) in counts)
            {
                frequencies[number] = count / numbers.Length;
            }

            return frequencies;
        }
    }
}