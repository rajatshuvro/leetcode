using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Problems
{
    public class SmallestDistinctSubsequence
    {
        //https://leetcode.com/contest/weekly-contest-140/problems/smallest-subsequence-of-distinct-characters/
        //Return the lexicographically smallest subsequence of text that contains all the distinct characters of text exactly once
        private readonly Dictionary<(int, int), string> _memoizationTable = new Dictionary<(int, int), string>();
        private string _text;
        private readonly BitMap _map = new BitMap(64);


        public string SmallestSubsequence(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            _text = text;

            foreach (var c in text)
            {
                _map.Set(c - 'a');
            }

            return SmallestSubsequence(0);
        }


        private string SmallestSubsequence(int i)
        {
            string s1 = null;
            if (_map.Count == 0 || i >= _text.Length) return null;
            if (_memoizationTable.TryGetValue((i, _map.GetHashCode()), out var result))
                return result;

            if (_map.Count == 1)
            {
                var index = _map.GetAllSetPositions().First();
                var c = (char)('a' + index);
                if (_text.IndexOf(c, i) >= 0) return c.ToString();
                return null;
            }

            //the _text.substring(i) must contain all the items in the hash map
            if (IsMissingRequiredChars(i))
                return null;
            if (i == _text.Length - 1 && _map.IsSet(_text[i] - 'a'))
                return $"{_text[i]}";
            
            
            //assume char i will not be in the optimal subsequence
            var s2 = SmallestSubsequence(i + 1);
            _memoizationTable[(i+1, _map.GetHashCode())] = s2;
            // assume char i will be in the optimal subsequence
            if (_map.IsSet(_text[i] - 'a'))
            {
                _map.Reset(_text[i] - 'a');
                var ss = SmallestSubsequence(i + 1);
                _memoizationTable[(i + 1, _map.GetHashCode())] = ss;
                s1 = _text[i] + ss;
                _map.Set(_text[i] - 'a');
            }

            var smallestSub = LexiCompare(s1, s2);

            _memoizationTable[(i, _map.GetHashCode())] = smallestSub;

            return smallestSub;

        }

        private bool IsMissingRequiredChars(int i)
        {
            var map = new BitMap(64);
            for (int j = i; j < _text.Length; j++)
                map.Set(_text[j] - 'a');

            foreach (var position in _map.GetAllSetPositions())
            {
                if (!map.IsSet(position)) return true;
            }

            return false;
        }

        private string LexiCompare(string s1, string s2)
        {
            if (s1 == null) return s2;
            if (s2 == null) return s1;
            if (s1.Length != s2.Length) return null;
            return string.CompareOrdinal(s1, s2) < 0 ? s1 : s2;
        }

        
    }
}