using System.Collections.Generic;

namespace Problems.StringProblems
{
    public class LastSubString
    {
        //https://leetcode.com/problems/last-substring-in-lexicographical-order/
        public string LastSubstring(string s) {
            var lastSubstringByChar = new Dictionary<char, string>();
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (!lastSubstringByChar.ContainsKey(c))
                {
                    lastSubstringByChar[c] = s.Substring(i);
                    continue;
                }

                var subString = s.Substring(i);
                if(lastSubstringByChar[c].CompareTo(subString) > 0) continue;
                lastSubstringByChar[c] = subString;
            }

            var maxChar = ' ';
            var lastSubString = string.Empty;
            foreach (var (c, subString) in lastSubstringByChar)
            {
                if (maxChar < c)
                {
                    maxChar = c;
                    lastSubString = subString;
                }
            }

            return lastSubString;
        }
    }
}