using System.Collections.Generic;

namespace Problems.StringProblems
{
    public class LastSubString
    {
        //https://leetcode.com/problems/last-substring-in-lexicographical-order/
        public string LastSubstring(string s) {
            var indexByChar = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (!indexByChar.ContainsKey(c))
                {
                    indexByChar[c] = i;
                    continue;
                }
                if(i>0 && s[i-1]==s[i]) continue;
                
                if(CompareSuffixAt(s, indexByChar[c], i) > 0) continue;
                indexByChar[c] = i;
            }

            var maxChar = ' ';
            var lastIndex = -1;
            foreach (var (c, i) in indexByChar)
            {
                if (maxChar < c)
                {
                    maxChar = c;
                    lastIndex = i;
                }
            }

            return s.Substring(lastIndex);
        }

        private int CompareSuffixAt(string s, int i, int j)
        {
            while (i < s.Length && j < s.Length)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j++;
                    continue;
                }

                return s[i].CompareTo(s[j]);
            }

            return 1;
        }
    }
}