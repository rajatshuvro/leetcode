using System.Collections.Generic;

namespace Problems
{
    public class Combinations
    {
        //https://leetcode.com/problems/combinations/description/

        private int[] _elements;
        public IList<IList<int>> Combine(int n, int k)
        {
            if (n < k) return null;

            _elements = new int[n];
            for (int i = 0; i < n; i++)
            {
                _elements[i] = i + 1;
            }
            
            return GetCombinations(n, k, 0);
        }

        public IList<IList<int>> GetCombinations(int n, int k, int i)
        {
            var combinations = new List<IList<int>>();
            if (k == 0) return combinations;
            if (k == 1)
            {
                for (int j = i; j < _elements.Length ; j++)
                {
                    var combination = new List<int> { _elements[j] };
                    combinations.Add(combination);
                }

                return combinations;
            }

            for (int j = i; j < _elements.Length - k +1; j++)
            {
                foreach (var comb in GetCombinations(n-1, k-1, j+1))
                {
                    var combination = new List<int> {_elements[j]};

                    combination.AddRange(comb);
                    combinations.Add(combination);
                }
            }

            return combinations;
        }
    }
}