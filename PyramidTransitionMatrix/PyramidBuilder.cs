using System;
using System.Collections.Generic;
using System.Linq;

namespace PyramidTransitionMatrix
{
    class PyramidBuilder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building pyramid with transition matrices!");

            UnitTest("XYZ", new List<string>(){ "XYD", "YZE", "DEA", "FFF" }, true);
            UnitTest("CCC", new List<string>() { "CBB", "ACB", "ABD", "CDB", "BDC", "CBC", "DBA", "DBB", "CAB", "BCB", "BCC", "BAA", "CCD", "BDD", "DDD", "CCA", "CAA", "CCC", "CCB" }, true);
            
        }

        private static void UnitTest(string bottom, List<string> allowed, bool expectedResult)
        {
            var pyBuilder = new PyramidBuilder();

            var result = pyBuilder.PyramidTransition(bottom, allowed);

            Console.Write($"Testing : {bottom} with {string.Join(',', allowed)}.....");
            Console.WriteLine(result == expectedResult ? "Passed" : "FAILED");
        }

        HashSet<string> _validBottoms;
        private Dictionary<string, List<char>> _allowedLookup;

        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            //generate 2-d lookup for allowed
            _allowedLookup = new Dictionary<string, List<char>>();
            foreach (var tripple in allowed)
            {
                var key = tripple.Substring(0, 2);
                if (!_allowedLookup.ContainsKey(key))
                    _allowedLookup[key] = new List<char>(){tripple[2]};
                else _allowedLookup[key].Add(tripple[2]);
            }
            _validBottoms = new HashSet<string>();
            return PyramidTransition(bottom);
        }

        private bool PyramidTransition(string bottom)
        {
            if (bottom.Length == 2) return _allowedLookup.ContainsKey(bottom);
            if (_validBottoms.Contains(bottom)) return true;//using memoization

            foreach (var nextFloor in GetNextFloors(bottom))
            {
                if (!PyramidTransition(nextFloor)) continue;

                _validBottoms.Add(bottom);
                return true;
            }

            return false;
        }

        private IEnumerable<string> GetNextFloors(string bottom)
        {
            var floorList = new List<string>(){""};
            
            for (var i = 0; i < bottom.Length - 1; i++)
            {
                var pair = bottom.Substring(i, 2);
                if (_allowedLookup.ContainsKey(pair))
                {
                    var newFloors = new List<string>();
                    foreach (var c in _allowedLookup[pair])
                    {
                        newFloors.AddRange(floorList.Select(f => f + c.ToString()));
                    }

                    floorList = newFloors;
                }
                else return new List<string>();//returning empty string list
            }

            return floorList;
        }
    }
}
