using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class SmallestDistinctSubsequence
    {
        //https://leetcode.com/contest/weekly-contest-140/problems/smallest-subsequence-of-distinct-characters/
        //Return the lexicographically smallest subsequence of text that contains all the distinct characters of text exactly once
        public string SmallestSubsequence(string text)
        {
            return SmallestSubsequence(text, 0, new HashSet<char>());
        }

        private string SmallestSubsequence(string text, int i, HashSet<char> exclude)
        {
            string s1, s2;
            if (!exclude.Contains(text[i]))
            {
                exclude.Add(text[i]);
                s1 = text[i] + SmallestSubsequence(text, i + 1, exclude);
                exclude.Remove(text[i]);
            }
            else
            {
                s2 = SmallestSubsequence(text, i + 1, exclude);
            }

            return s1.CompareTo(s2) < 0 ? s1 : s2;

        }
    }
}