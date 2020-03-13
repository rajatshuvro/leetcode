namespace Problems
{
    public class ReachablePoints
    {
        //https://leetcode.com/problems/reaching-points/
        public bool ReachingPoints(int sx, int sy, int tx, int ty)
        {
            if (sx > tx || sy > ty) return false;
            
            while (sx < tx && sy < ty)
            {
                if (tx < ty) ty %= tx;
                else tx %= ty;
            }
            //at this point, either sx==tx or sy == ty
            if (sx == tx) return (ty - sy) % sx == 0;
            if (sy == ty) return (tx - sx) % sy == 0;

            return false;
        }
    }
}