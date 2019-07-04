namespace Problems
{
    public class EleminationGame
    {
        public int LastRemaining(int n)
        {
            if (n <= 1) return n;

            var leftSurvivor = 1;
            var rightSurvivor = n;
            var round = 0;
            var distToNextSurvivor = 1; //2^0
            while (leftSurvivor < rightSurvivor)
            {
                if (round % 2 == 0)
                {
                    //elemination starts from left
                    leftSurvivor += distToNextSurvivor;
                    rightSurvivor = n % 2 == 0 ? rightSurvivor : rightSurvivor - distToNextSurvivor;
                }
                else
                {
                    //elemination starts from right
                    rightSurvivor -= distToNextSurvivor;
                    leftSurvivor = n % 2 == 0 ? leftSurvivor : leftSurvivor + distToNextSurvivor;
                }

                distToNextSurvivor <<= 1;//doubles in every iteration
                n >>= 1;//halves every iteration
                round++;
            }

            return round % 2 == 0 ? rightSurvivor : leftSurvivor;
        }
    }
}