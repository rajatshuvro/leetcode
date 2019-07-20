using System;
using System.Threading;
using Problems;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests
{
    public class PrintOrderTests
    {
        [Fact]
        public void ThreeTwoOne()
        {
            var printer = new PrintOrder();
            var thread1 = new Thread(() => printer.First());
            var thread2 = new Thread(() => printer.Second());
            var thread3 = new Thread(() => printer.Third());

            thread3.Start();
            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Assert.Equal("firstsecondthird", printer.GetOutput());
        }

        [Fact]
        public void TwoThreeOne()
        {
            var printer = new PrintOrder();
            var thread1 = new Thread(() => printer.First());
            var thread2 = new Thread(() => printer.Second());
            var thread3 = new Thread(() => printer.Third());

            thread2.Start();
            thread3.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Assert.Equal("firstsecondthird", printer.GetOutput());
        }

        [Fact]
        public void OneThreeTwo()
        {
            var printer = new PrintOrder();
            var thread1 = new Thread(() => printer.First());
            var thread2 = new Thread(() => printer.Second());
            var thread3 = new Thread(() => printer.Third());

            thread1.Start();
            thread3.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Assert.Equal("firstsecondthird", printer.GetOutput());
        }
    }
}