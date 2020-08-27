using System;

namespace Problems.ArrayProblems
{
    //https://www.hackerrank.com/challenges/new-year-chaos/problem
    public class NewYearChaos
    {
        // Complete the minimumBribes function below.
        private const int MaxSwapCount = 2;

        public static int GetBribeCount(int[] A)
        {
            if (IsTooChaotic(A)) return -1;

            var sorted = false;
            var count = 0;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < A.Length-1; i++)
                {
                    if (A[i] > A[i + 1])
                    {
                        sorted = false;
                        count++;
                        Algorithms.ArrayUtils.Swap(A, i, i+1);
                    }
                }
                
            }

            return count;
        }
        private static bool IsTooChaotic(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if ( i < A[i] - 1 && A[i] - 1 - i > MaxSwapCount) return true;
            }

            return false;
        }

        static void minimumBribes(int[] q)
        {
            var count = GetBribeCount(q);
            if(count == -1) Console.WriteLine("Too chaotic");
            else Console.WriteLine(count);
        }

        
    }
}