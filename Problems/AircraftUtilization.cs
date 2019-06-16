using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems
{
    public class AircraftUtilization
    {
        private class ForwardRoute:IComparable<ForwardRoute>
        {
            public readonly int Id;
            public readonly int Distance;

            public ForwardRoute(int id, int distance)
            {
                Id = id;
                Distance = distance;
            }

            public int CompareTo(ForwardRoute other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return Distance.CompareTo(other.Distance);
            }
        }

        private class ReturnRoute:IComparable<ReturnRoute>
        {
            public readonly int Id;
            public readonly int Distance;

            public ReturnRoute(int id, int distance)
            {
                Id = id;
                Distance = distance;
            }

            public int CompareTo(ReturnRoute other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return Distance.CompareTo(other.Distance);
            }
        }

        private class RouteCombination : IComparable<RouteCombination>
        {
            public readonly ForwardRoute Forward;
            public readonly ReturnRoute Return;
            public int Distance => Forward.Distance + Return.Distance;

            public RouteCombination(ForwardRoute forward, ReturnRoute ret)
            {
                Forward = forward;
                Return = ret;
            }

            public int CompareTo(RouteCombination other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;

                return Distance.CompareTo(other.Distance);
            }
        }

        private List<ForwardRoute> _forwardRoutes;
        private List<ReturnRoute> _returnRoutes;
        public List<List<int>> optimalUtilization(int maxTravelDist,
            List<List<int>> forwardRouteList,
            List<List<int>> returnRouteList)
        {
            _forwardRoutes = new List<ForwardRoute>(forwardRouteList.Count);
            foreach (var forwardRoute in forwardRouteList)
            {
                _forwardRoutes.Add(new ForwardRoute(forwardRoute[0],forwardRoute[1]));
            }

            _returnRoutes = new List<ReturnRoute>(returnRouteList.Count);
            foreach (var returnRoute in returnRouteList)
            {
                _returnRoutes.Add(new ReturnRoute(returnRoute[0], returnRoute[1]));
            }

            //_forwardRoutes.Sort();
            _returnRoutes.Sort();

            var candidateCombinations = new MaxHeap<RouteCombination>(new RouteCombination(null, null));

            foreach (var forwardRoute in _forwardRoutes)
            {
                var remainingDistance = maxTravelDist - forwardRoute.Distance;
                if (remainingDistance <= 0) continue;

                //searching for the max return route possible
                var maxReturnRouteIndex = _returnRoutes.BinarySearch(new ReturnRoute(0, remainingDistance));

                //if exact match not found in b.search, the complement of the index of the next largest element is returned
                if (maxReturnRouteIndex < 0) maxReturnRouteIndex = ~maxReturnRouteIndex - 1;
                
                // if no return route is as large as the remaining distance, start from the largest
                if (maxReturnRouteIndex >= _returnRoutes.Count)
                    maxReturnRouteIndex = _returnRoutes.Count - 1;

                var maxReturnDistance = _returnRoutes[maxReturnRouteIndex].Distance;
                while (maxReturnRouteIndex >=0 && _returnRoutes[maxReturnRouteIndex].Distance == maxReturnDistance)
                {
                    candidateCombinations.Add(new RouteCombination(forwardRoute, _returnRoutes[maxReturnRouteIndex]));
                    maxReturnRouteIndex--;
                }
            }

            var optimalCombinations = new List<List<int>>();
            var optimalRouteDistance = candidateCombinations.GetMax().Distance;
            while (candidateCombinations.GetMax().Distance == optimalRouteDistance)
            {
                var optimalCombination = candidateCombinations.ExtractMax();
                optimalCombinations.Add(new List<int>() { optimalCombination.Forward.Id, optimalCombination.Return.Id});
            }

            return optimalCombinations;
        }
    }
}