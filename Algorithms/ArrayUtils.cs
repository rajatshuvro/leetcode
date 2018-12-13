namespace Algorithms
{
    public static class ArrayUtils
    {
        public static int Partition(int[] nums, int i, int j, int pivotIndex)
        {
            if (i < 0 || i >= nums.Length || j >= nums.Length) return -1;
            if (i > j || pivotIndex > j || i > pivotIndex) return -1;

            var pivot = nums[pivotIndex];
            while (i < j)
            {
                while (nums[i] < pivot) i++;
                while (pivot < nums[j]) j--;

                Swap(nums, i, j);

                if (nums[i] == pivot) pivotIndex = i;
                if (nums[j] == pivot) pivotIndex = j;
            }

            return pivotIndex;
        }

        public static void Swap(int[] nums, int i, int j)
        {
            if (j == i) return;

            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}