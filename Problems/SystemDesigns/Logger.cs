using System.Collections.Generic;

namespace Problems.SystemDesigns
{
    //https://leetcode.com/problems/logger-rate-limiter/
    public class Logger
    {

        private readonly Dictionary<string, int> _lastMessageTime;
        /** Initialize your data structure here. */
        public Logger() {
            _lastMessageTime = new Dictionary<string, int>(1024);
        }
    
        /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
        public bool ShouldPrintMessage(int timestamp, string message) {
            if (_lastMessageTime.TryGetValue(message, out var lastTime) && (timestamp - lastTime < 10))
            {
                return false;
            }

            _lastMessageTime[message] = timestamp;
            return true;
        }
    }
}