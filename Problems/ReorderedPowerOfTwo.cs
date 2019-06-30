using System.Linq;

namespace Problems
{
    public class ReorderedPowerOfTwo
    {
        public bool ReorderedPowerOf2(int N)
        {
            var profileN = GetIntegerProfile(N);
            var i = GetMinNumberForProfile(profileN);

            for (; i <= 1000000000; i <<= 1)
            {
                var profileI = GetIntegerProfile(i);
                if (profileN.SequenceEqual(profileI)) return true;
            }

            return false;
        }

        private int GetMinNumberForProfile(int[] profile)
        {
            var digitCount = profile.Sum();
            switch (digitCount)
            {
                case 1:
                    return 1;
                case 2:
                    return 16;
                case 3:
                    return 128;
                case 4:
                    return 1_024;
                case 5:
                    return 16_384;
                case 6:
                    return 131_072;
                case 7:
                    return 1_048_576;
                case 8:
                    return 16_777_216;
                default:
                    return 134_217_728;
            }

        }

        private int[] GetIntegerProfile(int n)
        {
            int[] profile = new int[10];
            while (n != 0)
            {
                var lastDigit = n % 10;
                n /= 10;
                profile[lastDigit]++;
            }

            return profile;
        }
    }
}