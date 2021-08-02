using System.Collections.Generic;
using System.Reflection;

namespace Problems.StringProblems
{
    //https://leetcode.com/problems/isomorphic-strings/
    public class IsomorphicString
    {
        public static bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var forwardMap = new Dictionary<char, char>(s.Length);
            var reverseMap = new Dictionary<char, char>(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                var x = s[i];
                var y = t[i];
                if (!forwardMap.ContainsKey(x) && !reverseMap.ContainsKey(y))
                {
                    forwardMap[x] = y;
                    reverseMap[y] = x;
                    continue;
                }

                if (!forwardMap.ContainsKey(x) || y != forwardMap[x]) return false;
            }
            return true;
        }
    }
}