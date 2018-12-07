namespace Problems
{
    public class TowerOfChampagne
    {
        private const int MaxRowSize = 100;
        private double[][] glasses= new double[MaxRowSize][];

        
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            if (query_row >= MaxRowSize || query_glass >= MaxRowSize) return 0;
            glasses[0]= new double[1];
            glasses[0][0] = poured;
            for (int i = 0; i < MaxRowSize -1; i++)
            {
                glasses[i+1]= new double[i+2];
                bool noGlassOverflowing = true;
                for (int j = 0; j <=i; j++)
                {
                    if (glasses[i][j] > 1)
                    {
                        noGlassOverflowing = false;
                        var spill = (glasses[i][j]-1) / 2;
                        glasses[i + 1][ j] += spill;
                        glasses[i + 1][ j + 1] += spill;
                        glasses[i][j] = 1;
                    }
                    
                }
                if (noGlassOverflowing) break;
            }
            //check the last row and spill to floor if overflowing
            for (int i = 0; i <=query_glass; i++)
            {
                if (glasses[query_row][ i] > 1) glasses[query_row][ i] = 1;
            }

            return glasses[query_row][ query_glass];
        }
    }
}