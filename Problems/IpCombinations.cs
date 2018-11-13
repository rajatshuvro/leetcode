using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class IpCombinations
    {
        //https://leetcode.com/problems/restore-ip-addresses/description/
        public IList<string> RestoreIpAddresses(string s)
        {
            var triplets = GetValidIpTriplets(s, 4);
            return triplets ?? new List<string>();
        }

        public IList<string> GetValidIpTriplets(string s, int tripletCount)
        {
            if (tripletCount <= 0 || string.IsNullOrEmpty(s)) return null;
            if (s.Length < tripletCount || s.Length > 3 * tripletCount) return null;

            var triplets = new List<string>();
            for (int i = 0; i < 3 && i < s.Length; i++)
            {
                var triplet = s.Substring(0, i + 1);
                if (int.Parse(triplet) <= 255)
                {
                    if (triplet == s)
                    {
                        triplets.Add(triplet);
                        break;
                    }

                    var followingTriplets = GetValidIpTriplets(s.Substring(i + 1), tripletCount - 1);
                    if (followingTriplets != null)
                    {
                        triplets.AddRange(from x in followingTriplets where CountDots(x) == tripletCount - 2 select triplet + "." + x);
                    }
                }
                //no leading or multiple zeros allowed
                if (triplet == "0") break;
            }

            return triplets.Count>0? triplets: null;
        }

        private int CountDots(string s)
        {
            var count = 0;
            foreach (char c in s)
            {
                if (c == '.') count++;
            }

            return count;
        }
    }
}