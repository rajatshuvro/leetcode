using System;

namespace Statistics
{
    public class StatRunner
    {
        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(' '), qTemp => Convert.ToInt32(qTemp));
            
            var std = StatUtilities.GetStd(nums);
            Console.WriteLine(string.Format("{0:0.0}", std));
        }
    }
}