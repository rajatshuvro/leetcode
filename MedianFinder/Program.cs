using System;
using DataStructures;

namespace MedianFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finding median of a dynamically changing array!");

            var result = UnitTest1();
            result &= UnitTest2();
            result &= UnitTest3();
            //result &= UnitTest4();
            //result &= UnitTest5();

            if (result)
                Console.WriteLine("Passed all unit tests");

            Console.Read();
        }

        private static bool UnitTest3()
        {
            Console.WriteLine("Testing the median finder");

            var medianFinder = new MedianFinder();

            medianFinder.AddNum(1);
            medianFinder.AddNum(2);

            if (medianFinder.FindMedian() != 1.5)
            {
                Console.WriteLine("failed to find median of [1,2]");
                return false;
            }
            medianFinder.AddNum(2);
            if (medianFinder.FindMedian() != 2)
            {
                Console.WriteLine("failed to find median of [1,2,2]");
                return false;
            }

            medianFinder.AddNum(1);
            medianFinder.AddNum(1);
            if (medianFinder.FindMedian() != 1)
            {
                Console.WriteLine("failed to find median of [1,1,1,2,2]");
                return false;
            }

            return true;
        }

        private static bool UnitTest2()
        {
            Console.WriteLine("Testing Min heap");

            var maxHeap = new MaxHeap<int>();

            maxHeap.Add(4);
            maxHeap.Add(3);
            maxHeap.Add(5);

            if (maxHeap.GetMax() != 5)
            {
                Console.WriteLine("Failed get Max test!!");
                return false;
            }

            maxHeap.Add(2);
            if (maxHeap.ExtractMax() != 5)
            {
                Console.WriteLine("Failed extract Max");
                return false;
            }

            maxHeap.Add(1);
            if (maxHeap.ExtractMax() != 4)
            {
                Console.WriteLine("Failed extract Max");
                return false;
            }

            return true;
        }

        private static bool UnitTest1()
        {
            Console.WriteLine("Testing Min heap");

            var minHeap = new MinHeap<int>();

            minHeap.Add(4);
            minHeap.Add(3);
            minHeap.Add(5);

            if (minHeap.GetMin() != 3)
            {
                Console.WriteLine("Failed get min test!!");
                return false;
            }

            minHeap.Add(2);
            if (minHeap.ExtractMin() != 2)
            {
                Console.WriteLine("Failed extract min");
                return false;
            }

            minHeap.Add(1);
            if (minHeap.ExtractMin() != 1)
            {
                Console.WriteLine("Failed extract min");
                return false;
            }

            return true;
        }
    }
}
