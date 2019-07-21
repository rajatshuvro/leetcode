
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class TaskScheduler
    {
        //https://leetcode.com/problems/task-scheduler/
        private LinkedList<char> _jobList;
        private Dictionary<char, int> _lastExecuted;
        private StringBuilder _sb;

        public int LeastInterval(char[] tasks, int n)
        {
            var coolingInterval = n;
            _sb = new StringBuilder();
            _jobList = new LinkedList<char>(tasks);
            _lastExecuted = new Dictionary<char, int>();

            foreach (char task in tasks)
            {
                _lastExecuted[task] = -1;
            }

            var time = 0;
            while (_jobList.Count > 0)
            {
                time++;
                
                var candidateNode = GetNextCandidate(time, coolingInterval);
                if (candidateNode == null)
                {
                    _sb.Append('-');
                    continue;
                }

                _lastExecuted[candidateNode.Value] = time;
                _sb.Append(candidateNode.Value);
                _jobList.Remove(candidateNode);

            }

            return time;
        }

        private LinkedListNode<char> GetNextCandidate(int time, int coolingInterval)
        {
            var candidateNode = _jobList.First;
            while (candidateNode != null)
            {
                var candidate = candidateNode.Value;
                if (_lastExecuted[candidate] == -1 || _lastExecuted[candidate] < time - coolingInterval)
                    break;
                
                candidateNode = candidateNode.Next;
            }

            return candidateNode;
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}