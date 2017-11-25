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
            result &= sol.PredictTheWinner(new[] { 3, 4 });
            result &= !sol.PredictTheWinner(new[] { 1, 5, 2 });
            result &= sol.PredictTheWinner(new[] { 1, 5, 233, 7 });
            result &= !sol.PredictTheWinner(new[] { 2, 4, 55, 6, 8 });
            result &= sol.PredictTheWinner(new[] { 1, 0, 0, 1, 1, 1, 1231, 0, 1, 1, 1, 1, 1, 1, 12, 0, 0, 0, 0, 0 });
            result &= sol.PredictTheWinner(new[] { 10, 17, 11, 16, 17, 9, 14, 17, 18, 13, 11, 4, 17, 18, 15, 3, 13, 10, 6, 10 });

            return result;
        }

        public bool PredictTheWinner(int[] nums)
        {
            return IterativeSolution(nums);
        }

        private bool IterativeSolution(int[] nums)
        {
            var n = nums.Length;
            int[] lead = new int[n];

            for (var i = n - 1; i >= 0; i--)
            {
                lead[i] = nums[i];
                for (var j = i + 1; j < n; j++)
                    lead[j] = Math.Max(nums[i] - lead[j], nums[j] - lead[j - 1]);
            }

            return lead[n - 1] >= 0;
        }

    }
}
