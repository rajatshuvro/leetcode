using System.Collections;
using System.Collections.Generic;

namespace Problems.StringProblems
{
    //https://leetcode.com/problems/ambiguous-coordinates/
    public class CoordinateCombinations
    {
        public IList<string> AmbiguousCoordinates(string s)
        {
            var coordinates = new List<string>();
            s = s.Trim('(', ')');
            if (string.IsNullOrEmpty(s)) return coordinates;

            for (int i = 1; i < s.Length; i++)
            {
                var s1 = s.Substring(0, i);
                var s2 = s.Substring(i);

                var validNums1 = GetValidNumbers(s1);
                var validNums2 = GetValidNumbers(s2);
                foreach (var n1 in validNums1)
                {
                    foreach (var n2 in validNums2)
                    {
                        coordinates.Add($"({n1}, {n2})");    
                    }
                    
                }
            }
            return coordinates;
        }

        private List<string> GetValidNumbers(string s)
        {
            var numbers = new List<string>();
            
            if (!(s.Length > 1 && s.StartsWith('0'))) numbers.Add(s);
            for (int i = 1; i < s.Length; i++)
            {
                var s1 = s.Substring(0, i );
                // first part can be 0 or has to start with non zero
                if(s1.Length > 1 && s1.StartsWith('0')) continue;  
                var s2 = s.Substring(i);
                // second part cannot end with 0
                if (s2.EndsWith('0')) continue;
                numbers.Add($"{s1}.{s2}");
            }
            
            return numbers;
        }
        
        
    }
}