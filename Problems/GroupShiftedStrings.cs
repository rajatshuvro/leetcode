using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using DataStructures;

namespace Problems
{
    public class GroupShiftedStrings
    {
        //https://leetcode.com/problems/group-shifted-strings/
        //Given a string, we can "shift" each of its letter to its successive letter, for example: "abc" -> "bcd". We can keep "shifting" which forms the sequence:
        //"abc" -> "bcd" -> ... -> "xyz"
        //Given a list of strings which contains only lowercase alphabets, group all strings that belong to the same shifting sequence.
        public IList<IList<string>> GroupStrings(string[] strings)
        {
            var stringsInGroup = new HashSet<int>();
            var groupLists = new List<IList<string>>();

            for (var i = 0; i < strings.Length; i++)
            {
                if (stringsInGroup.Contains(i)) continue;

                stringsInGroup.Add(i);

                var currList = new List<string>() { strings[i] };
                for (var j = i + 1; j < strings.Length; j++)
                {
                    if (stringsInGroup.Contains(j)) continue;

                    if (InSameGroup(strings[i], strings[j]))
                    {
                        stringsInGroup.Add(j);
                        currList.Add(strings[j]);
                    }
                }
                groupLists.Add(currList);
            }

            return groupLists;
        }

        private bool InSameGroup(string s, string s1)
        {
            if (s.Length != s1.Length) return false;

            var diff = s[0] - s1[0];
            for (int i = 1; i < s.Length; i++)
            {
                //if(s1=="yx")
                //    Console.WriteLine("bug");
                var expectedChar = s[i] - diff;
                if (expectedChar > 'z') expectedChar = 'a' + (expectedChar - 'z' - 1);
                if (expectedChar < 'a') expectedChar = 'z' - ('a' - expectedChar - 1);
                if (expectedChar != s1[i]) return false;
            }

            return true;
        }
    }
}