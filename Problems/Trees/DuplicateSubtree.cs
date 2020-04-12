using System.Collections.Generic;
using DataStructures;

namespace Problems.Trees
{
    public class DuplicateSubtree
    {
        private readonly Dictionary<string, int> _treeHashesAndCounts = new Dictionary<string, int>();
        private readonly List<TreeNode> _dupTrees = new List<TreeNode>();
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            PostOrder(root);
            return _dupTrees;
        }

        private string PostOrder(TreeNode node)
        {
            if (node == null) return "null";
            string treeHash = node.val + ',' + PostOrder(node.left) + ',' + PostOrder(node.right);

            if (_treeHashesAndCounts.TryGetValue(treeHash, out var count))
            {
                if(count==1) _dupTrees.Add(node);
                _treeHashesAndCounts[treeHash]++;
            }
            else _treeHashesAndCounts.Add(treeHash, 1);
            
            return treeHash;
        }
    }
}