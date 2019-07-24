using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems
{
    public class EnumeratorOfEnumerator<T,K>:IEnumerator<T>
    {
        // interview questions
        // implement an enumerator of T, that takes an array of K and a function that returns an enumerator of T given K
        // e.g. given ["abc", "def"] return ['a', 'b', 'c', 'd', 'e', 'f']

        private Func<K, IEnumerable<T>> _enumFunc;
        public EnumeratorOfEnumerator(K[] array, Func<K, IEnumerable<T>> enumFunc)
        {

        }
        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public T Current { get; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}