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

    public class LogSystem
    {
        private ElasticArray<Log> _logs;
        private StringBuilder _sb;
        public LogSystem() {
            _logs = new ElasticArray<Log>(512);
            _sb = new StringBuilder();
        }
    
        public void Put(int id, string timestamp) {
            _logs.Add(new Log(id, timestamp));
        }

        private int GetIndex(string timeComponent)
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

        private string GetMax(int i)
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

        private string GetStartTime(string s, string gra)
        {
            var i = GetIndex(gra);
            var splits = s.Split(':');

            _sb.Clear();
            for (int j = 0; j <= i; j++)
            {
                _sb.Append(splits[i] + ':');
            }

            for (int j = i+1; j < splits.Length-1; j++)
            {
                _sb.Append("00:");
            }

            _sb.Append("00");
            return _sb.ToString();
        }
        
        
        private string GetEndTime(string s, string gra)
        {
            var i = GetIndex(gra);
            var splits = s.Split(':');

            _sb.Clear();
            for (int j = 0; j <= i; j++)
            {
                _sb.Append(splits[i] + ':');
            }

            for (int j = i+1; j < splits.Length-1; j++)
            {
                var max = GetMax(j);
                _sb.Append("max"+':');
            }

            _sb.Append(GetMax(splits.Length-1));
            return _sb.ToString();
        }

        public IList<int> Retrieve(string s, string e, string gra)
        {
            var startTime = GetStartTime(s, gra);
            var endTime = GetEndTime(e, gra);
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