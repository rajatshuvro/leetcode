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
            switch (n)
            {
                case 0:
                case 1:
                    return n;
                case 2:
                    return s[0] == s[1] ? 2 : 1;
            }

            var dpArray = InitializeDpMemory(s);
            int k;
            int dpIndex;

            for (k = 2; k < n; k++)
            {
                dpIndex = k;

                for (var i = 0; i < n - k; i++)
                {
                    var j = i + k;
                    if (s[i] == s[j])
                    {
                        dpArray[k%3, i] = GetDpValue(dpArray, (k-2) %3, i + 1, j) + 2; // dp[i][j]= dp[i+1][j-1]+2
                    }

                    else
                    {
                        // dp[i,j]= max (dp[i+1, j], dp[i, j-1]
                        dpArray[k%3, i] = Math.Max(GetDpValue(dpArray, (k - 1) % 3, i+1, j), GetDpValue(dpArray, (k - 1) % 3, i , j));
                        
                    }
                }
                
            }
            return dpArray[(k-1)%3, 0];
        }

        private int GetDpValue(int[,] dpArray, int dpIndex, int i, int j)
        {
            return i > j ? 0 : dpArray[dpIndex, i];
        }

        private static int[,] InitializeDpMemory(string s)
        {
            var n = s.Length;
            var dpArrays = new int[3, n];
            for (var i = 0; i < n; i++)
            {
                // by definition, the diagonal elements are all 1, since palindrome of a subsequence of length 1 is 1.
                dpArrays[0, i] = 1;
            }

            for (var i = 0; i < n - 1; i++)
            {
                // by definition, the diagonal elements are all 1, since palindrome of a subsequence of length 1 is 1.
                dpArrays[1, i] = s[i] == s[i + 1] ? 2 : 1;
            }

            return dpArrays;
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
