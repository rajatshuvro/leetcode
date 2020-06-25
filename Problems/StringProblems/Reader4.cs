using System;
using System.IO;
using System.Xml;

namespace Problems.StringProblems
{
    //https://leetcode.com/problems/read-n-characters-given-read4-ii-call-multiple-times/
    public class Reader4:IDisposable
    {
        private Stream _stream;
        private readonly StreamReader _reader;
        public Reader4(Stream stream)
        {
            _stream = stream;
            _reader = new StreamReader(_stream);
        }

        private int Read4(char[] buf)
        {
            return _reader.Read(buf, 0, 4);
        }

        private readonly char[] _buf4 = new char[4];
        private int _i4 = 0;//index of _buf4
        private int _count4 = 0;
        public int Read(char[] buf, int n)
        {
            var count = 0;
            while (count < n)
            {
                if (_i4 > 0)// there are some residues left over from last read
                {
                    var len4 = Math.Min(_count4 - _i4 , n - count);
                    Array.Copy(_buf4,_i4,buf,count,len4);
                    _i4 += len4;
                    count += len4;
                    if (_i4 == _count4) _i4 = 0;
                    continue;
                }

                _count4 = Read4(_buf4);
                _i4 = 0;
                if (_count4 == 0) break;
                var length = Math.Min(_count4, n - count);
                Array.Copy(_buf4,_i4,buf,count,length);
                _i4 = length;
                if (_i4 == _count4) _i4 = 0;
                count += length;
            }
            
            return count;
        }

        public void Dispose()
        {
            _stream?.Dispose();
            _reader?.Dispose();
        }
    }
}