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

            var printer = new AlternatePrinting(4, "...", "|||");
            var thread1 = new Thread(() => printer.PrintX());
            var thread2 = new Thread(() => printer.PrintY());

            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine();
            Console.WriteLine(printer.GetOutput());

        }
    }
}
