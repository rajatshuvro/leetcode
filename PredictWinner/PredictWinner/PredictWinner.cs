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

        static int[,] _maxMatrix;
        private static int[] _scores;

        public bool PredictTheWinner(int[] nums)
        {
            _maxMatrix = InitializeMaxMatrix(nums);
            _scores = new[] {int.MinValue, int.MinValue};
            CanCurrentPlayerWin(nums, 0, nums.Length-1, 0);

            return _scores[0] >= _scores[1];
        }

        private static int[,] InitializeMaxMatrix(int[] nums)
        {
            var matrix = new int[nums.Length, nums.Length];
            for(var i=0; i < nums.Length ; i++)
                for (var j = 0; j < nums.Length; j++)
                    matrix[i, j] = int.MinValue;

            return matrix;
        }

        public static bool CanCurrentPlayerWin(int[] nums, int start, int end, int playerNo)
        {
            if (start == end)
            {
                UpdatePlayerScore(nums[start], playerNo);
                return true;
            }
            if (start > end) return false;
            //sub array length 2
            if (end - start == 1) {
                UpdatePlayerScore(Math.Max(nums[start], nums[end]), playerNo);
                return true; 
                }

            if (_maxMatrix[start, end] == int.MinValue)
                _maxMatrix[start, end] = GetMax(nums, start, end);

            var max = _maxMatrix[start, end];
            if (nums[start] == max || nums[end] == max)
            {
                UpdatePlayerScore(max, playerNo);
                return true;
            }

            return !(CanCurrentPlayerWin(nums, start + 1, end, 1- playerNo) && CanCurrentPlayerWin(nums, start, end - 1, 1 - playerNo));
        }

        private static void UpdatePlayerScore(int score, int playerNo)
        {
            _scores[playerNo] = score > _scores[playerNo] ? score : _scores[playerNo];
        }

        private static int GetMax(int[] nums, int start, int end)
        {
            var max = int.MinValue;
            if (start < 0 || end >= nums.Length) return max;

            for (var i = start; i <= end; i++)
            {
                if (max < nums[i]) max = nums[i];
            }

            return max;
        }
    }
}
