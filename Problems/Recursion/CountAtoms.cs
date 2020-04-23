using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems.Recursion
{
    public class CountAtoms
    {
        //https://leetcode.com/problems/number-of-atoms/
        public string CountOfAtoms(string formula)
        {

            var atomCounts = AtomCounts(formula);

            return GetCountString(atomCounts);
        }

        private Dictionary<string, int> AtomCounts(string formula)
        {
            var atomCounts = new Dictionary<string, int>();
            if (string.IsNullOrEmpty(formula)) return atomCounts;
            var i = 0;

            while (i < formula.Length)
            {
                int count;
                if (formula[i] == '(')
                {
                    //if this is a sub-formula, solve recursively
                    var j = GetMatchingParenthesisIndex(formula, i);
                    // j is the index of the matching parenthesis. So the subFormula spans from i+1 to j-1
                    // so length = j-1 -i -1 +1 = j-i-1
                    var subFormula = formula.Substring(i + 1, j - i - 1);
                    i = j + 1;
                    var atomSubCounts = AtomCounts(subFormula);
                    (count, i) = GetNextCount(formula, i);

                    foreach (var (atom, subCount) in atomSubCounts)
                    {
                        if (atomCounts.ContainsKey(atom)) atomCounts[atom] += subCount * count;
                        else atomCounts.Add(atom, subCount*count);
                    }
                }
                else
                {
                    string nextAtom;
                    (nextAtom, i) = GetNextAtom(formula, i);
                    (count, i) = GetNextCount(formula, i);
                    if (atomCounts.ContainsKey(nextAtom)) atomCounts[nextAtom] += count;
                    else atomCounts.Add(nextAtom, count);
                }

                
            }

            return atomCounts;
        }

        private int GetMatchingParenthesisIndex(string formula, int i)
        {
            var count = 0;
            
            while (i < formula.Length)
            {
                if (formula[i] == '(') count++;
                if (formula[i] == ')') count--;
                if (count == 0) return i;
                i++;
            }

            return formula.Length;
        }

        private string GetCountString(Dictionary<string, int> atomCounts)
        {
            var sb = new StringBuilder();
            foreach (var (atom, count) in atomCounts.OrderBy(x=>x.Key))
            {
                sb.Append(atom);
                if (count > 1) sb.Append(count);
                
            }
            return sb.ToString();
        }

        private (string atom, int i) GetNextAtom(string formula, int i)
        {
            if(!char.IsUpper(formula[i])) throw new DataMisalignedException($"Atom has to start with Upper case");
            var j = i + 1;
            while (j < formula.Length && char.IsLower(formula[j]))
            {
                j++;
            }

            var atom = formula.Substring(i, j - i);
            i = j;//now check for number
            
            return (atom, i);
        }

        private (int count, int i) GetNextCount(string formula, int i)
        {
            var count = 0;
            while (i < formula.Length && char.IsDigit(formula[i]))
            {
                count = count * 10 + formula[i] - '0';
                i++;
            }

            if (count == 0) count = 1;//if there was no number, the count it 1
            return (count, i);
        }
    }
}