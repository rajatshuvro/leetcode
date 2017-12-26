using System;
using System.Linq;
using System.Text;

namespace ZigZagString
{
    class ZigZag
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting zig-zag string!");

            var result = UnitTest("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR");
            result &= UnitTest("PAYPALISHIRING", 4, "PINALSIGYAHRPI");
            result &= UnitTest("PAYPALISHIRING", 1, "PAYPALISHIRING");

            if (result)
                Console.WriteLine("Passed all tests");

            Console.ReadKey();

        }

        private static bool UnitTest(string s, int numRows, string expectedResult)
        {
            var sol = new ZigZag();
            var result = sol.Convert(s,numRows);

            if (result == expectedResult)
            {
                Console.WriteLine($"Passed case: {s}, num rows: {numRows}");
                return true;
            }
            Console.WriteLine($"Failed for: {s}, num rows: {numRows}. Expected {expectedResult}, observed {result}");
            return false;
        }

        public enum ZzDirection
        {
            Down,
            Diagonal
        }
        public string Convert(string s, int numRows)
        {
            if (numRows == 0) return null;
            if (numRows == 1) return s;

            var strBuilders = new StringBuilder[numRows];
            for(var i=0; i < numRows; i++)
            {
                strBuilders[i] = new StringBuilder();
            }
            var dir = ZzDirection.Down;//the start direction is down
            var j = 0;
            foreach (var c in s)
            {
                switch (dir)
                {
                    case ZzDirection.Down:
                        strBuilders[j++].Append(c);
                        if (j == numRows )
                        {
                            j = numRows - 2;
                            dir = ZzDirection.Diagonal;
                        }
                        break;
                    case ZzDirection.Diagonal:
                        strBuilders[j--].Append(c);
                        if (j < 0)
                        {
                            j = 1;
                            dir = ZzDirection.Down;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            for (var i = 1; i < numRows; i++)
                strBuilders[0].Append(strBuilders[i]);
            return strBuilders[0].ToString();
        }

        
    }
}
