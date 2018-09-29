using Problems;
using Xunit;

namespace UnitTests
{
    public class MedianFinderTests
    {
        [Fact]
        public void MedianFinderBasic()
        {
            var medianFinder = new MedianFinder();

            medianFinder.AddNum(1);
            medianFinder.AddNum(2);

            Assert.Equal(1.5, medianFinder.FindMedian());

            medianFinder.AddNum(2);
            Assert.Equal(2, medianFinder.FindMedian());
            
            medianFinder.AddNum(1);
            medianFinder.AddNum(1);
            Assert.Equal(1, medianFinder.FindMedian());

        }
    }
}