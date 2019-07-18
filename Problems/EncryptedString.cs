using System;

namespace Problems
{
    public class EncryptedString
    {
        private string _encryptedString;
        private int[] _numWays;
        public int NumDecodings(string s)
        {
            _encryptedString = s;
            _numWays = new int[_encryptedString.Length];
            Array.Fill(_numWays, -1);

            NumDecodings(0);

            return _numWays[0];
        }

        private int NumDecodings(int i)
        {
            if (i >= _encryptedString.Length) return 0;
            if (_numWays[i] >= 0) return _numWays[i];// value has already been computed

            if (_encryptedString[i] == '0')
            {
                _numWays[i] = 0;
                return 0;//invalid string
            }

            if (i == _encryptedString.Length - 1)
            {
                _numWays[i] = _encryptedString[i]=='0'? 0: 1;
                return _numWays[i];
            }

            var twoLetterDecoding = GetTwoLetterDecoding(i);
            if (i == _encryptedString.Length - 2)
            {
                _numWays[i] = twoLetterDecoding;
                return twoLetterDecoding;
            }
            var jointDecoding = GetJointDecoding(i);
            _numWays[i]= NumDecodings(i + 1) + jointDecoding * NumDecodings(i + 2);
            return _numWays[i];
        }

        private int GetJointDecoding(int i)
        {
            // num ways to decode when two chars are taken together
            if (i >= _encryptedString.Length - 1) return 0;

            var num = _encryptedString[i] - '0';
            num = num * 10 + (_encryptedString[i + 1] - '0');

            if (num < 10) return 0;// invalid string
            if (num <= 26) return 1;

            return 0;
        }

        //returns how many ways a two letter combination can be decoded as
        private int GetTwoLetterDecoding(int i)
        {
            if (i >= _encryptedString.Length) return 0;
            if (i == _encryptedString.Length - 1) return 1;

            var num = _encryptedString[i] - '0';
            num = num * 10 + (_encryptedString[i + 1] - '0');

            if (num < 10) return 0;// invalid string
            if (num == 10) return 1;
            if (num <= 26) return 2;
            return 1;
        }
    }
}