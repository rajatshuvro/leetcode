﻿using System.Collections.Generic;
using Algorithms;
using DataStructures;

namespace Problems
{
    public class CourseOrdering
    {
        //https://leetcode.com/problems/course-schedule-ii/
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            var nodes = new List<GraphNode<int>>(numCourses);
            for (var i = 0; i < numCourses; i++)
            {
                nodes.Add(new GraphNode<int>(i));
            }

            var edges = new List<DirectedEdge<int>>(prerequisites.GetLength(0));
            for (var i = 0; i < prerequisites.GetLength(0); i++)
            {
                edges.Add(new DirectedEdge<int>(nodes[prerequisites[i][0]], nodes[prerequisites[i][1]]));
            }

            var diGraph = new DirectedGraph<int>(nodes, edges);

            var topSorter = new TopologicalOrdering<int>(diGraph);

            return topSorter.GetTopologicalOrdering()?.ToArray();
        }
    }
}