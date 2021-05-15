using System;
using System.Threading;

//https://leetcode.com/problems/print-foobar-alternately/
public class FooBar {
    private int n;
    private SemaphoreSlim _fooSemaphore;
    private SemaphoreSlim _barSemaphore;

    public FooBar(int n) {
        this.n = n;
        _fooSemaphore = new SemaphoreSlim(1);
        _barSemaphore = new SemaphoreSlim(0);
    }

    public void Foo(Action printFoo) {
        
        for (int i = 0; i < n; i++)
        {
            _fooSemaphore.Wait();
        	// printFoo() outputs "foo". Do not change or remove this line.
        	printFoo();
            _barSemaphore.Release();
        }
    }

    public void Bar(Action printBar) {
        
        for (int i = 0; i < n; i++)
        {
            _barSemaphore.Wait();
            // printBar() outputs "bar". Do not change or remove this line.
        	printBar();
            _fooSemaphore.Release();
        }
    }
}