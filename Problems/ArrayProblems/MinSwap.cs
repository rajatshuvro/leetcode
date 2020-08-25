using System;
using System.Collections.Generic;

namespace Problems.ArrayProblems
{
    //https://www.hackerrank.com/challenges/minimum-swaps-2/problem
    public class MinSwap
    {
        public static int minimumSwaps(int[] arr)
        {
            var swaps = 0;
            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    while (arr[i]-1 !=  i)
                    {
                        isSorted = false;
                        swaps++;
                        Algorithms.ArrayUtils.Swap(arr, i, arr[i]-1);
                    }
                }
            }

            return swaps;
        }

        
    }
}