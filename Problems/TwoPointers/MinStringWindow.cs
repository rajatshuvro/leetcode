using System.Collections.Generic;
using DataStructures;

namespace Problems.TwoPointers
{
    public class MinStringWindow
    {
        //https://leetcode.com/problems/minimum-window-substring/
        private BitMap _allCharBitMap = new BitMap();
        private BitMap _windowBitMap = new BitMap();
        
        public string MinWindow(string s, string t) 
        {
            var charIndices = new Dictionary<char, int>(t.Length);
            foreach (var c in t)
            {
                charIndices[c] = -1;
                _allCharBitMap.Set(c - 'A');
            }

            var minLeft = 0;
            var minRight = s.Length;
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if(!charIndices.ContainsKey(c)) continue;
                //keep track of the latest index of a character
                charIndices[c] = i;
                _windowBitMap.Set(c - 'A');
                if (_allCharBitMap.Equals(_windowBitMap))
                {
                    //all characters have been seen once
                    var (min, max) = GetMinMax(charIndices.Values);
                    if (max - min < minRight - minLeft)
                    {
                        minRight = max;
                        minLeft = min;
                    }
                }
            }

            return minRight < s.Length ? s.Substring(minLeft, minRight - minLeft + 1): "";
        }

        private (int min, int max) GetMinMax(IEnumerable<int> values)
        {
            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var value in values)
            {
                if (value < min) min = value;
                if (max < value) max = value;
            }

            return (min, max);
        }
        
    }
}