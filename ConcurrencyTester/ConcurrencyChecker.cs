using System;
using System.Threading;
using Problems;

namespace ConcurrencyTester
{
    class ConcurrencyChecker
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Concurrency tester!");

            var printer = new PrintZeroEvenOdd(4);
            var thread1 = new Thread(() => printer.Zero());
            var thread2 = new Thread(() => printer.Odd());
            var thread3 = new Thread(() => printer.Even());

            thread3.Start();
            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine(printer.GetOutput());

        }
    }
}
