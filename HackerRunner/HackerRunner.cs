using System;
using System.IO;
using Problems.HashMap;

namespace HackerRunner
{
    public static class HackerRunner
    {
        static void whatFlavors(int[] cost, int money) {
            var (i,j) = IceCreamParlor.GetTwoFlavors(cost, money);
            Console.WriteLine($"{i+1} {j+1}");
        }

        static void Main(string[] args)
        {
            var inputFileName = args[0];
            using var reader = new StreamReader(File.OpenRead(inputFileName));
            int t = Convert.ToInt32(reader.ReadLine());

            string line=null;
            for (int tItr = 0; tItr < t; tItr++) {
                int money = Convert.ToInt32(reader.ReadLine());

                int n = Convert.ToInt32(reader.ReadLine());

                line = reader.ReadLine();
                var nums = line.Split(' ');
                //int[] cost = Array.ConvertAll(line.Split(' '), costTemp => Convert.ToInt32(costTemp));
                var cost = new int[n];
                for (int i = 0; i < n; i++)
                {
                    cost[i] = Convert.ToInt32(nums[i]);
                }
                whatFlavors(cost, money);
            }
            
        }
    }
}