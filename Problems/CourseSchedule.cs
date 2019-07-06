﻿using System.Collections.Generic;
using Algorithms;
using DataStructures;

namespace Problems
{
    public class CourseSchedule
    {
        //https://leetcode.com/problems/course-schedule/
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var nodes = new List<GraphNode<int>>(numCourses);
            for (var i = 0; i < numCourses; i++)
            {
                nodes.Add(new GraphNode<int>(i));
            }

            var edges = new List<Edge<int>>(prerequisites.GetLength(0));
            for (var i = 0; i < prerequisites.GetLength(0); i++)
            {
                edges.Add(new Edge<int>(nodes[prerequisites[i][0]], nodes[prerequisites[i][1]], true));
            }

            var diGraph = new Graph<int>(edges);
            return GraphProperties<int>.IsDirectedAcyclic(diGraph);
        }
    }
}