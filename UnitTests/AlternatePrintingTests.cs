using System.Threading;
using Problems;
using Xunit;

namespace UnitTests
{
    public class AlternatePrintingTests
    {
        [Fact]
        public void Print4Sets()
        {
            var printer = new AlternatePrinting(4, "...", "|||");
            var thread1 = new Thread(() => printer.PrintX());
            var thread2 = new Thread(() => printer.PrintY());

            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();

            Assert.Equal("...|||...|||...|||...|||", printer.GetOutput());
        }

        [Fact]
        public void Print5Sets()
        {
            var printer = new AlternatePrinting(5, "...", "|||");
            var thread1 = new Thread(() => printer.PrintX());
            var thread2 = new Thread(() => printer.PrintY());

            thread2.Start();
            thread1.Start();

            thread1.Join();
            thread2.Join();

            Assert.Equal("...|||...|||...|||...|||...|||", printer.GetOutput());
        }
    }
}