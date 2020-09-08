using System;

namespace Statistics
{
    public static class PoissonDistribution
    {
        public static double Probability(int x, double mean)
        {
            return Math.Pow(mean, x) * Math.Pow(Math.E, -mean)/StatUtilities.Factorial(x);
        }

        public static double AtLeast(int x, double mean)
        {
            var cumulative = 0.0;
            for (int i = 0; i <= x; i++)
            {
                cumulative += Probability(i, mean);
            }

            return cumulative;
        }

        public static double ExpectedSquare(double mean)
        {
            return mean * mean + mean;
        }
    }
}