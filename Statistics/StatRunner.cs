using System;

namespace Statistics
{
    public class StatRunner
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));

            var (q1, q2, q3) = StatUtilities.GetQuartiles(nums);
            Console.WriteLine(q1);
            Console.WriteLine(q2);
            Console.WriteLine(q3);
        }
    }
}