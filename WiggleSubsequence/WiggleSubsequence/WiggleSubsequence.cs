using System;
using System.Collections.Generic;
using System.Linq;

namespace WiggleSubsequence
{
    public class WiggleSubsequence
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding max wiggle subsequence length");

            var s = new WiggleSubsequence();

            if (s.WiggleMaxLength(new[] {2}) != 1)
            {
                Console.WriteLine("FAIL!! test 1");
                Console.ReadKey();
                return;
            }
            if (s.WiggleMaxLength(new[] { 2, 3 }) != 2)
            {
                Console.WriteLine("FAIL!! test 2");
                Console.ReadKey();
                return;
            }
            if (s.WiggleMaxLength(new[] { 1, 7, 4, 9, 2, 5 }) != 6)
            {
                Console.WriteLine("FAIL!! test 3");
                Console.ReadKey();
                return;
            }

            if (s.WiggleMaxLength(new[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 }) != 7)
            {
                Console.WriteLine("FAIL!! test 4");
                Console.ReadKey();
                return;
            }
            if (s.WiggleMaxLength(new[] { 2, 2 }) != 1)
            {
                Console.WriteLine("FAIL!! test 6");
                Console.ReadKey();
                return;
            }


            if (s.WiggleMaxLength(new[] { 1, 1, 17, 5, 5, 10, 13, 15, 10, 5, 16, 8 }) != 7)
            {
                Console.WriteLine("FAIL!! test 5");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("HURRAY!! all tests passed");
            Console.ReadKey();
        }

        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length < 2) return nums.Length;

            var wiggleSeq = new List<int>(){nums[0]};
            //by definition the first number is always part of the subsequence
            var i = 0;
            while (i < nums.Length-1 && nums[i] == nums[i + 1])
                i++;

            if (i == nums.Length - 1) return 1;

            var lastDeltaSign = GetDeltaSign(nums[i], nums[i+1]);
            
            var lastPeak = nums[++i];

            if (lastDeltaSign != '#') wiggleSeq.Add(lastPeak);

            for (var j = i+1; j < nums.Length ; j++)
            {
                var deltaSign = GetDeltaSign(lastPeak, nums[j]);
                if (deltaSign == '#') continue;
                if (deltaSign == lastDeltaSign)
                {
                    lastPeak = nums[j];
                    wiggleSeq[wiggleSeq.Count-1]= lastPeak;
                    continue;
                }

                lastPeak = nums[j];
                lastDeltaSign = deltaSign;
                wiggleSeq.Add(lastPeak);
            }

            //PrintList(wiggleSeq);
            return wiggleSeq.Count;
        }

        private static void PrintList(IEnumerable<int> wiggleSeq)
        {
            Console.WriteLine(string.Join(',', wiggleSeq));
        }

        private static char GetDeltaSign(int i, int j)
        {
            if (i == j) return '#';
            return i < j ? '+' : '-';
        }

       
    }
}
