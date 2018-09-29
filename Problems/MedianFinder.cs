using DataStructures;

namespace Problems
{
    public class MedianFinder
    {
        readonly MaxHeap<int> _leftHalf = new MaxHeap<int>();

        readonly MinHeap<int> _rightHalf = new MinHeap<int>();

        //remove a number from the list
        public bool Remove(int num)
        {
            var result = false;
            //if (num <= _leftHalf.GetMax()) result |=_leftHalf.Remove(num);
            //else if (num >= _rightHalf.GetMin()) result |= _rightHalf.Remove(num);
            result |= _leftHalf.Remove(num);
            if (! result) result |= _rightHalf.Remove(num);
            BalanceHeaps();
            return result;
        }

        // Adds a num into the data structure.
        public void AddNum(int num)
        {
            if (_leftHalf.Count == 0)
            {
                _leftHalf.Add(num);
                return;
            }

            if (num <= _leftHalf.GetMax()) _leftHalf.Add(num);
            else _rightHalf.Add(num);

            BalanceHeaps();
        }

        private void BalanceHeaps()
        {
            while (_leftHalf.Count > _rightHalf.Count + 1)
            {
                _rightHalf.Add(_leftHalf.ExtractMax());
                return;
            }
            //the left heap cannot be empty if the right one has items
            while (_leftHalf.Count < _rightHalf.Count)
            {
                _leftHalf.Add(_rightHalf.ExtractMin());
                return;
            }
        }

        // return the median of current data stream
        public double FindMedian()
        {
            if (_leftHalf.Count == _rightHalf.Count)
                return (_leftHalf.GetMax()*1.0 + _rightHalf.GetMin()*1.0) / 2;

            return _leftHalf.Count > _rightHalf.Count ? _leftHalf.GetMax() : _rightHalf.GetMin();
        }
        
    }
}