using System;
using System.Collections.Generic;

namespace Problems.HashMap
{
    //https://www.hackerrank.com/challenges/ctci-ice-cream-parlor/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=search
    public class CostIndex:IComparable<CostIndex>, IComparable<int>
    {
        public readonly long Cost;
        public readonly int Index;

        public CostIndex(long cost, int index)
        {
            Cost = cost;
            Index = index;
        }

        public int CompareTo(CostIndex other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Cost.CompareTo(other.Cost);
        }
        
        public int CompareTo(int cost)
        {
            return Cost.CompareTo(Cost);
        }
    }

    public class IceCreamParlor
    {
        public static (int i, int j) GetTwoFlavors(int[] costs, long money)
        {
            var costIndexes = new List<CostIndex>();
            for (int i = 0; i < costs.Length; i++)
            {
                costIndexes.Add(new CostIndex(costs[i], i));
            }
            costIndexes.Sort();

            for (int i = 0; i < costIndexes.Count - 1; i++)
            {
                var cost1 = costIndexes[i].Cost;
                var indexI = costIndexes[i].Index;
                var cost2 = money - cost1;
                var flavor2 = new CostIndex(cost2, 0);
                var index = costIndexes.BinarySearch(flavor2);
                if (index < 0) index = ~index;
                
                int indexJ;
                for (indexJ = -1; index < costIndexes.Count && cost2 == costIndexes[index].Cost; index++)
                {
                    if(index == i) continue;
                    indexJ = costIndexes[index].Index;
                    break;
                }
                if(indexJ == -1) continue;
                return indexI < indexJ? (indexI, indexJ): ( indexJ, indexI);
            }

            return (-1, -1);//no possible combination
        }
    }
}