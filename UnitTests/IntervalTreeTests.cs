using System.Collections.Generic;
using System.Linq;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class IntervalTreeTests
    {
        private Interval[] _intervalSetOne=new []
        {
            new Interval(15,20),
            new Interval(10, 30),
            new Interval(5, 20),
            new Interval(12, 15),
            new Interval(17, 19),
            new Interval(30, 40)
        };
        
        [Fact]
        public void Adding_intervals()
        {
            var tree = new IntervalTree();


            tree.Add(_intervalSetOne[0]);
            Assert.Equal(15, tree.GetRange().Begin);
            Assert.Equal(20, tree.GetRange().End);

            tree.Add(_intervalSetOne[1]);
            Assert.Equal(10, tree.GetRange().Begin);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(_intervalSetOne[2]);
            Assert.Equal(5, tree.GetRange().Begin);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(_intervalSetOne[3]);
            Assert.Equal(5, tree.GetRange().Begin);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(_intervalSetOne[4]);
            Assert.Equal(5, tree.GetRange().Begin);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(_intervalSetOne[5]);
            Assert.Equal(5, tree.GetRange().Begin);
            Assert.Equal(40, tree.GetRange().End);


        }

        [Fact]
        public void OverlapsAnyTests()
        {
            var intervals = new List<Interval>(_intervalSetOne);
            intervals.Sort();
            var tree = IntervalTree.Build(intervals);
            
            Assert.True(tree.OverlapsAny(5,13));
            Assert.False(tree.OverlapsAny(0,4));
        }

        [Fact]
        public void GetOverlappingIntervals()
        {
            var intervals = new List<Interval>(_intervalSetOne);
            intervals.Sort();
            var tree = IntervalTree.Build(intervals);


            var expectedIntervals = new Interval[]
            {
                _intervalSetOne[2], _intervalSetOne[1], _intervalSetOne[3]
            };
            
            
            var observedIntervals = tree.GetOverlappingIntervals(new Interval(5, 13)).OrderBy(x => x.Begin);
            Assert.Equal(expectedIntervals, observedIntervals);
        }
        
        [Fact]
        public void No_overlap()
        {
            var tree = new IntervalTree();

            var interval1 = new Interval(15, 20);
            var interval2 = new Interval(10, 21);
            var interval3 = new Interval(5, 20);
            var interval4 = new Interval(12, 15);
            var interval5 = new Interval(17, 19);
            var interval6 = new Interval(30, 40);


            tree.Add(interval1);
            tree.Add(interval2);
            tree.Add(interval3);
            tree.Add(interval4);
            tree.Add(interval5);
            tree.Add(interval6);

            var observedIntervals = tree.GetOverlappingIntervals(new Interval(22, 29));
            Assert.Empty(observedIntervals);
        }
        
        
    }
}