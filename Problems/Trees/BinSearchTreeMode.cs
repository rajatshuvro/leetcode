using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Problems.Trees
{
    public class BinSearchTreeMode
    {
        private Dictionary<int, int> _valueCounts = new Dictionary<int, int>();
        public int[] FindMode(TreeNode root)
        {
            if(root == null) return Array.Empty<int>();
            TraverseBst(root);
            var maxCount = _valueCounts.Values.Max();
            var modes = new List<int>();
            foreach (var (key, value) in _valueCounts)
            {
                if(value == maxCount) modes.Add(key);
            }

            return modes.ToArray();
        }

        private void TraverseBst(TreeNode root)
        {
            if (root == null) return;
            if (_valueCounts.ContainsKey(root.val)) _valueCounts[root.val]++;
            else _valueCounts.Add(root.val, 1);
            
            if(root.left != null) TraverseBst(root.left);
            if(root.right != null) TraverseBst(root.right);
        }
    }
}