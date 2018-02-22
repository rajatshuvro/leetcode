using System;

namespace EliminationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let the eliminatioin begin!");

            var s = new Solution();

            var n = 9;
            var result = s.LastRemaining(n) == 6;
            Console.WriteLine(result ? $"Passed case n={n}" : $"Failed case n={n}");

            n = 2;
            result = s.LastRemaining(n) == 2;
            Console.WriteLine(result ? $"Passed case n={n}" : $"Failed case n={n}");

            n = 3;
            result = s.LastRemaining(n) == 2;
            Console.WriteLine(result ? $"Passed case n={n}" : $"Failed case n={n}");

            n = 24;
            result = s.LastRemaining(n) == 14;
            Console.WriteLine(result ? $"Passed case n={n}" : $"Failed case n={n}");
        }
    }

    public class Solution
    {
        public int LastRemaining(int n)
        {
            if (n <= 1) return n;

            var leftSurvivor = 1;
            var rightSurvivor = n;
            var round = 0;
            var distToNextSurvivor = 1; //2^0
            while (leftSurvivor < rightSurvivor)
            {
                if (round % 2 == 0)
                {
                    //elemination starts from left
                    leftSurvivor += distToNextSurvivor;
                    rightSurvivor = n % 2 == 0 ? rightSurvivor : rightSurvivor - distToNextSurvivor;
                }
                else
                {
                    //elemination starts from right
                    rightSurvivor -= distToNextSurvivor;
                    leftSurvivor = n % 2 == 0 ? leftSurvivor : leftSurvivor + distToNextSurvivor;
                }

                distToNextSurvivor <<= 1;//doubles in every iteration
                n >>= 1;//halves every iteration
                round++;
            }

            return round%2==0? rightSurvivor: leftSurvivor;
        }
    }
}
