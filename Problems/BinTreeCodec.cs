using DataStructures;

namespace Problems
{
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
            return null;
        }
    }
}