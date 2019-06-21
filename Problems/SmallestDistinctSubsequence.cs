using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using DataStructures;

namespace Problems
{
    public class SmallestDistinctSubsequence
    {
        //https://leetcode.com/contest/weekly-contest-140/problems/smallest-subsequence-of-distinct-characters/
        //Return the lexicographically smallest subsequence of text that contains all the distinct characters of text exactly once
        private readonly Dictionary<(int, int), string> _memoizationTable = new Dictionary<(int, int), string>();
        private string _text;
        private readonly BitMap _map = new BitMap();


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

            if (i == _text.Length - 1 && _map.IsSet(_text[i] - 'a')) return $"{_text[i]}";
            if (_memoizationTable.TryGetValue((i, _map.GetHashCode()), out var result)) return result;

            var s2 = SmallestSubsequence(i + 1);
            // assume char i will be the next one in the subsequence
            if (_map.IsSet(_text[i] - 'a'))
            {
                _map.Clear(_text[i] - 'a');
                s1 = _text[i] + SmallestSubsequence(i + 1);
                _map.Set(_text[i] - 'a');
            }

            var smallestSub = LexiCompare(s1, s2);
            if (smallestSub != null && smallestSub.Length != _map.Count) smallestSub = null;

            _memoizationTable[(i, _map.GetHashCode())] = smallestSub;

            return smallestSub;

        }

        private string LexiCompare(string s1, string s2)
        {
            if (s1 == null) return s2;
            if (s2 == null) return s1;
            return string.CompareOrdinal(s1, s2) < 0 ? s1 : s2;
        }

        //public class Positions<T> : IComparable<Positions<T>> where T : IComparable<T>
        //{
        //    public readonly T Key;
        //    private readonly List<int> _positions;
        //    public Positions(T key, int position)
        //    {
        //        Key = key;
        //        _positions = new List<int>() { position };
        //    }

        //    public void Add(int i)
        //    {
        //        _positions.Add(i);
        //    }

        //    public int Search(int pos)
        //    {
        //        var index = _positions.BinarySearch(pos);
        //        if (index >= 0) return pos;
        //        index = ~index;
        //        //return the position > pos
        //        if (index < _positions.Count) return _positions[index];
        //        //return the largest position < pos
        //        return _positions[_positions.Count - 1];
        //    }

        //    public int CompareTo(Positions<T> other)
        //    {
        //        return Key.CompareTo(other.Key);
        //    }
        //}

        //public string SmallestSubsequence(string text)
        //{
        //    var charPositions = new Dictionary<char, Positions<char>>();

        //    for (var i = 0; i < text.Length; i++)
        //    {
        //        if (charPositions.TryGetValue(text[i], out var positions)) positions.Add(i);
        //        else charPositions[text[i]] = new Positions<char>(text[i], i);
        //    }

        //    var charLine = new char[text.Length];
        //    Array.Fill(charLine, ' ');

        //    //at each point we pull out the smallest char available and place it in the line
        //    var charHeap = new MinHeap<Positions<char>>(new Positions<char>(' ', -1));
        //    foreach (var positions in charPositions.Values)
        //    {
        //        charHeap.Add(positions);
        //    }

        //    var lastAssignedPosition = -1;
        //    while (charHeap.Count > 0)
        //    {
        //        var positions = charHeap.ExtractMin();
        //        lastAssignedPosition = positions.Search(lastAssignedPosition);
        //        charLine[lastAssignedPosition] = positions.Key;
        //    }

        //    var sb = new StringBuilder();
        //    foreach (var c in charLine)
        //    {
        //        if (c == ' ') continue;
        //        sb.Append(c);
        //    }

        //    return sb.ToString();
        //}
    }
}