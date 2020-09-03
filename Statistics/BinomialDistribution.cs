using System;

namespace Statistics
{
    public static class BinomialDistribution
    {
        public static double Probability(int n, int k, double p)
        {
            return StatUtilities.GetBinCoeff(n,k) * Math.Pow(p,k)* Math.Pow(1.0-p,n-k); 
        }
        
        public static double AtLeastProbability(int n, int k, double p)
        {
            var prob = 0.0;
            for (int i = k; i <= n; i++)
            {
                prob+=Probability(n,i,p); 
            }

            return prob;
        }
        
        public static double AtMostProbability(int n, int k, double p)
        {
            var prob = 0.0;
            for (int i = 0; i <= k; i++)
            {
                prob+=Probability(n,i,p); 
            }

            return prob;
        }
    }
}