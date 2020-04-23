using System;
using System.Linq;

namespace Problems.RandomNumbers
{
    public class RandomWithWeights
    {
        //https://leetcode.com/problems/random-pick-with-weight/
        private int[] _cumulative;
        private readonly int _totalWeight;
        private readonly Random _rand;
        
        public RandomWithWeights(int[] weights)
        {
            _rand = new Random();
            _totalWeight = weights.Sum();
            _cumulative = new int[weights.Length];
            var sum = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                _cumulative[i] = sum + weights[i] -1;
                sum += weights[i];
            }
        }
    
        public int PickIndex()
        {
            var x = _rand.Next(0, _totalWeight);
            var i = Array.BinarySearch(_cumulative, x);
            if (i < 0) i = ~i;

            return i;
        }
    }
}