using System.Collections.Generic;
using System.Linq;

namespace Problems.SystemDesigns
{
    //https://leetcode.com/problems/design-underground-system/

    public class UndergroundSystem
    {

        private readonly Dictionary<int, (string, int)> _checkInsInTransit;
        private readonly Dictionary<(string, string), List<int>> _tripDurations;

        public UndergroundSystem() {
            _checkInsInTransit = new Dictionary<int, (string, int)>();
            _tripDurations = new Dictionary<(string, string), List<int>>();
        }
    
        public void CheckIn(int id, string stationName, int t) {
            _checkInsInTransit.Add(id, (stationName, t));
        }
    
        public void CheckOut(int id, string stationName, int t)
        {
            var (startStation, checkinTime) = _checkInsInTransit[id];
            if(_tripDurations.TryGetValue((startStation, stationName), out var durations)) durations.Add(t-checkinTime);
            else _tripDurations.Add((startStation, stationName), new List<int>(){t-checkinTime});

            _checkInsInTransit.Remove(id);
        }
    
        public double GetAverageTime(string startStation, string endStation)
        {
            if (_tripDurations.TryGetValue((startStation, endStation), out var durations)) return durations.Average();
            else return 0;
        }
    }
}