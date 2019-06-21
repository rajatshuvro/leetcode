namespace DataStructures
{
    public class BitMap
    {
        //can be a used or keeping track of item existance of <= 64 items 
        public ulong Map { get; private set; }
        public int Count { get; private set; }

        public BitMap()
        {
            Map = 0;
        }

        public override int GetHashCode()
        {
            return Map.GetHashCode();
        }

        public bool Set(int index)
        {
            if (index < 0 || index > 64) return false;

            var flag = (ulong) 1 << index;
            if ((Map & flag) == 0) Count++;
            Map |= flag;
            return true;
        }

        public void Clear(int index)
        {
            if (index < 0 || index > 64) return;

            var flag = (ulong)1 << index;
            if ((Map & flag) != 0) Count--;
            flag = ~flag;
            Map &= flag;
        }

        public bool IsSet(int index)
        {
            if (index < 0 || index > 64) return false;
            var flag = (ulong)1 << index;
            return (Map & flag) !=0;
        }
    }
}