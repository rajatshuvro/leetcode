using System.Text;
using System.Threading;

namespace Problems
{
    public class PrintZeroEvenOdd
    {
        //https://leetcode.com/problems/print-zero-even-odd/
        private readonly int _n;
        private int _i=1;
        private readonly Semaphore _zero;
        private readonly Semaphore _even;
        private readonly Semaphore _odd;
        private readonly StringBuilder _sb;
        public PrintZeroEvenOdd(int n)
        {
            _n    = n;
            _zero = new Semaphore(1, 1);
            _even = new Semaphore(0, 1);
            _odd  = new Semaphore(0, 1);
            _sb   = new StringBuilder();
        }

        public void Zero()
        {
            while (_i < _n)
            {
                _zero.WaitOne();
                _sb.Append('0');
                if (_i % 2 != 0)
                    _odd.Release();
                else _even.Release();
            }
            
        }

        public void Even()
        {
            while (_i <= _n)
            {
                _even.WaitOne();
                if (_i > _n) break;
                _sb.Append(_i);
                _i++;
                _zero.Release();
            }

            _odd.Release();
        }
        public void Odd()
        {
            while (_i <= _n)
            {
                _odd.WaitOne();
                if (_i > _n) break;
                _sb.Append(_i);
                _i++;
                _zero.Release();
            }
            _even.Release();
        }
        public string GetOutput()
        {
            return _sb.ToString();
        }
    }
}