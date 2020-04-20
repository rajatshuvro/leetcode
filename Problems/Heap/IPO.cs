using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Problems.Heap
{
    public class Project : IComparable<Project>
    {
        public readonly int Profit;
        public readonly int Capital;

        public Project(int profit, int capital)
        {
            Profit = profit;
            Capital = capital;
        }

        public int CompareTo(Project other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            
            return Profit.CompareTo(other.Profit);
        }
    }

    public class IPO
    {
        //https://leetcode.com/problems/ipo/
        public int FindMaximizedCapital(int k, int W, int[] Profits, int[] Capital)
        {
            var projects = new List<Project>(Profits.Length);
            for (int i = 0; i < Profits.Length; i++)
            {
                projects.Add(new Project(Profits[i], Capital[i]));
            }
            var projectsByCapital = projects.OrderBy(x => x.Capital).ToArray();
            var projectIndex = 0;
            var currentCandidates = new MaxHeap<Project>(new Project(0,int.MaxValue));
            while (projectIndex < projectsByCapital.Length)
            {
                if (projectsByCapital[projectIndex].Capital <= W) currentCandidates.Add(projectsByCapital[projectIndex]);
                else break;
                projectIndex++;
            }
            
            while (k>0 && currentCandidates.Count >0)
            {
                var bestProject = currentCandidates.ExtractMax();
                if (bestProject.Capital > W) break;
                W += bestProject.Profit;
                while (projectIndex < projectsByCapital.Length)
                {
                    if (projectsByCapital[projectIndex].Capital <= W) currentCandidates.Add(projectsByCapital[projectIndex]);
                    else break;
                    projectIndex++;
                }
                k--;
            }

            return W;
        }
    }
}