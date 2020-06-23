using System;
using System.Collections.Generic;
using DataStructures;

namespace Problems.Trees
{
    //https://leetcode.com/problems/unique-binary-search-trees-ii/
    public class UniqueBst2
    {
        private Dictionary<(int i, int j), List<TreeNode>> _trees= new Dictionary<(int i, int j), List<TreeNode>>();
        public IList<TreeNode> GenerateTrees(int n)
        {
            if(n==0) return new List<TreeNode>();
            return GetAllBinSearchTrees(1, n);
        }

        private IList<TreeNode> GetAllBinSearchTrees(int i, int j)
        {
            if (i > j || j < i) return null;
            
            if (_trees.TryGetValue((i, j), out var trees)) return trees;
            if (i == j)
            {
                var root = new TreeNode(i);
                _trees[(i,j)] = new List<TreeNode>(){root};
                return _trees[(i, j)];
            }

            if (i + 1 == j)
            {
                var root_i = new TreeNode(i) {right = new TreeNode(j)};

                var root_j = new TreeNode(j) {left = new TreeNode(i)};
                _trees.Add((i,j), new List<TreeNode>(){root_i, root_j});
                return _trees[(i, j)];
            }
            
            trees = new List<TreeNode>();
            for (int k = i; k <= j; k++)
            {
                var leftTrees = GetAllBinSearchTrees(i, k - 1);
                var rightTrees = GetAllBinSearchTrees(k + 1, j);
                
                if (leftTrees == null && rightTrees != null)
                {
                    foreach (var rightTree in rightTrees)
                    {
                        var root = new TreeNode(k) {right = rightTree};
                        trees.Add(root);    
                    }
                    continue;
                }
                
                if (leftTrees != null && rightTrees == null)
                {
                    foreach (var leftTree in leftTrees)
                    {
                        var root = new TreeNode(k) {left = leftTree};
                        trees.Add(root);    
                    }
                    continue;
                }
                
                //both sub-trees are present
                foreach (var leftTree in leftTrees)
                {
                    foreach (var rightTree in rightTrees)
                    {
                        var root = new TreeNode(k)
                        {
                            left =  leftTree,
                            right = rightTree
                        };
                        trees.Add(root);
                    }
                }
            }
            _trees.Add((i,j), trees);
            return trees;
        }
    }
}