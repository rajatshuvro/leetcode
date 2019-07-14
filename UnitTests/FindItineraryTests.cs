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

        [Fact]
        public void TestCase3()
        {
            var tickets = new List<IList<string>>()
            {
                new List<string>(){ "JFK","AAA" },
                new List<string>(){ "AAA","JFK"},
                new List<string>(){ "JFK", "BBB" },
                new List<string>(){ "JFK","CCC" },
                new List<string>(){ "CCC", "JFK" }
            };

            var itineraryReconstructor = new ReconstructItinerary();
            Assert.Equal(new[] { "JFK", "AAA", "JFK", "CCC", "JFK", "BBB" }, itineraryReconstructor.FindItinerary(tickets));

        }

        [Fact]
        public void TestCase4()
        {
            var tickets = new List<IList<string>>()
            {
                new List<string>(){ "EZE","AXA" },
                new List<string>(){ "TIA","ANU"},
                new List<string>(){ "ANU","JFK" },
                new List<string>(){ "JFK","ANU" },
                new List<string>(){ "ANU", "EZE" },
                new List<string>(){ "TIA","ANU" },
                new List<string>(){ "AXA","TIA" },
                new List<string>(){ "TIA","JFK" },
                new List<string>(){ "ANU","TIA" },
                new List<string>(){ "JFK", "TIA" }
            };

            var itineraryReconstructor = new ReconstructItinerary();
            Assert.Equal(new[] { "JFK", "ANU", "EZE", "AXA", "TIA", "ANU", "JFK", "TIA", "ANU", "TIA", "JFK" }, itineraryReconstructor.FindItinerary(tickets));

        }
    }
}