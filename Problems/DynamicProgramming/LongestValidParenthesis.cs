using System.Collections.Generic;

namespace Problems.DynamicProgramming
{
    public class LongestValidParenthesis
    {
        //https://leetcode.com/problems/longest-valid-parentheses/
        public int LongestValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            
            var wellFormedIntervals = new Stack<(int start, int end)>();
            var openParenIndices = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '(')
                {
                    openParenIndices.Push(i);
                    continue;
                }

                if(openParenIndices.Count==0) continue;//no matching open parenthesis
                var start = openParenIndices.Pop();
                var end = i;
                wellFormedIntervals.Push((start, end));
                MergeIntervals(wellFormedIntervals);
                
            }

            if (wellFormedIntervals.Count == 0) return 0;
            
            var maxLength = 0;
            while (wellFormedIntervals.Count > 0)
            {
                var top = wellFormedIntervals.Pop();
                if (maxLength < top.end - top.start + 1)
                    maxLength = top.end - top.start + 1;
            }
            return maxLength;
        }

        private void MergeIntervals(Stack<(int start, int end)> wellFormedIntervals)
        {
            while (wellFormedIntervals.Count > 1)
            {
                var top1 = wellFormedIntervals.Pop();
                var top2 = wellFormedIntervals.Peek();

                if (IntervalContains(top1, top2))
                {
                    //remove top2 and push top1
                    wellFormedIntervals.Pop();
                    wellFormedIntervals.Push(top1);
                    continue;
                }

                if (CanBeMerged(top1, top2))
                {
                    wellFormedIntervals.Pop();
                    wellFormedIntervals.Push((top2.start, top1.end));
                    continue;
                }
                wellFormedIntervals.Push(top1);//no change possible, so put back top1
                return;
            }
        }

        private bool CanBeMerged((int start, int end) top1, (int start, int end) top2)
        {
            return top2.end + 1 == top1.start;
        }

        private bool IntervalContains((int start, int end) interval1, (int start, int end) interval2)
        {
            return interval1.start <= interval2.start && interval2.end <= interval1.end;
        }
    }
}