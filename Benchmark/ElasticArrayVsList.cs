using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using DataStructures;

namespace Benchmark
{
    public class ElasticArrayVsList
    {
        private const int Size = 1_000_000;
        private int[] _nums;

        public ElasticArrayVsList()
        {
            _nums = new int[Size];
            var rand = new Random();
            for (int i = 0; i < Size; i++)
            {
                _nums[i] = rand.Next();
            }
        }

        [Benchmark]
        public void RunElasticArray()
        {
            var array= new ElasticArray<int>(128);
            for (int i = 0; i < Size; i++)
            {
                array.Add(_nums[i]);
            }
            
            array.Sort();
        }

        [Benchmark]
        public void RunList()
        {
            var list= new List<int>(128);
            for (int i = 0; i < Size; i++)
            {
                list.Add(_nums[i]);
            }
            
            list.Sort();
        }
        
    }
}