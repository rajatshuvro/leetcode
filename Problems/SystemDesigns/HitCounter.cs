namespace Problems.SystemDesigns
{
    //https://leetcode.com/problems/design-hit-counter/
    public class HitCounter
    {
        private const int TimeWindow = 300; //seconds
        private readonly bool[] _circularArray;
        private int _currentTime=1;
        private int _index;
        private int _count;
        /** Initialize your data structure here. */
        public HitCounter() {
            _circularArray = new bool[TimeWindow];
        }
    
        /** Record a hit.
        @param timestamp - The current timestamp (in seconds granularity). */
        public void Hit(int timestamp) {
            AdvanceTo(timestamp);
            //now set the bool for timeStamp.
            _circularArray[_index] = true;
            _count++;
        }
    
        /** Return the number of hits in the past 5 minutes.
        @param timestamp - The current timestamp (in seconds granularity). */
        public int GetHits(int timestamp) {
            AdvanceTo(timestamp);

            return _count;
        }

        private void AdvanceTo(int timestamp)
        {
            for (int i = _currentTime; i < timestamp; i++, _currentTime++)
            {
                _index++;
                if (_index >= TimeWindow) _index = 0; //reset the circular window
                if (_circularArray[_index]) _count--;
                _circularArray[_index] = false;
            }
            
        }
    }
}