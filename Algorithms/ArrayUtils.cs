namespace Algorithms
{
    public static class ArrayUtils
    {
        public static int Partition(int[] array, int startIndex = 0, int endIndex = -1, int pivotIndex = -1)
        {
            if (endIndex == -1) endIndex = array.Length - 1;
            if (pivotIndex == -1) pivotIndex = (startIndex + endIndex) / 2;

            if (startIndex > endIndex || pivotIndex > endIndex || pivotIndex < startIndex) return -1;

            var i     = startIndex;
            var j     = endIndex;
            var pivot = array[pivotIndex];

            while (i < j)
            {
                while (i < endIndex && array[i] <= pivot) i++;  //num[i] is the first element > pivot
                while (j > startIndex && array[j] > pivot) j--; //num[j] is the first element <= pivot

                if (i >= j) break;
                Swap(array, i, j);
            }
            // i might have gone past the pivot element
            while (i > startIndex && array[i] > pivot) i--;
            return i;
        }

        //find the kth element in the array _nums[i...j]. K is 0 based
        public static int FindKthElement(int[] array, int i, int j, int k)
        {
            if (k >= j ) return GetMax(array, i, j);
            if (k <= i) return GetMin(array, i, j);

            if (i == j) return array[i];

            var pivotIndex = (i + j) / 2;

            var pivotRank = Partition(array, i, j, pivotIndex);

            return k <= pivotRank ? FindKthElement(array, i, pivotRank, k) : FindKthElement(array, pivotRank + 1, j, k);
        }

        private static int GetMax(int[] array, int i = 0, int j= -1)
        {
            if (j == -1) j = array.Length - 1;
            var max = array[i++];
            while (i <= j)
            {
                if (max < array[i]) max = array[i];
                i++;
            }

            return max;
        }

        private static int GetMin(int[] array, int i = 0, int j = -1)
        {
            if (j == -1) j = array.Length - 1;
            var min = array[i++];
            while (i <= j)
            {
                if (min > array[i]) min = array[i];
                i++;
            }

            return min;
        }

        public static void Swap(int[] array, int i, int j)
        {
            if (j == i) return;

            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}