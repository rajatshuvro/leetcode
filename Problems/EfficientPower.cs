namespace Problems
{
    public static class EfficientPower
    {
        // interview problem
        // more efficient power function
        public static double Power(double x, int y)
        {
            if (y == 0) return 1;
            if (y == 1) return x;

            double r1 = Power(x, y / 2);
            if (y % 2 == 0) return r1 * r1;
            return r1 * r1 * x;
        }
    }
}