using System.Collections.Generic;
using Problems.SystemDesigns;
using Xunit;

namespace UnitTests.SystemDesigns
{
    public class InMemoryFileSystemTests
    {
        [Fact]
        public void Case0()
        {
            var fs = new InMemoryFileSystem();
            Assert.Equal(new List<string>(),fs.Ls("/") );
            
            fs.Mkdir("/a/b/c");
            fs.AddContentToFile("/a/b/c/d","hello");
            
            Assert.Equal(new List<string>(){"a"}, fs.Ls("/") );
            Assert.Equal("hello", fs.ReadContentFromFile("/a/b/c/d"));
            
            fs.Mkdir("/a/b2/");
            Assert.Equal(new List<string>(){"b","b2"}, fs.Ls("/a") );
            fs.AddContentToFile("/a/b/f", "file in folder b");
            Assert.Equal("file in folder b", fs.ReadContentFromFile("/a/b/f"));
        }

        // ["FileSystem","mkdir","ls","ls","mkdir","ls","ls","addContentToFile","ls","ls","ls"]
        // [[],["/goowmfn"],["/goowmfn"],["/"],["/z"],["/"],["/"],["/goowmfn/c","shetopcy"],["/z"],["/goowmfn/c"],["/goowmfn"]]
        // expected: [null,null,[],["goowmfn"],null,["goowmfn","z"],["goowmfn","z"],null,[],["c"],["c"]]
        [Fact]
        public void Case42()
        {
            var fs = new InMemoryFileSystem();
            fs.Mkdir("/goowmfn");
            
            Assert.Equal(new List<string>(), fs.Ls("/goowmfn"));
            Assert.Equal(new List<string>(){"goowmfn"}, fs.Ls("/"));
            
            fs.Mkdir("/z");
            Assert.Equal(new List<string>(){"goowmfn", "z"}, fs.Ls("/"));
            
            fs.AddContentToFile("/goowmfn/c","shetopcy");
            
            Assert.Equal(new List<string>(), fs.Ls("/z"));
            
            Assert.Equal(new List<string>(){"c"}, fs.Ls("/goowmfn"));
            Assert.Equal(new List<string>(){"c"}, fs.Ls("/goowmfn/c"));
            
        }
    }
}