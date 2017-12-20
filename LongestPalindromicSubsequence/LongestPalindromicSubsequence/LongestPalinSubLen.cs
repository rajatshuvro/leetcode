using System;

namespace LongestPalindromicSubsequence
{
    class LongestPalinSubLen
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding length of longest palindromic subsequence!");

            var result = UnitTest("bbbab", 4);

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

        //public int LongestPalindromeSubseq(string s)
        //{
        //    _dp = new int[s.Length, s.Length];

        //    return MaxPalinSubLen(s, 0, s.Length - 1);
        //}

        //memory efficient O(n) iterative solution
        //we will move along the diagonal of the nxn matrix. In each iteration, the difference between i and j will be constant
        public int LongestPalindromeSubseq(string s)
        {
            var n = s.Length;
            if (n == 0) return 0;
            var scratches = GetScratches(n);
            var scratchIndex = 1;

            for (var k = 1; k < n; k++)
            {
                for (var i = 0; i < n - k; i++)
                {
                    var j = i + k;
                    if (s[i] == s[j])
                        scratches[1 - scratchIndex, j] = scratches[1 - scratchIndex, j] + 2; // dp[i][j]= dp[i+1][j-1]+2
                    else
                    {
                        // dp[i,j]= max (dp[i+1, j], dp[i, j-1]
                        scratches[1 - scratchIndex, j] =
                            Math.Max(scratches[scratchIndex, j], scratches[scratchIndex, j + 1]);
                    }
                }
                scratchIndex = 1 - scratchIndex;

            }
            return scratches[scratchIndex, n - 1];
        }

        
        private static int[,] GetScratches(int n)
        {
            var scratches = new int[2, n];
            for (var i = 0; i < n; i++)
                scratches[0, i] = 1;// by definition, the diagonal elements are all 1, since palindrome of a subsequence of length 1 is 1.
            return scratches;
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
