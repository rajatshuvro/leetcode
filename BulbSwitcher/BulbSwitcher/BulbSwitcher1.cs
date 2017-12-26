using System;

namespace BulbSwitcher
{
    class BulbSwitcher1
    {
        //https://discuss.leetcode.com/topic/31929/math-solution
        static void Main(string[] args)
        {
            Console.WriteLine("Bulb switcher 1!");
        }

        public int BulbSwitch(int n)
        {
            return (int) Math.Sqrt(n);
        }
    }
}
