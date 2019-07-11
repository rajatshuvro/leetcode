using System.Collections.Generic;
using Problems;
using Xunit;

namespace UnitTests
{
    public class FindItineraryTests
    {
        [Fact]
        public void TestCase0()
        {
            var tickets = new List<IList<string>>()
            {
                new List<string>(){ "MUC", "LHR" },
                new List<string>(){ "JFK", "MUC" },
                new List<string>(){ "SFO", "SJC" },
                new List<string>(){ "LHR", "SFO" },

            };

            var itineraryReconstructor = new ReconstructItinerary();

            Assert.Equal(new []{ "JFK", "MUC", "LHR", "SFO", "SJC" }, itineraryReconstructor.FindItinerary(tickets));

        }

        [Fact]
        public void TestCase1()
        {
            var tickets = new List<IList<string>>()
            {
                new List<string>(){ "JFK","SFO" },
                new List<string>(){ "JFK","ATL" },
                new List<string>(){ "SFO","ATL" },
                new List<string>(){ "ATL","JFK" },
                new List<string>(){ "ATL","SFO" },
            };

            var itineraryReconstructor = new ReconstructItinerary();

            Assert.Equal(new[] { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" }, itineraryReconstructor.FindItinerary(tickets));

        }

        [Fact]
        public void TestCase2()
        {
            var tickets = new List<IList<string>>()
            {
                new List<string>(){ "JFK","KUL" },
                new List<string>(){ "JFK","NRT" },
                new List<string>(){ "NRT","JFK" }
            };

            var itineraryReconstructor = new ReconstructItinerary();
            Assert.Equal(new[] { "JFK", "NRT", "JFK", "KUL" }, itineraryReconstructor.FindItinerary(tickets));

        }
    }
}