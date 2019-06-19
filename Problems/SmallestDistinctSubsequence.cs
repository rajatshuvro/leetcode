using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    public class SmallestDistinctSubsequence
    {
        //https://leetcode.com/contest/weekly-contest-140/problems/smallest-subsequence-of-distinct-characters/
        //Return the lexicographically smallest subsequence of text that contains all the distinct characters of text exactly once
        private Dictionary<(int, string), string> _memoizationTable = new Dictionary<(int, string), string>();
        private string _text;
        private HashSet<char> _charSet;
        public string SmallestSubsequence(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            _text = text;

            _charSet = new HashSet<char>(text.Length);
            foreach (var c in text)
            {
                _charSet.Add(c);
            }
            return SmallestSubsequence(0);
        }

        private string SmallestSubsequence(int i)
        {
            string s1=null;
            if (_charSet.Count == 0 || i >=_text.Length) return null;
            if (i == _text.Length - 1 && _charSet.Contains(_text[i])) return _text.Substring(i);

            var sortedCharSet = GetSortedCharSet();
            if (_memoizationTable.TryGetValue((i, sortedCharSet), out var result)) return result;

            // assume char i will be the next one in the subsequence
            if (_charSet.Contains(_text[i]))
            {
                _charSet.Remove(_text[i]);
                s1 = _text[i] + SmallestSubsequence(i + 1);
                _charSet.Add(_text[i]);
            }
            
            var s2 = SmallestSubsequence(i + 1);
            var smallestSub = LexiCompare(s1, s2);
            if (smallestSub !=null && smallestSub.Length != _charSet.Count) smallestSub = null;

            _memoizationTable[(i, sortedCharSet)] = smallestSub;

            return smallestSub;

        }

        private string LexiCompare(string s1, string s2)
        {
            if (s1 == null) return s2;
            if (s2 == null) return s1;
            //if (s1.Length > s2.Length) return s1;
            //if (s2.Length > s1.Length) return s2;
            return string.CompareOrdinal(s1, s2) < 0 ? s1 : s2;
        }

        private string GetSortedCharSet()
        {
            var chars = new StringBuilder();
            foreach (var c in _charSet.OrderBy(x => x))
            {
                chars.Append(c);
            }

            return chars.ToString();
        }
    }
}