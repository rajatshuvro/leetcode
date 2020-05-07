using System;
using System.Collections.Generic;

namespace Problems.DynamicProgramming
{
    public class FreedomRing
    {
        //https://leetcode.com/problems/freedom-trail/
        private Dictionary<char, List<int>> _charIndices;
        private int[][] _distanceMatrix;
        private string _key;
        private string _ring;
        private Dictionary<(int, int), int> _subProblems;
        public int FindRotateSteps(string ring, string key)
        {
            if (string.IsNullOrEmpty(key)) return 0;
            
            GetCharIndices(ring);
            // given a position on the ring, we want to know the minimum steps to the char in question
            InitializeDistanceMatrix(ring.Length); 
            _key = key;
            _ring = ring;
            _subProblems = new Dictionary<(int, int), int>();
            return DynamicStepsCount(0, 0);
        }

        private int DynamicStepsCount(int ringIndex, int keyIndex)
        {
            if (keyIndex >= _key.Length) return 0;
            if (_subProblems.TryGetValue((ringIndex, keyIndex), out var result)) return result;
            
            var keyChar = _key[keyIndex];
            var minSteps = int.MaxValue;
            foreach (var distance in ComputeDistances(ringIndex, keyChar))
            {
                var nextRingIndex = ringIndex + distance;
                if (nextRingIndex < 0) nextRingIndex += _ring.Length;
                if (nextRingIndex >= _ring.Length) nextRingIndex -= _ring.Length;

                var steps = Math.Abs(distance) + 1 + DynamicStepsCount(nextRingIndex, keyIndex + 1);
                if (steps < minSteps)
                    minSteps = steps;
            }
            _subProblems.Add((ringIndex, keyIndex), minSteps);
            return minSteps;
        }
        private List<int> ComputeDistances(int ringIndex, char c )
        {
            var indices = _charIndices[c];
            var distances = new List<int>();
            foreach (var i in indices)
            {
                var absDistance = Math.Abs(i - ringIndex) ;
                var clockwiseDistance = ringIndex <= i ? absDistance : _ring.Length - absDistance;
                var antiClkwDistance = i < ringIndex ? absDistance : _ring.Length - absDistance;

                var distance = clockwiseDistance < antiClkwDistance ? clockwiseDistance : -antiClkwDistance;
                distances.Add(distance);
            }

            return distances;
        }
        
        private void InitializeDistanceMatrix(int n)
        {
            _distanceMatrix = new int[n][];
            for (int i = 0; i < _distanceMatrix.Length; i++)
            {
                _distanceMatrix[i] = new int[26];
                Array.Fill(_distanceMatrix[i], int.MaxValue);
            }
        }

        private void GetCharIndices(string ring)
        {
            _charIndices = new Dictionary<char, List<int>>(26);
            for (int i = 0; i < ring.Length; i++)
            {
                var c = ring[i];
                if (_charIndices.TryGetValue(c, out var indices)) indices.Add(i);
                else _charIndices[c] = new List<int>() {i};
            }
        }
    }
}