using System;
using System.Collections.Generic;
using System.IO;

namespace DataStructures
{
    public class BitMap:IEquatable<BitMap>
    {
        public int Count { get; private set; }
        private readonly byte[] _buffer;
        public int Capacity { get; private set; }
        private int BufferSize => Capacity >> 3;
        private int BufferCapacity => _buffer.Length * 8;
        
        public BitMap(int capacity)
        {
            SetCapacity(capacity);

            _buffer = new byte[BufferSize];
        }

        private void SetCapacity(int capacity)
        {
            if ((capacity & 7) != 0)
                //not a multiple of 8. So we want to make it one.
                Capacity  = ((capacity >> 3) + 1) << 3;
            else Capacity = capacity;
        }

        public void Resize(int capacity)
        {
            if(capacity > BufferCapacity)
                throw new InvalidOperationException($"BitMap capacity cannot be inceased beyond initial capacity ({_buffer.Length*8}). Please create a new BitMap.");

            Clear();
            SetCapacity(capacity);

        }

        public void Read(BinaryReader reader)
        {
            Clear();
            var count = reader.ReadInt32();
            Resize(count<<3);
            
            reader.Read(_buffer, 0, count);
        }

        public void Set(int index)
        {
            (int i, uint flag) = GetBufferIndexAndFlag(index);

            if ((_buffer[i] & flag) == 0) Count++;
            
            _buffer[i] |= (byte)flag;
        }

        private (int bufferIndex, uint flag) GetBufferIndexAndFlag(int index)
        {
            if (index < 0 || index >= Capacity)
            {
                throw new IndexOutOfRangeException($"Index has to be between [0,{Capacity-1}]. Observed: {index}");
            }
            
            var bufferIndex = index >> 3; // divide by 8
            var bitIndex    = index & 7; // modulo 8
            var flag        = (uint) 1 << bitIndex;
            return (bufferIndex, flag);
        }

        public void Reset(int index)
        {
            (int i, uint flag) = GetBufferIndexAndFlag(index);

            if ((_buffer[i] & flag) != 0) Count--;
            flag =  ~flag;
            _buffer[i] &= (byte)flag;
        }

        public bool IsSet(int index)
        {
            (int i, uint flag) = GetBufferIndexAndFlag(index);

            return (_buffer[i] & flag) != 0;

        }

        public void Clear()
        {
            Array.Fill(_buffer, (byte)0);
            Count = 0;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(BufferSize);
            writer.Write(_buffer, 0, BufferSize);
            
        }

        public IEnumerable<int> GetAllSetPositions()
        {
            for(var i=0; i < Capacity; i++)
                if (IsSet(i))
                    yield return i;
        }

        public bool Equals(BitMap other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Capacity != other.Capacity) return false;
            for (int i = 0; i < BufferSize; i++)
            {
                if (_buffer[i] != other._buffer[i]) return false;
            }

            return true;
        }
    }
}