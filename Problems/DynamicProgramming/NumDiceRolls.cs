using System.Collections.Generic;

namespace Problems.DynamicProgramming
{
    public class NumDiceRolls
    {
        //https://leetcode.com/problems/number-of-dice-rolls-with-target-sum/
        private Dictionary<(int dice, int target), int> _sumWays = new Dictionary<(int dice, int target), int>();
        private const int _modulo = 1_000_000_007;
        public int NumRollsToTarget(int d, int f, int target)
        {
            if (d == 0 || target < 1) return 0;
            if (target > d * f || target < d) return 0;
            
            if (d == 1)
            {
                return target <= f ? 1 : 0;
            }

            if (_sumWays.TryGetValue((d, f), out var ways)) return ways;
            ways = 0;
            for (int i = 1; i <= f; i++)
            {
                ways += NumRollsToTarget(d - 1, f, target - i);
                if (ways >= _modulo) ways -= _modulo;
            }
            
            _sumWays.Add((d,f), ways);
            return ways;
        }
    }
}