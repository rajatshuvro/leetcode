using Algorithms;

namespace Problems
{
    public class KthLargestElement
    {
        public int FindKthLargest(int[] nums, int k)
        {
            return ArrayUtils.FindKthElement(nums, 0, nums.Length -1, nums.Length - k );
        }
        
    }
}