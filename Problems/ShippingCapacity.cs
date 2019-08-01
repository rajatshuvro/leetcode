using System.Linq;

namespace Problems
{
    public class ShippingCapacity
    {
        //https://leetcode.com/problems/capacity-to-ship-packages-within-d-days/
        /*
         * A conveyor belt has packages that must be shipped from one port to another within D days.

The i-th package on the conveyor belt has a weight of weights[i].  Each day, we load the ship with packages on the conveyor belt (in the order given by weights). We may not load more weight than the maximum weight capacity of the ship.

Return the least weight capacity of the ship that will result in all the packages on the conveyor belt being shipped within D days.
         */

        private int[] _weights;
        private int _d;
        public int ShipWithinDays(int[] weights, int D)
        {
            _weights = weights;
            _d = D;
            int totalWeight = weights.Sum();
            int lowerBound = totalWeight %  D==0? totalWeight / D: totalWeight /D + 1;

            int upperBound = GetUpperBound(lowerBound);

            for (var i = lowerBound; i <= upperBound; i++)
            {
                if (CompareCapacity(i) >= 0) return i;
            }

            return upperBound;
        }

        private int CompareCapacity(int capacity)
        {
            //returns -1 if capacity is insufficient
            // returns 0 is capacity is just right
            // returns 1 if capacity is more than sufficient
            var i = 0;
            int d = _d;
            while (d > 0 && i < _weights.Length)
            {
                var dayLoad = 0;
                while (dayLoad < capacity && i < _weights.Length)
                {
                    if (dayLoad + _weights[i] <= capacity) dayLoad += _weights[i++];
                    else break;
                }

                d--;
            }
            if (d == 0 && i == _weights.Length) return 0;
            if (d > 0) return 1;//finished shipping before last day
            // d=0 since it can't be less than 0 and...
            if ( i < _weights.Length) return -1;// packages left to be shipped
            return 1;// all shipped by using all days

        }
        // tries to ship at least lowerBound amount every day to estimate an upper bound;
        private int GetUpperBound(int lowerBound)
        {
            int i = 0;
            var upperBound = lowerBound;
            var d = _d;
            while (d > 0 && i < _weights.Length)
            {
                var dayLoad = 0;
                while (dayLoad <lowerBound && i < _weights.Length)
                {
                    dayLoad += _weights[i++];
                }

                if (dayLoad > upperBound)  upperBound = dayLoad;
                d--;
            }

            return upperBound;
        }
    }
}