using DataStructures;

namespace Problems.Trees
{
    //https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
    public class BinTreeCodec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null) return "null";

            return root.val.ToString() + ',' + serialize(root.left) + ',' + serialize(root.right);
            
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            var splits = data.Split(',');

            return Deserialize(splits, 0).root;
        }

        public (TreeNode root, int nextVal) Deserialize(string[] valStrings, int i)
        {
            if (i >= valStrings.Length) return (null, i+1);
            
            var root = GetNode(valStrings[i]);
            if (root == null) return (null, i + 1);
            
            (root.left, i)  = Deserialize(valStrings, i + 1);
            (root.right, i) = Deserialize(valStrings, i);
            return (root, i);
        }

        private static TreeNode GetNode(string valString)
        {
            if (valString == "null") return null;
            var val = int.Parse(valString);
            return new TreeNode(val);
        }
    }
}