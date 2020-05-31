using System.Collections.Generic;
using System.IO;

namespace Problems.SystemDesigns
{
    public class PathNode
    {
        public readonly string Name;
        public readonly int Value;
        private Dictionary<string, PathNode> _children;

        public PathNode(string name, int value)
        {
            Name = name;
            Value = value;
            _children = new Dictionary<string, PathNode>();
        }
    }

    public class FileSystem
    {
        //https://leetcode.com/problems/design-file-system/
        private readonly Dictionary<string, int> _pathsAndValue;
        public FileSystem() {
            _pathsAndValue = new Dictionary<string, int> {{"", -1}};
        }
    
        public bool CreatePath(string path, int value)
        {
            if (string.IsNullOrEmpty(path)) return false;
            var lastSeparatorIndex = path.LastIndexOf('/');

            if (lastSeparatorIndex < 0) return false;

            var parentPath = path.Substring(0, lastSeparatorIndex);
            if (!_pathsAndValue.ContainsKey(parentPath)) return false;

            if (_pathsAndValue.ContainsKey(path)) return false;
            _pathsAndValue.Add(path, value);
            return true;
        }
    
        public int Get(string path)
        {
            if (_pathsAndValue.ContainsKey(path)) return _pathsAndValue[path];
            return -1;
        }
    }
}