using System.Threading;
using Problems;
using Xunit;

namespace UnitTests
{
    public class ZeroOddEvenTests
    {
        [Fact]
        public void PrintTo3()
        {
            var printer = new PrintZeroEvenOdd(3);
            var thread1 = new Thread(() => printer.Zero());
            var thread2 = new Thread(() => printer.Odd());
            var thread3 = new Thread(() => printer.Even());

            thread3.Start();
            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Assert.Equal("010203", printer.GetOutput());
        }

        [Fact]
        public void PrintTo4()
        {
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

            Assert.Equal("01020304", printer.GetOutput());
        }

        [Fact]
        public void PrintTo9()
        {
            var printer = new PrintZeroEvenOdd(9);
            var thread1 = new Thread(() => printer.Zero());
            var thread2 = new Thread(() => printer.Odd());
            var thread3 = new Thread(() => printer.Even());

            thread3.Start();
            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Assert.Equal("010203040506070809", printer.GetOutput());
        }
    }
}