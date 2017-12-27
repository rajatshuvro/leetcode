using System;

namespace MutableRangeSum
{
    class MutableRangeSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reporting range sums of mutable array!");
        }

        private readonly BinaryIndexTree _biTree;
        private readonly int[] _nums;
        public MutableRangeSum(int[] nums)
        {
            _nums = nums;
            _biTree = new BinaryIndexTree(nums);
        }

        public void Update(int i, int val)
        {
            _biTree.Update(i, _nums[i] - val);
            _nums[i] = val;
        }

        public int SumRange(int i, int j)
        {
            return _biTree.GetSum(j) - _biTree.GetSum(i);
        }
    }

    public class BinaryIndexTree
    {
        private readonly int[] _biTree;
        private readonly int _arrayLen;
        public BinaryIndexTree(int[] array)
        {
            _arrayLen = array.Length;
            _biTree = new int[_arrayLen + 1];
            // Initialize _biTree[] as 0
            for (var i = 1; i <= _arrayLen; i++)
                _biTree[i] = 0;

            // Store the actual values in _biTree[]
            // using update()
            for (var i = 0; i < _arrayLen; i++)
                Update(i, array[i]);
        }
        // Returns sum of array[0..index]. This function 
        // assumes that the array is preprocessed and 
        // partial sums of array elements are stored 
        // in _biTree[].
        public int GetSum(int index)
        {
            var sum = 0; // Iniialize result

            // index in _biTree[] is 1 more than
            // the index in array[]
            index = index + 1;

            // Traverse ancestors of _biTree[index]
            while (index > 0)
            {
                // Add current element of _biTree 
                // to sum
                sum += _biTree[index];

                // Move index to parent node in 
                // getSum View
                index -= index & (-index);
            }
            return sum;
        }

        // Updates a node in Binary Index Tree (_biTree)
        // at given index in _biTree.  The given  
        // 'change' is added to _biTree[i] and all of 
        // its ancestors in tree.
        public void Update( int index, int change)
        {
            // index in _biTree[] is 1 more than 
            // the index in array[]
            index = index + 1;

            // Traverse all ancestors and add 'change'
            while (index <= _arrayLen)
            {
                // Add 'change' to current node of BIT Tree
                _biTree[index] += change;

                // Update index to that of parent 
                // in update View
                index += index & (-index);
            }
        }
    }
}
