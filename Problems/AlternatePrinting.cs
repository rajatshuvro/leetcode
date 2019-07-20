using System;
using System.Text;
using System.Threading;

namespace Problems
{
    public class AlternatePrinting
    {
        //https://leetcode.com/problems/print-foobar-alternately/
        private readonly int _n;
        private readonly string _x;
        private readonly string _y;
        private readonly Semaphore _xLock;
        private readonly Semaphore _yLock;
        private readonly StringBuilder _sb;

        public AlternatePrinting(int n, string x, string y)
        {
            _n = n;
            _x = x;
            _y = y;

            _xLock = new Semaphore(1, 1);
            _yLock = new Semaphore(0, 1);
            _sb = new StringBuilder();
        }

        public void PrintX()
        {
            for (int i = 0; i < _n; i++)
            {
                _xLock.WaitOne();
                _sb.Append(_x);
                Console.Write(_x);
                _yLock.Release();
            }
        }
        public void PrintY()
        {
            for (int i = 0; i < _n; i++)
            {
                _yLock.WaitOne();
                _sb.Append(_y);
                Console.Write(_y);
                _xLock.Release();
            }
        }

        public string GetOutput()
        {
            return _sb.ToString();
        }
    }
}