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
            for(var i=0; i < graph.GetLength(0); i++)
                for (var j = i+1; j < graph.GetLength(1); j++)
                {
                    edges.Add(new Edge<int>(new Node<int>(i), new Node<int>(graph[i][j])));
                }

            var myGraph = new Graph<int>(false, edges);

            return myGraph.IsBipartite();
        }
    }
}
