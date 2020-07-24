using System;
using System.Collections.Generic;
using System.Text;
using DataStructures;

namespace Problems.SystemDesigns
{
    //https://leetcode.com/problems/design-log-storage-system/

    public class Log: IComparable<Log>, IComparable<string>
    {
        public readonly int Id;
        public readonly string TimeStamp;

        public Log(int id, string timeStamp)
        {
            Id = id;
            TimeStamp = timeStamp;
        }

        public int CompareTo(string other)
        {
            return string.Compare(TimeStamp, other, StringComparison.Ordinal);
        }

        public int CompareTo(Log other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(TimeStamp, other.TimeStamp, StringComparison.Ordinal);
        }
    }

    public static class LogSystemUtilities
    {
        public static int GetIndex(string timeComponent)
        {
            //Year:Month:Day:Hour:Minute:Second
            switch (timeComponent)
            {
                case "Year":
                    return 0;
                case "Month":
                    return 1;
                case "Day":
                    return 2;
                case "Hour":
                    return 3;
                case "Minute":
                    return 4;
                case "Second":
                    return 5;
                default:
                    return -1;
                
            }
        }

        public static string GetComponentMax(int i)
        {
            //Year:Month:Day:Hour:Minute:Second
            switch (i)
            {
                case 0:
                    return "9999"; // year
                case 1:
                    return "12";// month
                case 2:
                    return "31";// day
                case 3:
                    return "23";// hour
                case 4:
                    return "59";// minute
                case 5:
                    return "59";// second
                default:
                    return null;
                
            }
        }

        public static string GetRoundDownTime(string s, string gra)
        {
            if (gra == "Second") return s;

            var i = GetIndex(gra);
            var splits = s.Split(':');

            var sb = new StringBuilder();
            for (int j = 0; j <= i; j++)
            {
                sb.Append(splits[j] + ':');
            }

            for (int j = i+1; j < splits.Length-1; j++)
            {
                sb.Append("00:");
            }

            sb.Append("00");
            return sb.ToString();
        }
        
        
        public static string GetRoundUpTime(string s, string gra)
        {
            if (gra == "Second") return s;
            var i = GetIndex(gra);
            var splits = s.Split(':');

            var sb = new StringBuilder();
            for (int j = 0; j <= i; j++)
            {
                sb.Append(splits[j] + ':');
            }

            for (int j = i+1; j < splits.Length-1; j++)
            {
                var max = GetComponentMax(j);
                sb.Append(max+':');
            }

            sb.Append(GetComponentMax(splits.Length-1));
            return sb.ToString();
        }

    }

    public class LogSystem
    {
        private List<Log> _logs;
        private StringBuilder _sb;
        public LogSystem() {
            _logs = new List<Log>(512);
            _sb = new StringBuilder();
        }
    
        public void Put(int id, string timestamp) {
            _logs.Add(new Log(id, timestamp));
        }

        
        public IList<int> Retrieve(string s, string e, string gra)
        {
            var startTime = LogSystemUtilities.GetRoundDownTime(s, gra);
            var endTime = LogSystemUtilities.GetRoundUpTime(e, gra);
            _logs.Sort();
            
            var logIds = new List<int>();
            
            var startLog = new Log(-1, startTime);
            var i = _logs.BinarySearch(startLog);
            if (i < 0) i = ~i;
            for (int j = i; j < _logs.Count; j++)
            {
                if (string.Compare(_logs[j].TimeStamp, endTime, StringComparison.Ordinal) > 0) break;
                logIds.Add(_logs[j].Id);
            }
            return logIds;
        }
        
    }
}