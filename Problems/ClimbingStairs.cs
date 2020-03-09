namespace Problems
{
    public class ClimbingStairs
    {
        //https://leetcode.com/problems/climbing-stairs/
        public int ClimbStairs(int n) {
            //very similar to fibonacci number but with a different initial values.
            if (n <= 2) return n;
            var s1 = 1;//we can climb one stairs in 1 way
            var s2 = 2; //climb two stairs in two ways

            var s_i = 0;

            for (var i = 3; i <= n; i++)
            {
                s_i = s1+s2;
                s1 = s2;
                s2 = s_i;
            }

            return s_i;
        }
    }
}