namespace DataStructures
{

    //https://www.geeksforgeeks.org/binary-indexed-tree-or-fenwick-tree-2/
    public class BinaryIndexTree
    {
        private readonly int[] _biTree;
        public BinaryIndexTree(int[] arr, int n)
        {
            _biTree = new int[n+1];
            // Initialize _biTree[] as 0
            for (var i = 1; i <= n; i++)
                _biTree[i] = 0;

            // Store the actual values in _biTree[]
            // using update()
            for (var i = 0; i < n; i++)
                Update(n, i, arr[i]);
        }
        // Returns sum of arr[0..index]. This function 
        // assumes that the array is preprocessed and 
        // partial sums of array elements are stored 
        // in _biTree[].
        public int GetSum(int index)
        {
            var sum = 0; // Iniialize result

            // index in _biTree[] is 1 more than
            // the index in arr[]
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
        // at given index in _biTree.  The given value 
        // 'val' is added to _biTree[i] and all of 
        // its ancestors in tree.
        public void Update(int n, int index, int val)
        {
            // index in _biTree[] is 1 more than 
            // the index in arr[]
            index = index + 1;

            // Traverse all ancestors and add 'val'
            while (index <= n)
            {
                // Add 'val' to current node of BIT Tree
                _biTree[index] += val;

                // Update index to that of parent 
                // in update View
                index += index & (-index);
            }
        }
    }
}