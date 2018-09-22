using DataStructures;

namespace MedianFinder
{
    public class MedianFinder
    {
        readonly MaxHeap<int> _leftHalf = new MaxHeap<int>();

        readonly MinHeap<int> _rightHalf = new MinHeap<int>();

        // Adds a num into the data structure.
        public void AddNum(int num)
        {
            if (_leftHalf.Count == 0)
            {
                _leftHalf.Add(num);
                return;
            }

            if (num <= _leftHalf.GetMax())
                _leftHalf.Add(num);
            else
                _rightHalf.Add(num);

            //now we need to balance the two heaps
            while (_leftHalf.Count > _rightHalf.Count + 1)
            {
                _rightHalf.Add(_leftHalf.ExtractMax());
                return;
            }

            while (_leftHalf.Count + 1 < _rightHalf.Count)
            {
                _leftHalf.Add(_rightHalf.ExtractMin());
                return;
            }

        }

        // return the median of current data stream
        public double FindMedian()
        {
            if (_leftHalf.Count == _rightHalf.Count)
                return (_leftHalf.GetMax() + _rightHalf.GetMin())*1.0 / 2;

            return _leftHalf.Count > _rightHalf.Count ? _leftHalf.GetMax() : _rightHalf.GetMin();
        }
        
    }
}