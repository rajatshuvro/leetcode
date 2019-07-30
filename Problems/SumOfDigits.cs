namespace Problems
{
    public class SumOfDigits
    {
        // interview problem
        // given an integer, return sum of digits
        // you may create a look up table of partial sums. Memory is limited

        private readonly byte[] _partialSums;

        public SumOfDigits()
        {
            _partialSums = new byte[1000];
            for (uint i = 0; i < 1000; i++)
                _partialSums[i] = (byte)SumAllDigits(i);
        }

        public uint EfficientSum(uint x)
        {
            uint sum = 0;
            while (x > 0)
            {
                var i = x % 1000;
                sum += _partialSums[i];
                x /= 1000;
            }

            return sum;
        }
        public uint SumAllDigits(uint x)
        {
            uint sum = 0;
            while (x > 0)
            {
                sum += (x % 10);
                x /= 10;
            }

            return sum;
        }
    }
}