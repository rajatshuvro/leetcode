using DataStructures;
using Problems;
using Xunit;

namespace UnitTests
{
    public class NextLargerNodeTests
    {
        [Theory]
        [InlineData(new[] { 2 }, new[] { 0 })]
        [InlineData(new []{ 2, 1, 5 }, new[] { 5, 5, 0 })]
        [InlineData(new[] { 2, 7, 4, 3, 5 }, new[] { 7, 0, 5, 5, 0 })]
        [InlineData(new[] { 1, 7, 5, 1, 9, 2, 5, 1 }, new[] { 7, 9, 9, 9, 0, 5, 0, 0 })]
        public void NextGreaterNumberTests(int[] input, int[] expectedOutput)
        {
            var greaterNumberFinder = new NextGreaterNumber();
            var linkedList = new LinkedList();
            foreach (var i in input)
            {
                linkedList.Add(new ListNode(i));
            }

            var results = greaterNumberFinder.NextLargerNodes(linkedList.First);
            Assert.Equal(expectedOutput, results);
        }
    }
}