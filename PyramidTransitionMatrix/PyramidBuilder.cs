using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PyramidTransitionMatrix
{
    class PyramidBuilder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Building pyramid with transition matrices!");
        }

        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            return GetNextFloors(bottom, allowed).Any(nextFloor => PyramidTransition(nextFloor, allowed));
        }

        private IEnumerable<string> GetNextFloors(string bottom, IList<string> allowed)
        {
            var floorList = new List<string>();
            for (var i = 0; i < bottom.Length - 1; i++)
            {

            }
        }
    }
}
