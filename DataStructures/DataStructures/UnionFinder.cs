using System;
using System.Collections.Generic;

namespace DataStructures
{
    public class UnionFinder<T> where T : IEquatable<T>, IComparable<T>
    {
        private readonly Dictionary<T, T> _founder;
        private readonly Dictionary<T, List<T>> _clans;

        public UnionFinder()
        {
            _founder = new Dictionary<T, T>();
            _clans = new Dictionary<T, List<T>>();
        }
        // returns true if a and b both belong to the same clan
        public bool Unite(T a, T b)
        {
            if (a.CompareTo(b) > 0)
            {
                var temp = a;
                a = b;
                b = temp;
            }
            // both items are present, we need to merge two clans if different
            if (_founder.ContainsKey(a) && _founder.ContainsKey(b))
            {
                if (_founder[a].Equals(_founder[b]))
                    return true;

                var founderB = _founder[b];
                foreach (var member in _clans[founderB])
                {
                    _founder[member] = _founder[a];
                }
                _clans[_founder[a]].AddRange(_clans[founderB]);
                _clans.Remove(founderB);
                return false;
            }
            // at least one item is present
            if (_founder.ContainsKey(a))
            {
                _founder[b] = _founder[a];
                _clans[_founder[a]].Add(b);
                return false;
            }
            if (_founder.ContainsKey(b))
            {
                _founder[a] = _founder[b];
                _clans[_founder[b]].Add(a);
                return false;
            }
            // no items present
            _founder[a] = a;
            _founder[b] = a;
            _clans.Add(a, new List<T> { a, b });
            return false;
        }
    }

}