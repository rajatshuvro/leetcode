using DataStructures;

namespace Problems
{
    public class SumOfFiles
    {
        private MinHeap<int> sizesMinHeap;

        public int minimumTime(int numOfSubFiles, int[] files)
        {
            if (numOfSubFiles == 0) return 0;
            if (numOfSubFiles == 1) return files[0];

            sizesMinHeap = new MinHeap<int>(int.MinValue);
            for (int i = 0; i < numOfSubFiles; i++)
            {
                sizesMinHeap.Add(files[i]);
            }

            var timeToMerge = 0;
            while (sizesMinHeap.Count > 1)
            {
                var min1 = sizesMinHeap.ExtractMin();
                var min2 = sizesMinHeap.ExtractMin();

                timeToMerge += (min1 + min2);

                sizesMinHeap.Add(min1+min2);
            }

            return timeToMerge;
        }
    }
}