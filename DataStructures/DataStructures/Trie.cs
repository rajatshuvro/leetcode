namespace Problems
{
    class TrieNode {
		public char C;
		public string value;
		public TrieNode[] Children;
		public TrieNode() {
			C = '*';
			value = null;
			Children = null;
		}
		public TrieNode(char c) {
			C = c;
			value = null;
			Children = null;
		}

		public TrieNode FindChild(char c){
			if (Children?[c - 'a'] == null)
				return null;

			return Children[c-'a'];
		}

		public TrieNode AddChild(char c){
			if (Children == null)
				Children = new TrieNode[26];
			if (Children [c - 'a'] == null) {
				//Console.WriteLine ("inserting child");
				Children [c - 'a'] = new TrieNode(c);
			}
			return Children [c - 'a'];
		}

	}

	public class Trie {
		private TrieNode root;

		public Trie() {
			root = new TrieNode();
		}

		// Inserts a word into the trie.
		public void Insert(string word) {
			var current = root;
			foreach (var c in word) {
				current = current.AddChild (c);

			}
			//insert the word at the last node
			current.value = word;

		}

		// Returns if the word is in the trie.
		public bool Search(string word) {
			var current = root;
			foreach (var c in word) {
				if (current.Children==null) return false;

				var child = current.FindChild (c);
				if (child != null)  {
					//keep going deeper as long as there is a match
					current = child;
				}
				else
					return false;
			}
			//returning true only the node contains the word in value
			if (current.value == null)
				return false;
			return current.value.Equals (word);
		}

		// Returns if there is any word in the trie
		// that starts with the given prefix.
		public bool StartsWith(string word) {
			var current = root;
			foreach (var c in word) {
				if (current.Children==null) return false;
				var child = current.FindChild (c);
				if (child != null)
					//keep going deeper as long as there is a match
					current = child;
				else
					return false;
			}
			//returning true if we haven't fallen off the tree
			return true;
		}
	}
}