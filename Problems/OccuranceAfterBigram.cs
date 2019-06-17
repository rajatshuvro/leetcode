using System.Collections.Generic;

namespace Problems
{
    public class OccuranceAfterBigram
    {
        //https://leetcode.com/contest/weekly-contest-140/problems/occurrences-after-bigram/
        public string[] FindOcurrences(string text, string first, string second)
        {
            if (string.IsNullOrEmpty(text)|| string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second)) return null;
            var words = text.Split();
            var thirds = new List<string>();
            for (int i = 0; i < words.Length -2; i++)
            {
                if (words[i] == first && words[i + 1] == second)
                {
                    thirds.Add(words[i+2]);
                } 
            }

            return thirds.ToArray();
        }
    }
}