namespace Problems
{
    public class TowerOfChampagne
    {
        private const int MaxRowSize = 100;
        private double[,] glasses= new double[MaxRowSize,MaxRowSize];

        
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            if (query_row >= MaxRowSize || query_glass >= MaxRowSize) return 0;

            glasses[0, 0] = poured;
            for (int i = 0; i < MaxRowSize -1; i++)
            {
                bool noGlassOverflowing = true;
                for (int j = 0; j <=i; j++)
                {
                    if (glasses[i, j] > 1)
                    {
                        noGlassOverflowing = false;
                        glasses[i, j]--;
                        glasses[i + 1, j] += glasses[i, j] / 2;
                        glasses[i + 1, j + 1] += glasses[i, j] / 2;
                        glasses[i, j] = 1;
                    }
                    
                }
                if (noGlassOverflowing) break;
            }
            //check the last row and spill to floor if overflowing
            for (int i = 0; i < MaxRowSize; i++)
            {
                if (glasses[MaxRowSize - 1, i] > 1) glasses[MaxRowSize - 1, i] = 1;
            }

            return glasses[query_row, query_glass];
        }
    }
}