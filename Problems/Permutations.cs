using System.Collections.Generic;

namespace Problems
{
    public class Permutations
    {
        //https://leetcode.com/problems/permutations/description/
        private int[] _nums;
        public IList<IList<int>> Permute(int[] nums)
        {
            _nums = nums;
            return GetPermutations(0, nums.Length);
        }

        private IList<IList<int>> GetPermutations(int i, int n)
        {
            var permutations = new List<IList<int>>();
            if (n == 0) return permutations;
            if (n == 1)
            {
                for(int j=i; j < _nums.Length; j++)
                    permutations.Add(new List<int>(){_nums[j]});
                return permutations;
            }

            for (int j = i; j < _nums.Length ; j++)
            {
                Swap(i,j);
                foreach (var perm in GetPermutations(i+1,n-1))
                {
                    var permutation = new List<int>(){_nums[i]};
                    permutation.AddRange(perm);
                    permutations.Add(permutation);
                }
                //swapping back
                Swap(i,j);

            }
            return permutations;

        }

        private void Swap( int i,  int j)
        {
            if (j == i) return;

            var temp = _nums[i];
            _nums[i] = _nums[j];
            _nums[j] = temp;
        }
    }
}