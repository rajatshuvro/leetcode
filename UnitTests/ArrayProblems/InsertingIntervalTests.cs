using Problems.ArrayProblems;
using Xunit;

namespace UnitTests.ArrayProblems
{
    public class InsertingIntervalTests
    {
        [Fact]
        public void Case1()
        {
            var intervals = new int[][]
            {
                new []{1, 3},
                new []{6, 9}
            };
            
            var intervalInserter = new InsertingInterval();
            var observedIntervals = intervalInserter.Insert(intervals, new[] {2, 5});
            var expectedIntervals = new int[][]
            {
                new []{1, 5},
                new []{6, 9}
            };

            Assert.Equal(expectedIntervals.Length, observedIntervals.Length);
            
            for (int i = 0; i < expectedIntervals.Length; i++)
            {
                var expected = expectedIntervals[i];
                var observed = observedIntervals[i];
                Assert.Equal(expected, observed);
            }
            
        }
        
        [Fact]
        public void Case2()
        {
            var intervals = new int[][]
            {
                new []{1, 2},
                new []{3,5},
                new []{6,7},
                new []{8,10},
                new []{12,16}
            };
            
            var intervalInserter = new InsertingInterval();
            var observedIntervals = intervalInserter.Insert(intervals, new[] {4,8});
            var expectedIntervals = new int[][]
            {
                new []{1, 2},
                new []{3, 10},
                new []{12, 16}
            };

            Assert.Equal(expectedIntervals.Length, observedIntervals.Length);
            
            for (int i = 0; i < expectedIntervals.Length; i++)
            {
                var expected = expectedIntervals[i];
                var observed = observedIntervals[i];
                Assert.Equal(expected, observed);
            }
            
        }
        
    }
}