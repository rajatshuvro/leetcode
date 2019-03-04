using System.Linq;
using DataStructures;

namespace Problems
{
    public class MeetingRoomsTwo
    {
        //https://leetcode.com/problems/meeting-rooms-ii/
        // Given an array of meeting time intervals consisting of start and end times [[s1,e1],[s2,e2],...] (si < ei), find the minimum number of conference rooms required.
        public int MinMeetingRooms(Interval[] intervals)
        {
            intervals = intervals.OrderBy(x => x.start).ToArray();
            var starts = intervals.Select(x => x.start).ToList();
            
            var ends = intervals.Select(x => x.end).ToList();
            ends.Sort();

            foreach (Interval meeting in intervals)
            {
                
            }
            return 1;
        }
    }
}