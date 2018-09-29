namespace SlidingWindowMedian
{
    public class SlidingMedianFinder
    {
        private readonly MedianFinder.MedianFinder _medianFinder = new MedianFinder.MedianFinder();
        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            if (k > nums.Length) return null;
            var medians = new double[nums.Length-k+1];
            for (int i = 0; i < k; i++)
            {
                _medianFinder.AddNum(nums[i]);
            }

            medians[0] = _medianFinder.FindMedian();

            for (int i = 1, j = k ; j < nums.Length; i++, j++)
            {
                _medianFinder.AddNum(nums[j]);
                medians[i] = _medianFinder.FindMedian();
            }

            return medians;
        }
    }
}