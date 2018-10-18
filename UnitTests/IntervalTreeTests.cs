using System.Linq;
using DataStructures;
using Xunit;

namespace UnitTests
{
    public class IntervalTreeTests
    {
        [Fact]
        public void Adding_intervals()
        {
            var tree = new IntervalTree();

            var interval1 = new Interval(15,20);
            var interval2 = new Interval(10, 30);
            var interval3 = new Interval(5, 20);
            var interval4 = new Interval(12, 15);
            var interval5 = new Interval(17, 19);
            var interval6 = new Interval(30, 40);


            tree.Add(interval1);
            Assert.Equal(15, tree.GetRange().Start);
            Assert.Equal(20, tree.GetRange().End);

            tree.Add(interval2);
            Assert.Equal(10, tree.GetRange().Start);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(interval3);
            Assert.Equal(5, tree.GetRange().Start);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(interval4);
            Assert.Equal(5, tree.GetRange().Start);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(interval5);
            Assert.Equal(5, tree.GetRange().Start);
            Assert.Equal(30, tree.GetRange().End);

            tree.Add(interval6);
            Assert.Equal(5, tree.GetRange().Start);
            Assert.Equal(40, tree.GetRange().End);


        }

        [Fact]
        public void GetOverlappingIntervals()
        {
            var tree = new IntervalTree();

            var interval1 = new Interval(15, 20);
            var interval2 = new Interval(10, 30);
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

            var expectedIntervals = new Interval[]
            {
                interval3, interval2, interval4
            };
            var observedIntervals = tree.GetOverlappingIntervals(new Interval(5, 13)).OrderBy(x => x.Start);
            Assert.Equal(expectedIntervals, observedIntervals);
        }

        [Fact]
        public void GetOverlappingIntervals_boundary()
        {
            var tree = new IntervalTree();

            var interval1 = new Interval(15, 20);
            var interval2 = new Interval(10, 30);
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

            var expectedIntervals = new Interval[]
            {
                interval3, interval2
            };
            var observedIntervals = tree.GetOverlappingIntervals(new Interval(5, 12)).OrderBy(x => x.Start);
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