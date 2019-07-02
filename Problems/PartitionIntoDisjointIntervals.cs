using DataStructures;

namespace Problems
{
    public class PartitionIntoDisjointIntervals
    {
        //https://leetcode.com/problems/partition-array-into-disjoint-intervals/
        /*
         * Given an array A, partition it into two (contiguous) subarrays left and right so that:

            - Every element in left is less than or equal to every element in right.
            - left and right are non-empty.
            - left has the smallest possible size.
            
            Return the length of left after such a partitioning.  It is guaranteed that such a partitioning exists.
         */

        public int PartitionDisjoint(int[] array)
        {
            var rightPartition = new MinHeap<int>(int.MinValue);
            var leftMax = array[0];

            for (var i = 1; i < array.Length; i++)
            {
                rightPartition.Add(array[i]);
            }

            var leftLength = 1;
            while (leftLength < array.Length && leftMax > rightPartition.GetMin())
            {
                rightPartition.Remove(array[leftLength]);
                if(leftMax < array[leftLength]) leftMax = array[leftLength];
                leftLength++;
            }

            return leftLength;
        }
    }
}