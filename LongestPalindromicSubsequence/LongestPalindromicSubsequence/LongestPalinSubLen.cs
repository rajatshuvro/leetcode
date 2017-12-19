using System;

namespace LongestPalindromicSubsequence
{
    class LongestPalinSubLen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding length of longest palindromic subsequence!");
        }

        public int LongestPalindromeSubseq(string s)
        {
            var dp = InitializeDpArray(s.Length);

            return MaxPalinSubLen(s, 0, s.Length - 1);
        }

        private int MaxPalinSubLen(string s, int i, int j)
        {
            if (i == j) return 1;

            if (s[i] == s[j])
                return MaxPalinSubLen(s, i + 1, j - 1) + 2;

            return Math.Max(MaxPalinSubLen(s, i + 1, j), MaxPalinSubLen(s, i, j - 1));
        }

        private int[,] InitializeDpArray(int n)
        {
            var dp = new int[2, n];

            for (var i = 0; i < n; i++)
            {
                dp[0, i] = 1;// palindrome for s[i,i] is always 1 char long by default
                dp[1, i] = 1;
            }

            return dp;
        }
    }
}
