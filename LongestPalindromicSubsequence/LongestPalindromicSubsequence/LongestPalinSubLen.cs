using System;

namespace LongestPalindromicSubsequence
{
    class LongestPalinSubLen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding length of longest palindromic subsequence!");

            var result = UnitTest("bbbab", 4);
            result &= UnitTest("babbab", 6);
            result &= UnitTest("babab", 5);
            result &= UnitTest("ba", 1);

            if (result)
                Console.WriteLine("Passed all tests");

            Console.ReadKey();
        }

        private static bool UnitTest(string s, int expedtedLen)
        {
            var sol = new LongestPalinSubLen();
            var len = sol.LongestPalindromeSubseq(s);

            if (len == expedtedLen)
            {
                Console.WriteLine($"Passed case: {s}");
                return true;
            }
            Console.WriteLine($"Failed for: {s}. Expected {expedtedLen}, observed {len}");
            return false;
        }

        private int[,] _dp;

        public int LongestPalindromeSubseq(string s)
        {
            _dp = new int[s.Length, s.Length];

            return MaxPalinSubLen(s, 0, s.Length - 1);
        }

        private int MaxPalinSubLen(string s, int i, int j)
        {
            if (i < 0 || j < 0 || i >= s.Length || j >= s.Length || i > j) return 0;
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
