using System;

namespace Problems.RandomNumbers
{
    public class RandomPointsInCircle
    {
        //https://leetcode.com/problems/generate-random-point-in-a-circle/

        private readonly double _radius;
        private readonly double _xCenter;
        private readonly double _yCenter;
        public RandomPointsInCircle(double radius, double x_center, double y_center)
        {
            _radius = radius;
            _xCenter = x_center;
            _yCenter = y_center;
        }

        public double[] RandPoint()
        {
            var rand = new Random();

            var x = rand.NextDouble() * _radius * 2 + (_xCenter - _radius);
            var yRange = Math.Sqrt(_radius * _radius - (x - _xCenter) * (x - _xCenter));
            var y = rand.NextDouble() * yRange * 2 + (_yCenter - yRange);

            return new[] {x, y};
        }
    }
}