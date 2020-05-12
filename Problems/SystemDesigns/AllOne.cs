using System.Collections.Generic;
using System.Linq;

namespace Problems.SystemDesigns
{
    public class AllOne
    {
        private List<HashSet<string>> _hashList;
        private Dictionary<string, int> _keyCounts;
        public AllOne() {
            _hashList = new List<HashSet<string>>();
            _keyCounts = new Dictionary<string, int>();
        }
    
        /** Inserts a new key <Key> with value 1. Or increments an existing key by 1. */
        public void Inc(string key)
        {
            if (!_keyCounts.ContainsKey(key))
            {
                _keyCounts[key] = 1;
                if(_hashList.Count < 1) _hashList.Add(new HashSet<string>());
                _hashList[0].Add(key);
            }
            else
            {
                var count = _keyCounts[key];
                _keyCounts[key]++;
                _hashList[count - 1].Remove(key);
                count++;
                if(_hashList.Count < count) _hashList.Add(new HashSet<string>());
                _hashList[count-1].Add(key);
            }
        }
    
        /** Decrements an existing key by 1. If Key's value is 1, remove it from the data structure. */
        public void Dec(string key)
        {
            if (!_keyCounts.ContainsKey(key)) return;
            
            var count = _keyCounts[key];
            if (count == 1)
            {
                _keyCounts.Remove(key);
                _hashList[0].Remove(key);
                return;
            }

            _hashList[count - 1].Remove(key);
            
            _keyCounts[key]--;
            count--;//new decremented count;
            _hashList[count - 1].Add(key);
        }
    
        /** Returns one of the keys with maximal value. */
        public string GetMaxKey()
        {
            if (_hashList.Count == 0) return "";
            var i = _hashList.Count -1;
            while (i >=0)
            {
                if (_hashList[i].Count > 0) return _hashList[i].First();
                i--;
            }

            return "";
        }
    
        /** Returns one of the keys with Minimal value. */
        public string GetMinKey() {
            if (_hashList.Count == 0) return "";
            var i = 0;
            while (i < _hashList.Count)
            {
                if (_hashList[i].Count > 0) return _hashList[i].First();
                i++;
            }

            return "";
        }
    }
}