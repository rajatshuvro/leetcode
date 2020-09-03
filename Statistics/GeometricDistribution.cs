using System;

namespace Statistics
{
    public static class GeometricDistribution
    {
        public static double Probability(int n, double p)
        {
            return Math.Pow(1.0 - p, n - 1) * p;
        }

        public static double FirstSuccessWithin(int n, double p)
        {
            var totalP = 0.0;
            for (int i = 1; i <= n; i++)
            {
                totalP += Probability(i, p);
            }

            return totalP;
        }
    }
}