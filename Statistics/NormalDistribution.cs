using System;
using System.Reflection.Metadata;

namespace Statistics
{
    public class NormalDistribution
    {
        public readonly double Mean;
        public readonly double Variance;
        public readonly double Std;
        public NormalDistribution(double mean, double std)
        {
            Mean = mean;
            Variance = std*std;
            Std = std;
        }

        public double CumulativeProbability(double x)
        {
            var z = (x - Mean) / (Std * Math.Sqrt(2));
            return (1 + StatUtilities.ErrorFunction(z)) / 2;
        }
        
        public double CumulativeIntervalProbability(double x, double y)
        {
            return Math.Abs(CumulativeProbability(y) - CumulativeProbability(x));
        }
    }
}