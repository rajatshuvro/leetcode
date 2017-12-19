using System;

namespace LongestPalindromicSubsequence
{
    class LongestPalinSubLen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding length of longest palindromic subsequence!");
        }

        private int[,] _dp;

        public int LongestPalindromeSubseq(string s)
        {
            _dp = new int[2, s.Length];

            return MaxPalinSubLen(s, 0, s.Length - 1);
        }

        private int MaxPalinSubLen(string s, int i, int j)
        {
            if (i == j) return 1;

            if (_dp[i, j] != 0) return _dp[i, j];

            if (s[i] == s[j])
                _dp[i, j] = MaxPalinSubLen(s, i + 1, j - 1) + 2;
            else
                _dp[i, j] = Math.Max(MaxPalinSubLen(s, i + 1, j), MaxPalinSubLen(s, i, j - 1));

            return _dp[i, j];
        }
        
    }
}
