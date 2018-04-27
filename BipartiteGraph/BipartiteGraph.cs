using System;
using System.Collections.Generic;
using DataStructures;

namespace BipartiteGraph
{
    public class BipartiteGraph
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bipartite Graph!");
        }

        public bool IsBipartite(int[][] graph)
        {
            var edges = new List<Edge<int>>();
            for(var i=0; i < graph.Length; i++)
                for (var j = 0; j < graph[i].Length; j++)
                {
                    if (i > graph[i][j]) continue;
                    edges.Add(new Edge<int>(new Node<int>(i), new Node<int>(graph[i][j])));
                }

            var myGraph = new Graph<int>(false, edges);

            return myGraph.IsBipartite();
        }
    }
}
