using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problems.SystemDesigns
{
    //https://leetcode.com/problems/design-in-memory-file-system/
    public class Folder
    {
        public const char PathSeparator = '/';
        public readonly string Name;
        public Dictionary<string, Folder> _children;
        public Dictionary<string, string> _documents;

        public Folder(string name)
        {
            Name = name;
            _children = new Dictionary<string, Folder>();
            _documents = new Dictionary<string, string>();
        }

        public void Mkdir(string path)
        {
            if(string.IsNullOrEmpty(path)) return;
            var subPaths = path.Split(PathSeparator);

            var current = this;
            foreach (var subPath in subPaths)
            {
                if(subPath==string.Empty) continue;
                if (!current._children.ContainsKey(subPath)) current._children.Add(subPath, new Folder(subPath) );
                
                current = current._children[subPath];
            }
        }

        private Folder GetFolder(string path)
        {
            if(string.IsNullOrEmpty(path)) return this;
            var subPaths = path.Split(PathSeparator);
            var current = this;

            foreach (var subPath in subPaths)
            {
                if(subPath==string.Empty) continue;
                if (current._children.ContainsKey(subPath))
                    current = current._children[subPath];
                else
                {
                    current = null;
                    break;
                }
            }

            return current;

        }

        public void AddFileContent(string path, string content)
        {
            var (folderPath, fileName)=GetFolderAndFileName(path);

            var folder = GetFolder(folderPath);
            if (folder == null) return;

            if (folder._documents.ContainsKey(fileName)) folder._documents[fileName] += content;
            else folder._documents[fileName] = content;
        }

        public string GetFileContent(string path)
        {
            var (folderPath, fileName)=GetFolderAndFileName(path);

            var folder = GetFolder(folderPath);
            if (folder == null) return null;

            return folder._documents.ContainsKey(fileName) ? folder._documents[fileName]:null;
        }

        public List<string> Ls(string path)
        {
            var list = new List<string>();
            var (folderPath, fileName)=GetFolderAndFileName(path);

            var folder = GetFolder(folderPath);
            if (folder == null) return list;

            //if path is a file name.
            if (folder._documents.ContainsKey(fileName))
            {
                list.Add(fileName);
            }
            
            //if path is a directory
            if (folder._children.ContainsKey(fileName))
            {
                folder = folder._children[fileName];
            }
            
            list.AddRange(folder._children.Keys);
            list.AddRange(folder._documents.Keys);
            list.Sort();
            
            return list;
        }

        private static (string folderPath, string fileName) GetFolderAndFileName(string path)
        {
            var i = path.LastIndexOf(PathSeparator);
            var folderPath = path.Substring(0,i);
            var fileName = path.Substring(i+1);

            return (folderPath, fileName);
        }
    }

    
    public class InMemoryFileSystem
    {
        private readonly Folder _root;
        public InMemoryFileSystem() {
            _root = new Folder(string.Empty);
        }
    
        public IList<string> Ls(string path)
        {
            return _root.Ls(path);
        }
    
        public void Mkdir(string path) {
            _root.Mkdir(path);
        }
    
        public void AddContentToFile(string filePath, string content) {
            _root.AddFileContent(filePath, content);
        }
    
        public string ReadContentFromFile(string filePath)
        {
            return _root.GetFileContent(filePath);
        }
    }
}