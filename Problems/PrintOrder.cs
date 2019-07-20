using System;
using System.Text;
using System.Threading;

namespace Problems
{
    public class PrintOrder
    {
        //https://leetcode.com/problems/print-in-order/
        // not available for c#. Just coding for practice
        private readonly Semaphore _semaphore1, _semaphore2;
        private readonly StringBuilder _sb;

        public PrintOrder()
        {
            _sb = new StringBuilder();
            _semaphore1 = new Semaphore(0,3);
            _semaphore2 = new Semaphore(0,3);
        }

        public void First()
        {
            _sb.Append("first");
            _semaphore1.Release();
        }

        public void Second()
        {
            _semaphore1.WaitOne();
            _sb.Append("second");
            _semaphore2.Release();
        }

        public void Third()
        {
            _semaphore2.WaitOne();
            _sb.Append("third");
        }

        public string GetOutput()
        {
            return _sb.ToString();
        }
    }
}