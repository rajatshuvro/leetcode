using System;
using System.Drawing;

namespace Problems
{
    public class CourseSchedule
    {
        //https://leetcode.com/problems/course-schedule/
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //we will use colors to indicate if a node has been visited
            var nodeColors = new char[numCourses];
            Array.Fill(nodeColors,'w');

            for (var i = 0; i < numCourses; i++)
            {
                if (nodeColors[i] == 'w') break; //ColorComponent(i);
            }
            return true;
        }
    }
}