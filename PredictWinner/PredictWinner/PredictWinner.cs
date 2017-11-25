using System;

namespace PredictWinner
{
    public class PredictWinner
    {
        static void Main()
        {
            Console.WriteLine("Predicting the winner!");

            if (RunTests())
                Console.WriteLine("Passed all tests");
            else
                Console.WriteLine("Some tests failed");
            Console.ReadKey();
        }

        private static bool RunTests()
        {
            var sol = new PredictWinner();
            var result = sol.PredictTheWinner(new[] { 2 });
            result &= sol.PredictTheWinner(new[] { 3, 4});
            result &= !sol.PredictTheWinner(new[] { 1, 5, 2 });
            result &= sol.PredictTheWinner(new[] { 1, 5, 233, 7 });
            result &= !sol.PredictTheWinner(new[] { 2, 4, 55, 6, 8 });
            result &= sol.PredictTheWinner(new[] { 1, 0, 0, 1, 1, 1, 1231, 0, 1, 1, 1, 1, 1, 1, 12, 0, 0, 0, 0, 0});
            result &= sol.PredictTheWinner(new[] { 10, 17, 11, 16, 17, 9, 14, 17, 18, 13, 11, 4, 17, 18, 15, 3, 13, 10, 6, 10 });

            return result;
        }

        static int[,] _firstPlayerLead;

        public bool PredictTheWinner(int[] nums)
        {
            _firstPlayerLead = InitializeMatrix(nums);

            return ComputeFirstPlayerLeads(nums, 0, nums.Length - 1) >= 0;
        }

        private int ComputeFirstPlayerLeads(int[] nums, int i, int j)
        {
            if (i > j) return 0;

            if (i == j) return nums[i];
            if (i + 1 == j) return Math.Abs(nums[i] - nums[j]);

            if (_firstPlayerLead[i,j] == int.MinValue)
                _firstPlayerLead[i,j] = Math.Max(nums[i] - ComputeFirstPlayerLeads(nums, i + 1, j),
                    nums[j] - ComputeFirstPlayerLeads(nums, i, j - 1));

            return _firstPlayerLead[i, j];
        }

        private static int[,] InitializeMatrix(int[] nums)
        {
            var matrix = new int[nums.Length, nums.Length];
            for(var i=0; i < nums.Length ; i++)
                for (var j = 0; j < nums.Length; j++)
                    matrix[i, j] = int.MinValue;

            return matrix;
        }
        
    }
}
