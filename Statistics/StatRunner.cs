using System;

namespace Statistics
{
    public class StatRunner
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));
            
            
            Console.WriteLine($"{StatUtilities.GetMean(nums):0.0}");
            Console.WriteLine($"{StatUtilities.GetMedian(nums):0.0}");
            Console.WriteLine($"{StatUtilities.GetMode(nums)}");
        }
    }
}