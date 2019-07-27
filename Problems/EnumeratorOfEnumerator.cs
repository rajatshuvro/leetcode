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

        private readonly Func<K, IEnumerator<T>> _getEnumerator;
        private readonly K[] _array;
        private int _index;
        private IEnumerator<T> _currentEnumerator = null;
        public EnumeratorOfEnumerator(K[] array, Func<K, IEnumerator<T>> getEnumerator)
        {
            _array = array;
            _index = -1;
            _getEnumerator = getEnumerator;
        }
        public bool MoveNext()
        {
            if (_array == null || _array.Length == 0 || _index >= _array.Length) return false;

            if (_currentEnumerator == null)
            {
                _index++;
                _currentEnumerator = _getEnumerator(_array[_index]);
            }
            if (_index == _array.Length - 1) return _currentEnumerator.MoveNext();

            var moveNext = _currentEnumerator.MoveNext();
            while (moveNext == false && _index < _array.Length -1)
            {
                // move to the next element in the array
                _index++;
                _currentEnumerator = _getEnumerator(_array[_index]);
                moveNext = _currentEnumerator.MoveNext();
            }
            return moveNext;
        }

        public void Reset()
        {
            _index = -1;
        }

        public T Current => _currentEnumerator.Current;

        object IEnumerator.Current => _currentEnumerator.Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}