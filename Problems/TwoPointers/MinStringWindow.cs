using System.Collections.Generic;

namespace Problems.TwoPointers
{
    public class MinStringWindow
    {
        //https://leetcode.com/problems/minimum-window-substring/
        private Dictionary<char, int> _allCharCounts = new Dictionary<char, int>();
        private Dictionary<char, int> _windowCharCounts = new Dictionary<char, int>();
        
        public string MinWindow(string s, string t) 
        {
            foreach (var c in t)
            {
                if(_allCharCounts.ContainsKey(c)) _allCharCounts[c]++;
                else _allCharCounts.Add(c, 1);
                _windowCharCounts[c] = 0;//initializing to zeros
            }

            var minLeft = 0;
            var minRight = s.Length;
            var left = 0;
            for (var right = 0; right < s.Length; right++)
            {
                var c = s[right];
                if(!_windowCharCounts.ContainsKey(c)) continue;
                _windowCharCounts[c]++;
                while (WindowHasAllChars())
                {
                    if (right - left < minRight - minLeft)
                    {
                        minRight = right;
                        minLeft = left;
                    }
                    //advancing left (tightening the window) till one char is missing
                    c = s[left];
                    left++;
                    if(_windowCharCounts.ContainsKey(c)) _windowCharCounts[c]--;
                    
                }
            }

            return minRight < s.Length ? s.Substring(minLeft, minRight - minLeft + 1): "";
        }

        private bool WindowHasAllChars()
        {
            foreach (var (c, count) in _allCharCounts)
            {
                if (_windowCharCounts[c] < count) return false;
            }

            return true;
        }
    }
}