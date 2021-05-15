using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Concurrency
{
    public class FooBarTests
    {
        private void printFoo()
        {
            Console.Write("foo");
        }
        
        private void printBar()
        {
            Console.Write("bar");
        }

        [Fact]
        public void Case1()
        {
            var fooBar = new FooBar(1);

            var fooTask = Task.Run(() => fooBar.Foo(printFoo));
            
            var barTask = Task.Run(() => fooBar.Foo(printBar));
            
            Task.WaitAll(new Task[] {fooTask, barTask});
        }
    }
}