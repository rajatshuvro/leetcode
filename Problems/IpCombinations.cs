using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public class IpCombinations
    {
        //https://leetcode.com/problems/restore-ip-addresses/description/
        public IList<string> RestoreIpAddresses(string s)
        {
            return GetValidIpTriplets(s, 4);
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
                    if (followingTriplets !=null) triplets.AddRange(followingTriplets.Select(x=>triplet+"."+x));
                }
            }

            return triplets.Count>0? triplets: null;
        }
    }
}