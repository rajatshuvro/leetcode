using System;
using System.Collections.Generic;

namespace MnvComposer
{
    class MnvComposer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Composing MNVs from phased SNVs!");
        }

        public int SampleCount;
        private byte[,] _sampleSequence;
        private byte[] _sampleIndices;
        private uint[] _samplePositions;
        private const int MaxRecomposeLength = 256;
        public MnvComposer(int sampleCount)
        {
            SampleCount      = sampleCount;
            _sampleSequence  = new byte[sampleCount * 2, MaxRecomposeLength];
            _sampleIndices   = new byte[MaxRecomposeLength];
            _samplePositions = new uint[sampleCount];
        }

        private void Add(IPosition position)
        {
        }

        public IEnumerable<IPosition> GetRecomposedPositions(IEnumerable<IPosition> positions)
        {
            foreach (var position in positions)
            {
                Add(position);
                var newPosition = GetNewPosition();
                if (newPosition !=null) yield return newPosition;

            }
        }

        private IPosition GetNewPosition()
        {
            throw new NotImplementedException();
        }
    }

    
}
